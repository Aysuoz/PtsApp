using System.Collections.ObjectModel;
using System.Windows.Input;
using System;
using Xamarin.Forms;

namespace PersonelTakip
{
    public class ListPageViewModel : BindableObject
    {
        private ObservableCollection<OffersModel> _CollectionsList;
        public ObservableCollection<OffersModel> CollectionsList
        {
            get { return _CollectionsList; }
            set
            {
                _CollectionsList = value;
                OnPropertyChanged();
            }
        }

        private void OnPropertyChanged()
        {
            throw new NotImplementedException();
        }

        public ICommand DeleteCommand { get; }

        public ICommand AddCommand { get; }

        public ListPageViewModel()
        {
            _CollectionsList = new ObservableCollection<OffersModel>()
            {
                new OffersModel { Name = "1. İş" },
                new OffersModel { Name = "2. İş" },

            };

            DeleteCommand = new Command(OnDeleteTapped);

            AddCommand = new Command(AddItems);
        }

        private void AddItems(object obj)
        {
            OffersModel offersModel = new OffersModel();
            offersModel.Name = ListPage.EntryValue;
            CollectionsList.Add(offersModel);
        }

        private void OnDeleteTapped(object obj)
        {
            var content = obj as OffersModel;
            CollectionsList.Remove(content);
        }
    }
}