using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using XamarinFormsGallery.Helpers;
using XamarinFormsGallery.Models;

namespace XamarinFormsGallery.ViewModels
{
    public class ImageGalleryViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<GalleryClass> GalleryCollection;
        private int _maxColumns;
        private ObservableCollection<GalleryClass> _parentModels;
        private float _titleHeight;

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged([CallerMemberName] string propertyname = null)
        {
            if(PropertyChanged != null)
            {
                if(!string.IsNullOrEmpty(propertyname))
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
                }
            }
        }

        public ImageGalleryViewModel()
        {
            _parentModels = new ObservableCollection<GalleryClass>();
            ParentModels = new ObservableCollection<GalleryClass>();
            ItemTapCommand = new Command<GalleryClass>(OnParentTapped);
            MaxColumns = 2;
            TitleHeight = 100;
        }

        public ICommand ItemTapCommand { get; set; }

        public int MaxColumns
        {
            get { return _maxColumns; }
            set { _maxColumns = value; RaisePropertyChanged(); }
        }

        public ObservableCollection<GalleryClass> ParentModels
        {
            get { return _parentModels; }
            set { _parentModels = value; RaisePropertyChanged(); }
        }

        public float TitleHeight
        {
            get { return _titleHeight; }
            set { _titleHeight = value; RaisePropertyChanged(); }
        }

        internal void LoadData()
        {
            if(Constants.GalleryCollection != null)
            {
                ParentModels = Constants.GalleryCollection;
            }
        }
        private void OnParentTapped(GalleryClass item)
        {
            Application.Current.MainPage.DisplayAlert("ImageGallery", "Selected" + item.Title, "Ok");
        }
    }
}
