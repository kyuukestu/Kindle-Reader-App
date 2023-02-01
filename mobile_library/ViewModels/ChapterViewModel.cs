using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace mobile_library.ViewModels
{
    public class ChapterViewModel : BaseViewModel
    {

        public Command UploadCommand { get; set; }

        public ChapterViewModel()
        {
            UploadCommand = new Command(async () => await UploadCommandAsync());
        }

        private Task UploadCommandAsync()
        {
            throw new NotImplementedException();
        }
    }
}
