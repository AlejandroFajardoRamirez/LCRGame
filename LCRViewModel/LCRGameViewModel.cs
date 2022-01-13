using LCRViewModel.Helpers;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LCRViewModel
{
    public class LCRGameViewModel { 
        
        public SimulationViewModel SelectedSimulation { get; set; }

        private bool _isRunningSimulation;

        private CommonCommand RunSimulationCommandWrapper;
        public ICommand RunSimulationCommand { get { return RunSimulationCommandWrapper; } }

        public ObservableCollection<SimulationViewModel> SimulationGameList { get; set; }

        public LCRGameViewModel()
        {
            InitializeSimulationListInput();
            
            RunSimulationCommandWrapper = new CommonCommand(StartSimulation, CanRunSimulation);
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
            RunSimulationCommandWrapper.CheckIsExecutable();
            RunSimulations();
        }

        private void RunSimulations()
        {
            var tasks = new List<Task>();
            var listCount = SimulationGameList.Count();

            foreach (var simulation in SimulationGameList)
            {
                simulation.RunSimulation();
            }
            _isRunningSimulation = false;
            RunSimulationCommandWrapper.CheckIsExecutable();
        }

        private bool CanRunSimulation(object parameter)
        {
            return SimulationGameList != null && SimulationGameList.Any() && !_isRunningSimulation;
        }

    }
}
