using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Navigace
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Zalozky : TabbedPage
    {
        public Zalozky ()
        {
            InitializeComponent();
        }
    }
}