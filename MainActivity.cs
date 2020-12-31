using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Custom_Communiations;
namespace Raffle_Andriod
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            UDP udp = new UDP();
            Enthernet e = new Enthernet();
            udp.UDP_Open(e.GetLocalIp(),11066);

            Button start = FindViewById<Button>(Resource.Id.start);
            start.Click += (sender, e) =>
            {
                udp.UDP_Write("start", "255.255.255.255", 11066);//向UDP发送“start”
            };
            Button stop = FindViewById<Button>(Resource.Id.stop);
            stop.Click += (sender, e) =>
            {
                udp.UDP_Write("stop", "255.255.255.255", 11066); //向UDP发送“stop”
            };
            Button restart = FindViewById<Button>(Resource.Id.restart);
            restart.Click += (sender, e) =>
            {
                udp.UDP_Write("restart", "255.255.255.255", 11066);//向UDP发送“restart”
            };
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}