using System;

namespace BackgammonLogic.Components
{
    public class DiceState
    {
        public DiceState(Dice dice)
        {
            if (dice.Left == dice.Right)
            {
                Pipes = new[] {dice.Left, dice.Left, dice.Left, dice.Left};
                PrimevalLength = 4;
            }
            else
            {
                if (dice.Left < dice.Right)
                    Pipes = new[] {dice.Left, dice.Right};
                else
                    Pipes = new[] {dice.Right, dice.Left};
                PrimevalLength = 2;
            }
        }

        private DiceState(int[] _possibilities, int _primevalLength)
        {
            Pipes = _possibilities;
            PrimevalLength = _primevalLength;
        }

        public DiceState ReducedByOne(int o)
        {
            if (Pipes.Length == 0)
                throw new Exception("The DiceState is already empty!");

            var notyet = true;
            var new_possibilities = new int[Pipes.Length - 1];
            var p = 0;
            for (var i = 0; i < Pipes.Length; ++i)
                if (notyet && o == Pipes[i])
                {
                    notyet = false;
                }
                else
                    new_possibilities[p++] = Pipes[i];

            if (!notyet)
            {
                return new DiceState(new_possibilities, PrimevalLength);
            }
            throw new Exception($"The DiceState does not contain a number {o} !");
        }

        public int[] Pipes { get; }

        public int PrimevalLength { get; }
    }
}
