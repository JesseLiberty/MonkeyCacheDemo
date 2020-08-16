using System.ComponentModel;
using Xamarin.Forms;
using MonkeyCacheDemo.ViewModels;

namespace MonkeyCacheDemo.Views
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