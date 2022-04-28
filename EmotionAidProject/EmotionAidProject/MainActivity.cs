using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;
using EmotionAidProject.ActivityFolder;
using Android.Views;
using Android.Content;

namespace EmotionAidProject
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity, Android.Views.View.IOnClickListener
    {
        Button btnLogin, btnRegister, btnUpdate, btnDelete, btnSettings, btnList;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            InitView();
        }
        private void InitView()
        {
            btnLogin = FindViewById<Button>(Resource.Id.btnLogin);
            btnRegister = FindViewById<Button>(Resource.Id.btnRegister);
            btnUpdate = FindViewById<Button>(Resource.Id.btnUpdate);
            btnDelete = FindViewById<Button>(Resource.Id.btnDelete);
            btnSettings = FindViewById<Button>(Resource.Id.btnSettings);
            btnList = FindViewById<Button>(Resource.Id.btnList);

            btnLogin.SetOnClickListener(this);
            btnRegister.SetOnClickListener(this);
            btnUpdate.SetOnClickListener(this);
            btnDelete.SetOnClickListener(this);
            btnSettings.SetOnClickListener(this);
            btnList.SetOnClickListener(this);
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        public void OnClick(View v)
        {
            if (v==btnLogin)
            {
                Intent intent = new Intent(this, typeof(LoginActivity));
                StartActivity(intent);

            }
            else if (v == btnRegister)
            {
                Intent intent = new Intent(this, typeof(Register));
                StartActivity(intent);
            }

            else if(v==btnDelete)
            {
                Intent intent = new Intent(this, typeof(DelteActivity));
                StartActivity(intent);
            }
            else if (v == btnList)
            {
                Intent intent = new Intent(this, typeof(ShowUsers));
                StartActivity(intent);
            }
            else if (v==btnSettings)
            {
                Intent intent = new Intent(this, typeof(SettingsActivity));
                StartActivity(intent);
            }
            else if (v==btnUpdate)
            {
                Intent intent = new Intent(this, typeof(UpdateActivity));
                StartActivity(intent);
            }
        }
    }
}