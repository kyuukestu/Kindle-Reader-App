using System;
using System.Threading.Tasks;
using mobile_library.Models;
using mobile_library.ViewsPages;
using Xamarin.Forms;

namespace mobile_library.ViewModels
{
    public class ReadingViewModel : BaseViewModel
    {
        private Chapter _SelectedChapter;
        public Chapter SelectedChapter
        {
            set
            {
                _SelectedChapter = value;
                OnPropertyChanged();
            }

            get
            {
                return _SelectedChapter;
            }
        }

        public Command HomeCommand { get; set; }


        public ReadingViewModel()
        { }

        public ReadingViewModel(Chapter chapter)
        {
            SelectedChapter = chapter;
            HomeCommand = new Command(async () => await GoHomeAsync());
        }

        protected async Task GoHomeAsync()
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(new MainTabbedView());
        }
    }
}
