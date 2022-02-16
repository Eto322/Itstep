using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Windows.Data;
using System.Windows.Input;
using dz6.InfoStructure;
using dz6.Model;

namespace dz6.ViewModel
{
    public class MainViewModel : BaseNotify
    {

        private ObservableCollection<Human> _humans;
        private RelayCommand _add;
        private RelayCommand _remove;
        private RelayCommand _sort;
        private RelayCommand _update;
        public Human SelectedHuman { get; set; }
        public ICommand SortCommand => _sort ?? (new RelayCommand(param =>
        {
            string sortParam = param.ToString();
            Humans.SortDescriptions.Clear();
            Humans.SortDescriptions.Add(new SortDescription(sortParam, ListSortDirection.Ascending));

        }));
        public ICommand UpdateCommand
        {
            get
            {
                if (_update == null)
                {
                    _update = new RelayCommand(x =>
                    {
                        //SelectedHuman = new Human(NName, NSecondName);
                        var s = _humans.FirstOrDefault(h => h.Name == SelectedHuman.Name
                                                            && h.SecondName == SelectedHuman.SecondName);
                        if (s != null)
                        {
                            s.Name = NName;
                            s.SecondName = NSecondName;
                        }
                        Humans?.Refresh();
                        Notify(nameof(SelectedHuman));
                    });


                }
                return _update;
            }
        }

        public string NName
        {
            get;
            set;
        }
   public string NSecondName { get; set; }

   public RelayCommand AddCommand
   {
       get
       {
           return _add ?? (_add = new RelayCommand(obj =>
           {
               Human hum = new Human(NName,NSecondName);
               _humans.Insert(0, hum);
               SelectedHuman = hum;
           }));
       }
   }


   public ICommand RemoveCommand =>
            _remove ?? (_remove = new RelayCommand(human =>
            {
                _humans.Remove(SelectedHuman);
            }, (human) => _humans.Count != 0));

        public ICollectionView Humans { get; set; }

        public MainViewModel()
        {
            _humans = new ObservableCollection<Human>()
            {
                new Human("Nikol","Kotik"),
                new Human("Aadim","Lisiy")
            };
            Humans = CollectionViewSource.GetDefaultView(_humans);
        }
    }
}