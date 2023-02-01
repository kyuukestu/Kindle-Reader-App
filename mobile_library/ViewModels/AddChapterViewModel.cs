using System;
namespace mobile_library.ViewModels
{
    public class AddChapterViewModel : BaseViewModel
    {
        private string _SelectedBook;
        public string SelectedBook
        {
            set
            {
                _SelectedBook = value;
                OnPropertyChanged();
            }

            get
            {
                return _SelectedBook;
            }
        }

        public AddChapterViewModel(string bookID)
        {
            SelectedBook = bookID;
        }
    }
}
