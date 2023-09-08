using LogBook.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace LogBook.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}