using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using NavBarBackImage.Droid.CustomRenderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using AppCompToolbar = Android.Support.V7.Widget.Toolbar;
using NavBarBackImage;

[assembly: ExportRenderer(typeof(CustomNavigationPage), typeof(NavigationPageRenderer))]
namespace NavBarBackImage.Droid.CustomRenderers
{
    public class NavigationPageRenderer : Xamarin.Forms.Platform.Android.AppCompat.NavigationPageRenderer
    {
        public AppCompToolbar toolbar;
        public Activity context;
        
        protected override Task<bool> OnPushAsync(Page view, bool animated)
        {
            var retVal = base.OnPushAsync(view, animated);

            context = (Activity)Forms.Context;
            toolbar = context.FindViewById<AppCompToolbar>(Droid.Resource.Id.toolbar);

            if (toolbar != null)
            {
                if (toolbar.NavigationIcon != null)
                {
                    toolbar.NavigationIcon = Android.Support.V7.Content.Res.AppCompatResources.GetDrawable(context, Resource.Drawable.back);
                    toolbar.Title = "返回";
                }
            }

            return retVal;
        }
    }
}