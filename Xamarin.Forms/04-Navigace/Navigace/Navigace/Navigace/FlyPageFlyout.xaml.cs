using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Navigace
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FlyPageFlyout : ContentPage
    {
        public ListView ListView;

        public FlyPageFlyout()
        {
            InitializeComponent();

            BindingContext = new FlyPageFlyoutViewModel();
            ListView = MenuItemsListView;
        }

        private class FlyPageFlyoutViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<FlyPageFlyoutMenuItem> MenuItems { get; set; }

            public FlyPageFlyoutViewModel()
            {
                MenuItems = new ObservableCollection<FlyPageFlyoutMenuItem>(new[]
                {
                    new FlyPageFlyoutMenuItem { Id = 0, Title = "Stránka 1" },
                    new FlyPageFlyoutMenuItem { Id = 1, Title = "Stránka 2" },
                    new FlyPageFlyoutMenuItem { Id = 2, Title = "Stránka 3", TargetType = typeof(Zalozky) },
                    new FlyPageFlyoutMenuItem { Id = 3, Title = "Stránka 4" },
                    new FlyPageFlyoutMenuItem { Id = 4, Title = "Stránka 5" },
                });
            }

            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}