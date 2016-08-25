using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;
using BackgammonLogic.Components;
using BackgammonLogic.Interfaces;

namespace BackgammonGame
{
    public class GameBoard : Panel
    {
        public enum LightTypeEnum
        {
            None,
            Source,
            Target
        }
        public GameBoard()
        {
            DoubleBuffered = true;
            DrawScene = null;
            _lightType = LightTypeEnum.None;
            ClickEven = false;
            InputEnabled = false;
            _currentPlayer = null;
            _mouseClicked1 = -1;
            _mouseClicked2 = -1;
        }

        public readonly int DesiredHeight = 12 * ColorsAndConstants.FieldSize;
        public readonly int DesiredWidth = 14 * ColorsAndConstants.FieldSize;

        private LightTypeEnum _lightType;
        public LightTypeEnum LightType
        {
            get { return _lightType; }
            private set
            {
                _lightType = value;
                Invalidate();
            }
        }

        public bool InputEnabled { get; private set; }

        private bool ClickEven { get; set; }

        public Scene DrawScene;

        private Drawable _mouseOver;
        public Drawable MouseOver
        {
            get { return _mouseOver; }
            protected set
            {
                _mouseOver = value;
                foreach (var l in Listeners)
                    l.OnMouseOverChange(_mouseOver);
            }
        }

        private int _mouseClicked1, _mouseClicked2;
        private HPlayer _currentPlayer;

        private IEnumerable<IGameBoardEvent> Listeners { get; } = new List<IGameBoardEvent>();

        public void EnableInputFor(HPlayer p)
        {
            ClickEven = false;
            InputEnabled = true;
            _currentPlayer = p;
            LightType = LightTypeEnum.Source;
            Invalidate();
        }

        public void DisableInput()
        {
            InputEnabled = false;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.HighQuality;

            g.Clear(ColorsAndConstants.BackgroundColor);

            if (DrawScene != null)
            {
                g.FillRectangle(ColorsAndConstants.BandBrush, new Rectangle(6 * ColorsAndConstants.FieldSize, 0, 2 * ColorsAndConstants.FieldSize, 12 * ColorsAndConstants.FieldSize));

                switch (LightType)
                {
                    case LightTypeEnum.None:
                        foreach (var d in DrawScene.Items)
                            d.Draw(g);
                        break;
                    case LightTypeEnum.Source:
                        foreach (var d in DrawScene.Items)
                            if (d is AbstractField)
                            {
                                var dd = d as AbstractField;
                                if (DrawScene.PossibleSources.Contains(dd.Number))
                                    dd.DrawWithLight(g, ColorsAndConstants.SourceLight);
                                else dd.Draw(g);
                            }
                            else d.Draw(g);
                        break;

                    case LightTypeEnum.Target:
                    {
                        var targets = DrawScene.PossibleTargets.ContainsKey(_mouseClicked1) ? DrawScene.PossibleTargets[_mouseClicked1] : new int[0];

                        foreach (var d in DrawScene.Items)
                                if (d is AbstractField)
                                {
                                    var dd = d as AbstractField;
                                    if (targets.Contains(dd.Number))
                                        dd.DrawWithLight(g, ColorsAndConstants.TargetLight);
                                    else
                                        dd.Draw(g);
                                }
                                else d.Draw(g);
                    }
                        break;
                }

                if (MouseOver != null)
                {
                    g.DrawRectangle(ColorsAndConstants.SelectionPen, MouseOver.Rect);
                    Invalidate(MouseOver.OverRect);
                }
            }


            base.OnPaint(e);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (DrawScene != null)
            {
                if (MouseOver != null)
                {
                    Invalidate(MouseOver.OverRect);
                    MouseOver = null;
                }
                foreach (var d in DrawScene.Items)
                    if (d is AbstractField)
                        if (d.TestAgainst(e.Location))
                        {
                            MouseOver = d;
                            break;
                        }
            }

            base.OnMouseMove(e);
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            if (InputEnabled)
            {
                if (DrawScene != null)
                    foreach (var drawable in DrawScene.Items)
                        if (drawable is AbstractField)
                            if (drawable.TestAgainst(e.Location))
                            {
                                var dd = drawable as AbstractField;
                                if (ClickEven)
                                {
                                    if (DrawScene.PossibleTargets[_mouseClicked1].Contains(dd.Number))
                                    {
                                        _mouseClicked2 = dd.Number;
                                        ClickEven = false;
                                        LightType = LightTypeEnum.None;
                                        SendMoveToPlayer();
                                    }
                                    else
                                    {
                                        _mouseClicked1 = -1;
                                        _mouseClicked2 = -1;
                                        ClickEven = false;
                                        LightType = LightTypeEnum.Source;
                                    }
                                }
                                else
                                {
                                    if (DrawScene.PossibleSources.Contains(dd.Number))
                                    {
                                        _mouseClicked1 = dd.Number;
                                        LightType = LightTypeEnum.Target;
                                        ClickEven = !ClickEven;
                                    }
                                }

                                break;
                            }
            }
            base.OnMouseClick(e);
        }

        private void SendMoveToPlayer()
        {
            var m = new Move(_mouseClicked1, _mouseClicked2, _currentPlayer.Color);
            DisableInput();
            _currentPlayer?.ReceiveMove(m);
        }

    }
}
