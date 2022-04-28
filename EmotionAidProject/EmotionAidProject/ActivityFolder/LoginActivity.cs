using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using EmotionAidProject.Model;
using System;

namespace EmotionAidProject.ActivityFolder
{
    [Activity(Label = "LoginActivity")]
    public class LoginActivity : Activity
    {
        EditText etEmail;
        EditText etPassword;
        Button btnsavelogin;
        //ProgressDialog progressDialog;
        UserData user;
        string email, password;

        //public void OnClick(View v)
        //{
        //    if (v == btnsave)
        //    {
        //        Intent intent = new Intent(this, typeof(FirstScale));
        //        StartActivity(intent);
        //    }
        //}

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.LoginLayout);



            // Create your application here
            //btnsave = FindViewById<Button>(Resource.Id.btnsavelogin);
            //btnsave.SetOnClickListener(this);
            InitViews();
        }
        private void InitViews()
        {
            
            etEmail = FindViewById<EditText>(Resource.Id.etEmailLogin);
           etPassword = FindViewById<EditText>(Resource.Id.etPasswordLogin);
           btnsavelogin = (Button)this.FindViewById(Resource.Id.btnsavelogin);
            //btnsavelogin.Click += ButtonLoginEmailPassword_Click;
            btnsavelogin.Click += Btnsavelogin_Click;
            //progressDialog = new ProgressDialog(this);


        }

        private async void Btnsavelogin_Click(object sender, EventArgs e)
        {

            email = this.etEmail.Text;
            password = this.etPassword.Text;
            Toast.MakeText(this, email + password, ToastLength.Short).Show();
            if (email == "")
            {
                Toast.MakeText(this, "you should enter an Email", ToastLength.Short).Show();
                return;
            }
            Toast.MakeText(this, "after checking Email", ToastLength.Short).Show();
            if (password == "")
            {
                Toast.MakeText(this, "you should enter a password", ToastLength.Short).Show();
                return;
            }

            // this.ShowProgressDialogue("loggin.......");
            this.user = new UserData(email, password);

            if (await this.user.Login() == true)
            {
                Toast.MakeText(this, "succssed", ToastLength.Short).Show();
                // this.progressDialog.Dismiss();
                this.Finish();
            }
            else
            {
                Toast.MakeText(this, "login- not succssed", ToastLength.Short).Show();
            }
        }

      

        
        //void ShowProgressDialogue(string status)
        //{
        //    this.progressDialog = new ProgressDialog(this);
        //    progressDialog.SetCancelable(false);
        //    progressDialog.SetMessage(status);
        //    progressDialog.SetProgressStyle(ProgressDialogStyle.Spinner);
        //    progressDialog.Show();
        //}
    }
    }
       
    