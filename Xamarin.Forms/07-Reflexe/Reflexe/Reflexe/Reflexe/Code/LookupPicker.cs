using System.Reflection;
using System.Collections;
using Xamarin.Forms;

namespace Reflexe
{
    public class LookupPicker : Picker
    {
        private bool itemsSourceChanging = false;

        /// <summary>
        /// Name of the property where the key (ID) is stored and which will be get and set over <see cref="ID"/> property
        /// </summary>
        public string ItemIdProperty { get; set; } = "Id";

        #region ID

        public static readonly BindableProperty IDProperty = BindableProperty.Create("ID", typeof(int?),
            typeof(LookupPicker), null, defaultBindingMode: BindingMode.TwoWay, propertyChanged: IDChanged);

        private static void IDChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if ((int?)oldValue != (int?)newValue) // ID changed => change selected item
                ((LookupPicker)bindable).SetSelectedItemByID();
        }

        /// <summary>
        /// ID (bindable property) - key (with property name specified in <see cref="ItemIdProperty"/>) of selected item
        /// </summary>
        public int? ID
        {
            get { return (int?)GetValue(IDProperty); }
            set { if (ID != value) SetValue(IDProperty, value); }
        }

        #endregion

        public LookupPicker()
        {
            PropertyChanged += LookupPicker_PropertyChanged; // watch changes of selected item
        }

        public new IList ItemsSource
        {
            get { return base.ItemsSource; }
            set
            {
                itemsSourceChanging = true;  // lock detection of SelectedItem changes
                base.ItemsSource = value;    // it fires "SelectedItem=null" but this change must be ignored now
                itemsSourceChanging = false; // unlock detection of SelectedItem changes
                SetSelectedItemByID();       // set SelectedItem by value in ID property
            }
        }

        private void LookupPicker_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (itemsSourceChanging || ItemsSource == null) return; // lock or ItemsSource is not set = do not any changes

            if (e.PropertyName == nameof(SelectedItem))             // selected item changed => change ID
                ID = SelectedItem?.GetType().GetTypeInfo().GetProperty(ItemIdProperty).GetValue(SelectedItem) as int?;
        }

        private void SetSelectedItemByID()
        {
            if (ItemsSource == null || itemsSourceChanging) return; // lock or ItemsSource is not set = do not any changes

            if (ID != null && ItemsSource.Count > 0) // if is what to look for and where...
            {
                var prop = ItemsSource[0].GetType().GetTypeInfo().GetProperty(ItemIdProperty); // get info from of the key property from the first item
                foreach (var item in ItemsSource)    // search an item which key value equals ID
                {
                    if ((int?)prop.GetValue(item) == ID) // item with the key equal to ID value is found
                    {
                        if (SelectedItem != item)
                            SelectedItem = item;     // set this item as a selected item
                        return;                      // done
                    }
                }
            }
            SelectedItem = null;                     // ID is null or item with this key value is not in list => unselect item
        }

    }
}