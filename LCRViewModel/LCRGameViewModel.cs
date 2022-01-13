using LCRViewModel.Helpers;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LCRViewModel
{
    public class LCRGameViewModel : NotificationEnabled
    {

        private int? _numberOfPlayers;
        public int? NumberOfPlayers
        {
            get { return _numberOfPlayers; }
            set
            {
                _numberOfPlayers = value;
                OnPropertyChanged();
                AddRowCommandWrapper.CheckIsExecutable();                
            }
        }

        private int? _numberOfGames;
        public int? NumberOfGames
        {
            get { return _numberOfGames; }
            set
            {
                _numberOfGames = value;
                OnPropertyChanged();
                AddRowCommandWrapper.CheckIsExecutable();
            }
        }

        public SimulationViewModel SelectedSimulation { get; set; }

        private bool _isRunningSimulation;


        private CommonCommand AddRowCommandWrapper;
        public ICommand AddRowCommand { get { return AddRowCommandWrapper; } }

        private CommonCommand RunSimulationCommandWrapper;
        public ICommand RunSimulationCommand { get { return RunSimulationCommandWrapper; } }

        public ObservableCollection<SimulationViewModel> SimulationGameList { get; set; }

        public LCRGameViewModel()
        {
            RunSimulationCommandWrapper = new CommonCommand(StartSimulation, CanRunSimulation);
            InitializeSimulationListInput();


            AddRowCommandWrapper = new CommonCommand(AddRow, CanAddRow);            
        }

        private void InitializeSimulationListInput() {
            SimulationGameList = new ObservableCollection<SimulationViewModel> {
                new SimulationViewModel(3,100),
                new SimulationViewModel(4,100),
                new SimulationViewModel(5,100),
                new SimulationViewModel(5,1000),
                new SimulationViewModel(5,10000),
                new SimulationViewModel(5,100000),
                new SimulationViewModel(6,100),
                new SimulationViewModel(7,100)
            };

        }

        private void StartSimulation(object parameter)
        {
            _isRunningSimulation = true;
            CheckExcecutables();
            RunSimulations();
        }

        private void RunSimulations()
        {
            var tasks = new List<Task>();
            var listCount = SimulationGameList.Count();

            foreach (var simulation in SimulationGameList)
            {
                var simulationTask = new Task(simulation.RunSimulation);
                simulationTask.GetAwaiter().OnCompleted(() =>
                {
                    listCount--;
                    if (listCount == 0)
                    {
                        _isRunningSimulation = false;
                        CheckExcecutables();
                    }
                });
                tasks.Add(simulationTask);
                simulationTask.Start();
            }
        }

        private bool CanRunSimulation(object parameter)
        {
            return SimulationGameList != null && SimulationGameList.Any() && !_isRunningSimulation;
        }

        private void AddRow(object parameter)
        {
            SimulationGameList.Add(new SimulationViewModel(NumberOfPlayers.Value, NumberOfGames.Value));

            NumberOfGames = null;
            NumberOfPlayers = null;
            OnPropertyChanged("SimulationGameList");

            CheckExcecutables();
        }

        private bool CanAddRow(object parameter)
        {
            return
                NumberOfPlayers.GetValueOrDefault() >= 3 &&
                NumberOfGames.GetValueOrDefault() > 0 && !_isRunningSimulation;

        }

        private void CheckExcecutables()
        {
            RunSimulationCommandWrapper.CheckIsExecutable();
            AddRowCommandWrapper.CheckIsExecutable();            
        }
    }
}
