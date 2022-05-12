using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using BLL.DTO;
using BLL.Services;

using UI.Inf;


namespace UI.ViewModel
{
    
    public class MainViewModel:NotifyPropertyChanged
    {
        #region Fields
        private ICommand _deleteCommandCategory;
        private ICommand _deleteCommandGood;
        private ICommand _deleteCommandManufacturer;
        private ICommand _changeGoodCommand;
        private ICommand _changeCategoryCommand;
        private ICommand _changeManufacturerCommand;
        private ICommand _addGoodCommand;
        private ICommand _addcategoryCommand;
        private ICommand _addManufacturerCommand;
        private ICommand _saveCommand;
        private ICommand _UpdateViewCommand;


        private CategoryService _categoryService;
        private GoodService _goodService;
        private ManufacturerService _manufacturerService;

        private ObservableCollection<CategoryDTO> _categories;
        private ObservableCollection<GoodDTO> _good;
        private ObservableCollection<ManufacturerDTO> _manufacturers;

        private CategoryDTO _selectedCategory;
        private GoodDTO _selectedGood;
        private ManufacturerDTO _selectedManufacturer;
       


        #endregion

        #region Commands and ObservableCollections

       

        public GoodDTO SelectedGood
        {
            get { return _selectedGood; }
            set
            {
                _selectedGood = value;
                NotifyOfPropertyChanged();
            }
        }

        public CategoryDTO SelectedCategory
        {
            get { return _selectedCategory; }
            set
            {
                _selectedCategory = value;
                NotifyOfPropertyChanged();
            }
        }

        public ManufacturerDTO SelectedManufacturer
        {
            get { return _selectedManufacturer; }
            set
            {
                _selectedManufacturer = value;
                NotifyOfPropertyChanged();
            }
        }

        public ObservableCollection<CategoryDTO> Category
        {
            get => _categories;
            set
            {
                _categories = value;
                NotifyOfPropertyChanged();
            }

        }
        public ObservableCollection<GoodDTO> Good
        {
            get => _good;
            set
            {
                _good = value;
                NotifyOfPropertyChanged();                
            }
        }
        public ObservableCollection<ManufacturerDTO> Maufacturer
        {
            get => _manufacturers;
            set
            {
                _manufacturers = value;
                NotifyOfPropertyChanged();
            }
        }

       
        public bool CanExecuteDeleteCategory()
        {
            
            return _goodService.CheckCategory(SelectedCategory.Id); ;
        }

        public bool CanExecuteDeleteManufacturer()
        {
            return _goodService.CheckManufacturer(SelectedManufacturer.Id);
        }
        
        public ICommand DeleteCommandGood
        {
            get
            {
                if (_deleteCommandGood == null)
                    _deleteCommandGood = new RelayCommand(param =>
                    {
                        _goodService.DeleteById((int)param);
                        _goodService.Save();
                        Good.Remove(Good.FirstOrDefault(x => x.Id == (int)param));
                    }, null);
                return _deleteCommandGood;
            }
        }

        public ICommand DeleteCommandCategory
        {
            get
            {
                if (_deleteCommandCategory == null)
                    _deleteCommandCategory = new RelayCommand(param =>
                    {
                        if (CanExecuteDeleteCategory())
                        {
                            MessageBox.Show("This Category has good in It", "Error");

                        }
                        else
                        {
                            _categoryService.DeleteById((int)param);
                            _categoryService.Save();
                            Category.Remove(Category.FirstOrDefault(x => x.Id == (int)param));
                        }
                        

                    },null );
                return _deleteCommandCategory;
            }
        }

        public ICommand DeleteCommandManufacturer
        {
            get
            {
                if (_deleteCommandManufacturer == null)
                    _deleteCommandManufacturer = new RelayCommand(param =>
                    {
                        if (CanExecuteDeleteManufacturer())
                        {
                            MessageBox.Show("This Manufacturer has good in It", "Error");


                        }
                        else
                        {
                            _manufacturerService.DeleteById((int)param);
                            _manufacturerService.Save();
                            Maufacturer.Remove(Maufacturer.FirstOrDefault(x => x.Id == (int)param));
                        }
                       
                    }, null);
                return _deleteCommandManufacturer;
            }
        }

  


        public ICommand UpdateViewCommand
        {
            get
            {
                if (_UpdateViewCommand == null)
                    _UpdateViewCommand = new RelayCommand(param =>UpdateView(), null);
                return _UpdateViewCommand;
            }
        }

       public ICommand ChangeGoodCommand
        {
            get
            {
                if (_changeGoodCommand == null)
                    _changeGoodCommand = new RelayCommand(param =>
                    {

                        _goodService.Update(SelectedGood);

                    }, null);
                return _changeGoodCommand;
            }
        }

       public ICommand ChangeCategoryCommand
       {
           get
           {
               if (_changeCategoryCommand == null)
                   _changeCategoryCommand =
                       new RelayCommand(param => { _categoryService.Update(SelectedCategory); }, null);
                return _changeCategoryCommand;
            }
       }

       public ICommand ChangeManufacturerCommand
       {
           get
           {
               if (_changeManufacturerCommand==null)
               {
                   _changeManufacturerCommand=
                       new RelayCommand(param => { _manufacturerService.Update(SelectedManufacturer); }, null);
                }

               return _changeManufacturerCommand;
           }
       }

       public ICommand AddGoodCommand
       {
           get
           {
               if (_addGoodCommand==null)
               {
                   _addGoodCommand =
                       new RelayCommand(param =>
                       {
                           var GoodDto = _goodService.Create(new GoodDTO() { Name = "ChangeME",Count = -1,Price = -1});
                           _good.Add(GoodDto);
                       }, null);
                }

               return _addGoodCommand;
           }
       }

       public ICommand AddCategoryCommand
       {
           get
           {
               if (_addcategoryCommand==null)
               {
                   _addcategoryCommand =
                       new RelayCommand(param =>
                       {
                           var categoryDto = _categoryService.Create(new CategoryDTO { Name = "ChangeME" });
                           _categories.Add(categoryDto);
                       }, null);

               }

               return _addcategoryCommand;
           }
       }

       public ICommand AddManufacturerCommand
       {
           get
           {
               if (_addManufacturerCommand==null)
               {
                   _addManufacturerCommand =
                       new RelayCommand(param =>
                       {
                           var ManufacturerDto = _manufacturerService.Create(new ManufacturerDTO { Name = "ChangeME" });
                           _manufacturers.Add(ManufacturerDto);
                       }, null);
                }
               return _addManufacturerCommand;
           }
       }






        #endregion


        public MainViewModel(CategoryService categoryService, GoodService goodService,
            ManufacturerService manufacturerService)
        {
            this._categoryService = categoryService;
            this._goodService = goodService;
            this._manufacturerService = manufacturerService;

            Category = new ObservableCollection<CategoryDTO>(_categoryService.GetAll());
            Good = new ObservableCollection<GoodDTO>(_goodService.GetAll());
            Maufacturer = new ObservableCollection<ManufacturerDTO>(_manufacturerService.GetAll());
        }

        /* public MainViewModel()
        {


            _categoryService = new CategoryService(new CategoryRepository(new ShopContext()));
            _goodService = new GoodService(new GoodRepository(new ShopContext()));
            _manufacturerService = new ManufacturerService(new ManufacturerRepository(new ShopContext()));


            Category = new ObservableCollection<CategoryDTO>(_categoryService.GetAll());
            Good = new ObservableCollection<GoodDTO>(_goodService.GetAll());
            Maufacturer = new ObservableCollection<ManufacturerDTO>(_manufacturerService.GetAll());

        }*/

            public void UpdateView()
        {
            Category = new ObservableCollection<CategoryDTO>(_categoryService.GetAll());
            Good = new ObservableCollection<GoodDTO>(_goodService.GetAll());
            Maufacturer = new ObservableCollection<ManufacturerDTO>(_manufacturerService.GetAll());
        }

       

    }
}

