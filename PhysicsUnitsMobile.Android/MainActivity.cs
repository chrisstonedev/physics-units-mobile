using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Xamarin.Forms.Platform.Android;

namespace PhysicsUnitsMobile.Droid
{
    [Activity(Label = "Physics", Icon = "@mipmap/icon", RoundIcon = "@mipmap/icon_round", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : FormsAppCompatActivity, IKeyboardListener
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        public override bool OnKeyUp(Keycode keyCode, KeyEvent e)
        {
            Xamarin.Forms.MessagingCenter.Send<IKeyboardListener, string>(this, "KeyboardListener", keyCode.ToString());
            return base.OnKeyUp(keyCode, e);
        }
    }
}