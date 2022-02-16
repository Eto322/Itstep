using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Windows.Data;
using System.Windows.Input;
using dz6.InfoStructure;
using dz6.Model;
using dz6.View;
using Infralution.Localization.Wpf;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace dz6.ViewModel
{
    public class MainViewModel : BaseNotify
    {

        static void SearializeJson(object data, string path)//нагло украл
        {
            JsonSerializer j = new JsonSerializer();
            StreamWriter sw = new StreamWriter(path);
            JsonWriter jw = new JsonTextWriter(sw);
            j.Serialize(jw, data);
            jw.Close();
            sw.Close();
        }
        static object DeserealizeJson(Type dataType, string path)// не так нагло но тоже украл
        {
           ;
            JsonSerializer j = new JsonSerializer();
            StreamReader sw = new StreamReader(path);
            JsonReader jr = new JsonTextReader(sw);
            JObject obj  = j.Deserialize(jr) as JObject;
            jr.Close();
            sw.Close();
            return obj.ToObject(dataType);
        }
        private ObservableCollection<People> _peoples;
        private RelayCommand _save;
        private RelayCommand _sort;
        private RelayCommand _update;
        private RelayCommand _translate;
        private RelayCommand _add;
        private RelayCommand _remove;
       
       
        private bool _langState = false;
        public People SelectedPeople { get; set; }
        public ICommand SortCommand => _sort ?? (new RelayCommand(param =>
        {
            string sortParam = param.ToString();
            Peoples.SortDescriptions.Clear();
            Peoples.SortDescriptions.Add(new SortDescription(sortParam, ListSortDirection.Ascending));

        }));

        public ICommand SaveCommand
        {
            get
            {
                if (_save == null)
                {
                    _save = new RelayCommand(s =>
                    {
                       SearializeJson(_peoples,"Peoples.json");
                    });
                }

                return _save;
            }
        }

        
        public ICommand UpdateCommand
        {
            get
            {
                if (_update == null)
                {
                    _update = new RelayCommand(x =>
                    {
                       
                        var s = _peoples.FirstOrDefault(h => h.Name == SelectedPeople.Name
                                                            && h.Surname == SelectedPeople.Surname);
                        if (s != null)
                        {
                            s.Name = NName;
                            s.Surname = NSecondName;
                        }
                        Peoples?.Refresh();
                        Notify(nameof(SelectedPeople));
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

   public RelayCommand AddCom
   {
       get
       {
           return _add ?? (_add = new RelayCommand(obj =>
           {
               People hum = new People(NName,NSecondName);
               _peoples.Insert(0, hum);
               SelectedPeople = hum;
               
               
           }));
       }
   }
   public RelayCommand LangCom
   {
       get
       {
           return _translate ?? (_translate = new RelayCommand(obj =>
           {
               if (_langState == false)
               {
                   CultureManager.UICulture = new CultureInfo("ru-RU");
                   _langState = true;
               }
               else
               {
                   CultureManager.UICulture = new CultureInfo("en-US");
                   _langState = false;
               }
           }));
       }
   }


        public ICommand RemoveCom =>
            _remove ?? (_remove = new RelayCommand(human =>
            {
                _peoples.Remove(SelectedPeople);
            }, (human) => _peoples.Count != 0));

  

        public ICollectionView Peoples { get; set; }

        public MainViewModel()
        {
            _peoples = new ObservableCollection<People>()
            {
                new People("Alejik","Ochen hochy sdat ety domashky"),
                
            };
            /*_peopleCollection = new PeopleCollection();
            _peopleCollection = (PeopleCollection)DeserealizeJSON(typeof(PeopleCollection), "Peoples.json");
            _peoples.Clear();
            _peoples = _peopleCollection.peoples;*/
            Peoples = CollectionViewSource.GetDefaultView(_peoples);
        }
    }
}