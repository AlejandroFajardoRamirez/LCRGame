using System;

namespace LCRModel.Entities
{
    public class Dice
    {
        private Random _diceRoller;

        public Dice() { _diceRoller = new Random(); }

        public DieFace Roll()
        {
            var result = _diceRoller.Next(0, 5);
            return Enum.IsDefined(typeof(DieFace), result) ? (DieFace)result : DieFace.DOT;
        }
    }

    public enum DieFace
    {
        L = 0,
        C = 1,
        R = 2,
        DOT = 3
    }
}
