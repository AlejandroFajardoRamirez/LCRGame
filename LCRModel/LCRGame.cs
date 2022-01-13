using LCRModel.Entities;
using System;
using System.Linq;

namespace LCRModel
{
    public class LCRGame
    {
        #region Private Properties
        private readonly int InitialChipCountPerPlayer = 3;
        private readonly int MaxNumberOfDice = 3;

        private readonly int _numberOfPlayers;
        private readonly int _totalChipsInGame;

        private int _turns;
        private Dice Die;
        #endregion

        public Player[] Players;

        public LCRGame(int numberOfPlayers) {
            if (numberOfPlayers < InitialChipCountPerPlayer)
                throw new ApplicationException($"The number of players must be {InitialChipCountPerPlayer} or more");

            _numberOfPlayers = numberOfPlayers;
            _totalChipsInGame = numberOfPlayers * InitialChipCountPerPlayer;
            Die = new Dice();
        }

        public void BuildPlayers()
        {
            Players = new Player[_numberOfPlayers];
            for (int i = 0; i < _numberOfPlayers; i++)
            {
                Players[i] = new Player(i, InitialChipCountPerPlayer);
            }
        }

        public int StartGame() {
            BuildPlayers();

            int? playerInTurn = null;
            _turns = 0;

            while (!Players.Any(p => p.Chips == _totalChipsInGame))
            {
                _turns++;

                playerInTurn = SetNextPlayerInTurn(playerInTurn);

                RollDiceForPlayer(Players[playerInTurn.Value]);
            }

            return _turns;
        }

        public int? SetNextPlayerInTurn(int? _currentPlayerInTurn) {            
            if (!_currentPlayerInTurn.HasValue || _currentPlayerInTurn.Value + 1 == _numberOfPlayers)
            {
                return 0;
            }
            else {
                return ++_currentPlayerInTurn;
            }
        }

        private void RollDiceForPlayer(Player player)
        {
            var diceToRoll = player.Chips > MaxNumberOfDice ? MaxNumberOfDice : player.Chips;

            for (int i = 0; i < diceToRoll; i++)
            {
                RollDieForPlayer(player);
            }
        }

        private void RollDieForPlayer(Player player)
        {
            var dieFace = player.RollDice(Die);
            GiveChipToPlayer(player, dieFace);
        }

        public void GiveChipToPlayer(Player player, DieFace dieFace)
        {
            bool giveChip = false;
            int playerToGiveChip = 0;

            if (dieFace == DieFace.L)
            {
                giveChip = true;
                playerToGiveChip = player.PlayerTurn == 0 ? _numberOfPlayers - 1 : player.PlayerTurn - 1;
            }
            else if (dieFace == DieFace.R) { 
                giveChip = true;
                playerToGiveChip = player.PlayerTurn == _numberOfPlayers - 1 ? 0 : player.PlayerTurn + 1;
            }

            if (giveChip)
            {
                player.Chips--;
                Players[playerToGiveChip].Chips++;
            }
        }


    }
}
