namespace LCRModel.Entities
{
    public class Player
    {
        public int Chips { get; set; }
        public int PlayerTurn { get; }

        public Player(int playerTurn, int initialChipCount)
        {
            PlayerTurn = playerTurn;
            Chips = initialChipCount;
        }

        public DieFace RollDice(Dice _dice) {
            return _dice.Roll();
        }
    }
}
