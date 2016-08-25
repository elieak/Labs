using System;
using System.Windows.Forms;
using BackgammonLogic.Components;
using BackgammonLogic.Interfaces;
using static BackgammonLogic.Components.MoveResult;

namespace BackgammonGame
{
    public partial class Form1 : Form, IGameControllerEvent
    {
        private GameStateController Game;
        private HPlayer CurrentPlayer;
        public Form1()
        {
            InitializeComponent();
            Game = null;
        }

        private void newGameToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            OpenGame(new GameStateController(new HPlayer(PColorEnum.White, this),
                new HPlayer(PColorEnum.Black, this)));
            
        }
        private void OpenGame(GameStateController theGame)
        {
            Game = theGame;
            Game.Listeners.Add(this);
            Game.CallOnGamestateUpdate();
        }
        public void EnableRoll(HPlayer humanPlayer)
        {
            CurrentPlayer = humanPlayer;
            button1.Enabled = true;
        }

        public void DisableRoll()
        {
            button1.Enabled = false;
        }

        public void EnableInputFor(HPlayer humanPlayer)
        {
            GamePanel.EnableInputFor(humanPlayer);
        }

        public void OnGamestateUpdate()
        {
            label1.Text = Game.GameState.CurrentTurn == PColorEnum.White ? "White player move." : "Black player move.";

            GamePanel.DrawScene = Game.GetScene();

            var l2 = Game.GameState.PlayerNeeds(Game.GameState.CurrentTurn);

            label2.Text = l2 != -1 ? $"You still need to get {l2} stones home to end the game" : "Enter stones to the game";


            GamePanel.Invalidate();
        }

        public void OnGameEnd()
        {
            var message = "Game Ended! The winner is: ";
            if (Game.GameState.Winner == PColorEnum.Black)
                message = message + "Black Player!";
            else message = message + "White Player!";
            ShowMessage(message);
        }

        public void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }

        private void StopGame()
        {
            Game = null;
            CurrentPlayer = null;
            GamePanel.DrawScene = null;
            GamePanel.Invalidate();
            label1.Text = "";
            button1.Enabled = false;
            label2.Text = "";
        }

        private void endGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StopGame();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DisableRoll();
            var res = Game.RollTheDice(CurrentPlayer);
            if (res.Result == ResultType.Negative)
            {
                MessageBox.Show($"Could not end game, {res.Description}");
            }
        }
    }
}
