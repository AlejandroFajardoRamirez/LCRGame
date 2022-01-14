using LCRModel;
using LCRViewModel.Helpers;
using System;
using System.Threading.Tasks;

namespace LCRViewModel
{
    public class SimulationViewModel : NotificationEnabled
    {
        private Guid _simulationId;
        public string SimulationId { get { return _simulationId.ToString(); } }

        private int _numberOfPlayers;
        public int NumberOfPlayers { get { return _numberOfPlayers; } }

        private int _numberOfGames;
        public int NumberOfGames { get { return _numberOfGames; } }

        private string _simulationStatus;
        public string SimulationStatus { get { return _simulationStatus; } }

        public int? ShortestGame { get { return _simulation.ShortestGame; } }
        public int? LongestGame { get { return _simulation.LongestGame; } }
        public int? AverageGame { get { return _simulation.AverageGame; } }

        private Simulation _simulation { get; set; }
        public Task SimulationsFinished { get; set; }

        public SimulationViewModel(int numberOfPlayers, int numberOfGames)
        {
            _numberOfPlayers = numberOfPlayers;
            _numberOfGames = numberOfGames;
            _simulationId = Guid.NewGuid();
            _simulation = new Simulation(_numberOfPlayers,_numberOfGames);

            _simulation.SimulationsFinished = OnSimulationsFinished;
        }

        public void RunSimulation()
        {
            _simulationStatus = "Running";
            OnPropertyChanged("SimulationStatus");
            _simulation.RunSimulations();          
        }

        public void OnSimulationsFinished()
        {
            OnPropertyChanged("ShortestGame");
            OnPropertyChanged("LongestGame");
            OnPropertyChanged("AverageGame");

            _simulationStatus = "Complete";
            OnPropertyChanged("SimulationStatus");
            SimulationsFinished.Start();
        }
    }
}
