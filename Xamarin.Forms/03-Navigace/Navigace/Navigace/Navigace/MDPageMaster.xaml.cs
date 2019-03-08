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
    public partial class MDPageMaster : ContentPage
    {
        public ListView ListView;

        public MDPageMaster()
        {
            InitializeComponent();

            BindingContext = new MDPageMasterViewModel();
            ListView = MenuItemsListView;
        }

        class MDPageMasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<MDPageMenuItem> MenuItems { get; set; }
            
            public MDPageMasterViewModel()
            {
                MenuItems = new ObservableCollection<MDPageMenuItem>(new[]
                {
                    new MDPageMenuItem { Id = 0, Title = "Stránka 1" },
                    new MDPageMenuItem { Id = 1, Title = "Stránka 2" },
                    new MDPageMenuItem { Id = 2, Title = "Stránka 3", TargetType = typeof(Zalozky) },
                    new MDPageMenuItem { Id = 3, Title = "Stránka 4" },
                    new MDPageMenuItem { Id = 4, Title = "Stránka 5" },
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