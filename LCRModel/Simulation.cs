using System.Linq;

namespace LCRModel
{
    public class Simulation
    {        
        public int ShortestGame { get { return _turnsPerGame.Min(); } }
        public int LongestGame { get { return _turnsPerGame.Max(); } }
        public int AverageGame { get { return (int)_turnsPerGame.Average(); } }
        

        private int[] _turnsPerGame;
        private int _numberOfGames;
        private LCRGame Game { get; set; }
        

        public Simulation(LCRGame _gameConfiguration,int numberOfGames)
        {
            _numberOfGames = numberOfGames;
            _turnsPerGame = new int[numberOfGames];
            Game = _gameConfiguration;
        }

        public void RunSimulations()
        {
            for (int i = 0; i < _numberOfGames; i++)
            {
                _turnsPerGame[i] = Game.StartGame();
            }
        }

    }
}
