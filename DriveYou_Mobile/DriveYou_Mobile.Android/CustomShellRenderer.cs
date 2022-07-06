using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using DriveYou_Mobile;
using DriveYou_Mobile.Droid;
using Google.Android.Material.BottomNavigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;


using Android.Support.Design.BottomNavigation;
using Android.Support.Design.Widget;
using System.ComponentModel;

[assembly: ExportRenderer(typeof(AppShell), typeof(CustomShellRenderer))]
namespace DriveYou_Mobile.Droid
{
    public class CustomShellRenderer : ShellRenderer
    {
        Android.Support.Design.Widget.BottomNavigationView _bottomView;
        public CustomShellRenderer(Context context) : base(context)
        {
            
        }
        protected override IShellItemRenderer CreateShellItemRenderer(ShellItem shellItem)
        {
            return new AndroidShellItemRenderer(this);
        }
    }


    public class AndroidShellItemRenderer : ShellItemRenderer
    {
        Android.Support.Design.Widget.BottomNavigationView _bottomView;

        public AndroidShellItemRenderer(IShellContext shellContext) : base(shellContext)
        {
        }

        public override Android.Views.View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var outerlayout = base.OnCreateView(inflater, container, savedInstanceState);

            _bottomView = outerlayout.FindViewById<Android.Support.Design.Widget.BottomNavigationView>(Resource.Id.bottomtab_tabbar);
            _bottomView.LabelVisibilityMode = Android.Support.Design.BottomNavigation.LabelVisibilityMode.LabelVisibilityUnlabeled;

            return outerlayout;
        }
    }
}