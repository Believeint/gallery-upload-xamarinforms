using Plugin.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinFormsGallery.Helpers;
using XamarinFormsGallery.Models;

namespace XamarinFormsGallery
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UploadPage : ContentPage
    {
        string _filePath;
        public UploadPage()
        {
            InitializeComponent();
            Title = "ImageGallery";
            DateTimeEntry.Text = DateTime.Now.ToString();
            UploadButton.Clicked += async delegate
            {
                if (string.IsNullOrEmpty(TittleEntry.Text))
                {
                    await DisplayAlert("ImageGallery", "Titulo Obrigatório", "OK");
                    return;
                }

                var gallery = new GalleryClass
                {
                    Title = TittleEntry.Text,
                    Path = _filePath,
                    Created = DateTime.Now
                };

                Constants.GalleryCollection.Add(gallery);
                await Application.Current.MainPage.Navigation.PopAsync();
            };
            BrowseButton.Clicked += delegate
            {
                PickImage();
            };

        }

        async void PickImage()
        {
            if(!CrossMedia.Current.IsPickPhotoSupported)
            {
                await DisplayAlert("ImageGallery", "Necessita de Permissão", "Ok");
                return;
            }
            var file = await CrossMedia.Current.PickPhotoAsync(new Plugin.Media.Abstractions.PickMediaOptions
            {
                PhotoSize = Plugin.Media.Abstractions.PhotoSize.Medium
            });
            if (file == null)
                return;
            image.Source = file.Path;
            _filePath = file.Path;
        }
    }
}