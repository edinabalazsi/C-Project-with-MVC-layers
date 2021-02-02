using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Teahouse.Wpf
{
    class MainViewModel : ViewModelBase
    {
        private MainLogic logic;
        private ObservableCollection<ExtraViewModel> allExtras;
        private ExtraViewModel selectedExtra;

        public ExtraViewModel SelectedExtra
        {
            get { return selectedExtra; }
            set { Set(ref selectedExtra, value); }
        }
        public ObservableCollection<ExtraViewModel> AllExtras
        {
            get { return allExtras; }
            set { Set(ref allExtras, value); }
        }

        public ICommand AddCmd { get; private set; }
        public ICommand DelCmd { get; private set; }
        public ICommand ModCmd { get; private set; }
        public ICommand LoadCmd { get; private set; }

        public Func<ExtraViewModel, bool> EditorFunc { get; set; }

        public MainViewModel()
        {
            logic = new MainLogic();

            AddCmd = new RelayCommand(() => logic.EditExtra(null, EditorFunc));
            DelCmd = new RelayCommand(() => logic.ApiDelExtra(selectedExtra));
            LoadCmd = new RelayCommand(() => 
            AllExtras = new ObservableCollection<ExtraViewModel>(logic.ApiGetExtras()));
            ModCmd = new RelayCommand(() => logic.EditExtra(selectedExtra, EditorFunc));
        }
    }
}
