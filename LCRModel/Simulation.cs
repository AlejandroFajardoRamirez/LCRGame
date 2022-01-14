using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LCRModel
{
    public class Simulation
    {
        public int? ShortestGame { get { return _turnsPerGame.Any() ? _turnsPerGame.Min() : null; } }
        public int? LongestGame { get { return _turnsPerGame.Any() ? _turnsPerGame.Max() : null; } }
        public int? AverageGame { get { return _turnsPerGame.Any() ? (int)_turnsPerGame.Average() : null; } }


        private List<int> _turnsPerGame;
        private int _numberOfGames;
        private readonly int _numberOfPlayers;

        public Action SimulationsFinished { get; set; }

        public Simulation(int numberOfPlayers,int numberOfGames)
        {
            _numberOfPlayers = numberOfPlayers;
            _numberOfGames = numberOfGames;
            _turnsPerGame = new List<int>();
        }

        public void RunSimulations()
        {            
            var tasks = new List<Task>();
            var gamesLeft = _numberOfGames;

            for (int i = 0; i < _numberOfGames; i++)
            {
                var game = new LCRGame(_numberOfPlayers);
                var simulationTask = new Task<int>(game.StartGame);
                simulationTask.GetAwaiter().OnCompleted(() =>
                {
                    _turnsPerGame.Add(simulationTask.Result);
                    gamesLeft--;
                    if (gamesLeft == 0)
                    {                        
                        SimulationsFinished();
                    }
                });
                tasks.Add(simulationTask);
                simulationTask.Start();
            }
        }

    }
}
