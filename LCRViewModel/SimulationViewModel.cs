using LCRModel;
using System;
using System.ComponentModel;

namespace LCRViewModel
{
    public class SimulationViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private int _numberOfPlayers;
        public int NumberOfPlayers { get { return _numberOfPlayers; } }

        private int _numberOfGames;
        public int NumberOfGames { get { return _numberOfGames; } }

        private string _simulationStatus;
        public string SimulationStatus { get { return _simulationStatus; } }

        public int ShortestGame { get { return _simulation.ShortestGame; } }
        public int LongestGame { get { return _simulation.LongestGame; } }
        public int AverageGame { get { return _simulation.AverageGame; } } 

        private Simulation _simulation { get; set; }

        public SimulationViewModel(int numberOfPlayers, int numberOfGames)
        {
            _numberOfPlayers = numberOfPlayers;
            _numberOfGames = numberOfGames;            

            _simulation = new Simulation(new LCRGame(_numberOfPlayers),_numberOfGames);            
        }

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public void RunSimulation()
        {
            _simulationStatus = "Running";
            OnPropertyChanged("SimulationStatus");

            _simulation.RunSimulations();

            OnPropertyChanged("ShortestGame");
            OnPropertyChanged("LongestGame");
            OnPropertyChanged("AverageGame");

            _simulationStatus = "Complete";
            OnPropertyChanged("SimulationStatus");
        }


    }
}
