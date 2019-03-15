using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Foundation;
using NavBarBackImage;
using NavBarBackImage.iOS;
using UIKit;
using Xamarin.Forms;

[assembly: ExportRenderer(typeof(CustomNavigationPage), typeof(NavigationPageRendereriOS))]
namespace NavBarBackImage.iOS
{
    public class NavigationPageRendereriOS : Xamarin.Forms.Platform.iOS.NavigationRenderer
    {
        private readonly Stack<NavigationPage> _navigationPageStack = new Stack<NavigationPage>();
        private NavigationPage CurrentNavigationPage => _navigationPageStack.Peek();

        public NavigationPageRendereriOS() : base()
        {
            
        }

        protected override Task<bool> OnPushAsync(Page page, bool animated)
        {
            var retVal = base.OnPushAsync(page, animated);

            SetBackButtonOnPage(page);

            return retVal;
        }

        protected override Task<bool> OnPopViewAsync(Page page, bool animated)
        {
            var retVal = base.OnPopViewAsync(page, animated);

            var stack = page.Navigation.NavigationStack;

            var returnPage = stack[stack.Count - 2];

            if (returnPage != null)
            {
                SetBackButtonOnPage(returnPage);
            }

            return retVal;
        }

        void SetBackButtonOnPage(Page page)
        {
            if (page is INavigationActionBarConfig incomingPage)
            {
                SetImageTitleBackButton("Down", "返回", -15);
            }
            else
            {
                SetDefaultBackButton();
            }
        }

        void SetImageTitleBackButton(string imageBundleName, string buttonTitle, int horizontalOffset)
        {
            var topVC = this.TopViewController;

            // Create the image back button
            var backButtonImage = new UIBarButtonItem(
                    UIImage.FromBundle(imageBundleName),
                    UIBarButtonItemStyle.Plain,
                    (sender, args) =>
                    { 
                        topVC.NavigationController.PopViewController(true);
                    });

            // Create the Text Back Button
            var backButtonText = new UIBarButtonItem(
                buttonTitle,
                UIBarButtonItemStyle.Plain,
                (sender, args) =>
                {
                    topVC.NavigationController.PopViewController(true);
                });

            backButtonText.SetTitlePositionAdjustment(new UIOffset(horizontalOffset, 0), UIBarMetrics.Default);

            // Add buttons to the Top Bar
            UIBarButtonItem[] buttons = new UIBarButtonItem[2];
            buttons[0] = backButtonImage;
            buttons[1] = backButtonText;

            topVC.NavigationItem.LeftBarButtonItems = buttons;
        }

        void SetDefaultBackButton()
        {
            this.TopViewController.NavigationItem.LeftBarButtonItems = null;
        }
    }
}