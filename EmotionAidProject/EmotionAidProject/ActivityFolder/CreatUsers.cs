using Android.App;
using Android.OS;
using Android.Widget;
using EmotionAidProject.Helpers;
using EmotionAidProject.Model;
using System;
using System.Collections.Generic;

namespace EmotionAidProject.ActivityFolder
{
    [Activity(Label = "CreatUsers")]
    public class CreatUsers : Activity
    {
        List<UserData> lstuser;
        ListView lvUser;
        UsersAdapter adpUser;
        UserData currentUser;
        SqlHelper sqlData;
        string userName, password, email, age, country;
        int passwordNum, ageNum;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.createUserLayout);
            InitViews();
            InitObjects();
            // Create your application here
            CreateUser();
            //ShowUser();
        }

        private void InitViews()
        {
            lvUser = FindViewById<ListView>(Resource.Id.lvUser);
             userName = Intent.GetStringExtra("UserName");
             password = Intent.GetStringExtra("Password");
             email = Intent.GetStringExtra("Email");
             age = Intent.GetStringExtra("Age");
             country = Intent.GetStringExtra("Country");
            ageNum = int.Parse(age);
            passwordNum = int.Parse(password);


        }


        private void InitObjects()
        {

            sqlData = new SqlHelper();
            ShowUser();
            currentUser = null;

        }

        private void ShowUser()
        {
            lstuser = sqlData.GetAllUsers();
            adpUser = new UsersAdapter(this, lstuser);
            lvUser.Adapter = adpUser;
            adpUser.NotifyDataSetChanged();
        }

        private void CreateUser()
        {
            currentUser = new UserData(password,ageNum,country,userName,email);
            sqlData.Insert(currentUser);
            
            Toast.MakeText(this, "User Saved", ToastLength.Short).Show();
            lstuser.Add(currentUser);
            adpUser.NotifyDataSetChanged();
            currentUser = null;
            ShowUser();
        }
    }
}