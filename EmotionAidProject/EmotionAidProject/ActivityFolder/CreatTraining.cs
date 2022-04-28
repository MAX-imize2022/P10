using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;
using EmotionAidProject.Helpers;
using EmotionAidProject.Model;
using System;
using System.Collections.Generic;

namespace EmotionAidProject.ActivityFolder
{
    [Activity(Label = "CreatTraining")]

    public class CreatTraining : Activity
    {
        //int userID, DateTime tdate, int traningNumber
        List<TraningData> lsttraining;
        ListView lvTrain; 
        EditText etCompany;
        TrainingAdapter adpTraining; 
        TraningData currentTrain; 
        View prevView = null; 
        SqlHelper sqlData; 


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            InitViews();
            InitObjects();

            CreateTrainging();
            ShowTrain();
        }

        private void InitObjects()
        {
            sqlData = new SqlHelper();
            ShowTrain();
        }

        private void InitViews()
        {
            lvTrain = FindViewById<ListView>(Resource.Id.lvTrain);

        }

        private void ShowTrain()
        {
            lsttraining = sqlData.GetAllTraining();
            adpTraining = new TrainingAdapter(this, lsttraining);
            lvTrain.Adapter = adpTraining;
            adpTraining.NotifyDataSetChanged();
        }

      
        private void CreateTrainging()
        {
            DateTime dt = DateTime.Now;
            currentTrain = new TraningData(1, dt,13);
            sqlData.InsertTrain(currentTrain);
            lsttraining.Add(currentTrain);
            adpTraining.NotifyDataSetChanged();


            
        }
    }
}

//Creat xml for this page and set only the listview of the activity main from shoes

//don't need : etComapny, oncreatoptionmenu, onoption,showcompanyactivity,showeditactivity, showaddactivity

// needs: onactivityresult -> creatTraining , showshoes, part of onactivityresults