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

        public ObservableCollection<SimulationViewModel> SimulationGameList { get; set; }

        public LCRGameViewModel()
        {  
            InitializeSimulationListInput();
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


    }
}
