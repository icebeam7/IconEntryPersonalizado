using Xamarin.Forms;

namespace IconEntry.FormsPlugin.Abstractions
{
    public class IconEntry : Entry
    {
        public static readonly BindableProperty IconProperty = BindableProperty.Create(nameof(Icon), typeof(string), typeof(IconEntry), string.Empty);

        public string Icon
        {
            get => (string)GetValue(IconProperty);
            set => SetValue(IconProperty, value);
        }
    }
}