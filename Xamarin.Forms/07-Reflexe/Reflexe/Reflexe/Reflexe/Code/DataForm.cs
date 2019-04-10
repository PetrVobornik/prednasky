using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Xamarin.Forms;

namespace Reflexe
{
    public class DataForm : StackLayout
    {
        public async void SetData(IData record)
        {
            var typ = record.GetType();

            foreach (var prop in typ.GetProperties())
            {
                if (prop.IsDefined(typeof(SkrytVeFormuAttribute))) continue;

                View editor = null;
                if (prop.PropertyType == typeof(int?) && prop.IsDefined(typeof(ReferenceAttribute)))
                {
                    editor = new LookupPicker() {
                        ItemsSource = await DbUtils.DataTabulky(prop.GetCustomAttribute<ReferenceAttribute>().Table) as IList
                    };
                    editor.SetBinding(LookupPicker.IDProperty, prop.Name);
                }
                else if (prop.PropertyType == typeof(string))
                {
                    editor = new Entry();
                    editor.SetBinding(Entry.TextProperty, prop.Name);
                }
                else if (prop.PropertyType == typeof(int))
                {
                    editor = new Entry() { Keyboard = Keyboard.Numeric };
                    editor.SetBinding(Entry.TextProperty, prop.Name);
                }
                else if (prop.PropertyType == typeof(DateTime))
                {
                    editor = new DatePicker() { HorizontalOptions = LayoutOptions.Start };
                    editor.SetBinding(DatePicker.DateProperty, prop.Name);
                }

                if (editor != null)
                {
                    Children.Add(new Label() { Text = DbUtils.Popisek(prop) });
                    editor.Margin = new Thickness(0, 2, 0, 10);
                    Children.Add(editor);
                }
            }
            BindingContext = record;
        }

        public IData GetData() => BindingContext as IData;
    }
}
