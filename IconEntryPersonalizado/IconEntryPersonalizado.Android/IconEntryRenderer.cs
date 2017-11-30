using System;
using Android.Runtime;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Path = System.IO.Path;
using IconEntryPersonalizado.Droid;

[assembly: ExportRenderer(typeof(IconEntry.FormsPlugin.Abstractions.IconEntry), typeof(IconEntryRenderer))]
namespace IconEntryPersonalizado.Droid
{
    [Preserve(AllMembers = true)]
    public class IconEntryRenderer : EntryRenderer
    {
        public async static void Init()
        {
            var temp = DateTime.Now;
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            var view = (IconEntry.FormsPlugin.Abstractions.IconEntry)Element;

            if (view != null)
            {
                SetIcon(view);
                Control.Background = this.Resources.GetDrawable(Resource.Drawable.RoundedCornerEntry);
                Control.SetPadding(10, 10, 10, 3);
            }
        }

        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            var view = (IconEntry.FormsPlugin.Abstractions.IconEntry)Element;
            if (e.PropertyName == IconEntry.FormsPlugin.Abstractions.IconEntry.IconProperty.PropertyName)
                SetIcon(view);
        }

        private void SetIcon(IconEntry.FormsPlugin.Abstractions.IconEntry view)
        {
            if (!string.IsNullOrEmpty(view.Icon))
            {
                try
                {
                    var context = Forms.Context;
                    var resId = context.Resources.GetIdentifier(Path.GetFileNameWithoutExtension(view.Icon), "drawable", context.PackageName);
                    if (resId != 0)
                        Control.SetCompoundDrawablesWithIntrinsicBounds(resId, 0, 0, 0);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                Control.SetCompoundDrawablesWithIntrinsicBounds(0, 0, 0, 0);
            }
        }
    }
}