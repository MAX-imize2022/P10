using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EmotionAidProject.ActivityFolder
{
    [Activity(Label = "ExerciseLevel1")]
    public class ExerciseLevel1 : Activity, Android.Views.View.IOnClickListener
    { 
        Button btnFirstExricise;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ExerciseLevel1Layout);
            InitViews();
            // Create your application here
        }

        private void InitViews()
        {
            btnFirstExricise = FindViewById<Button>(Resource.Id.btnFirstExricise);
            btnFirstExricise.SetOnClickListener(this);
        }
        public void OnClick(View v)
        {
            if (v == btnFirstExricise)
            {
                Intent intent = new Intent(this, typeof(ExplainLevel2)); ;
                StartActivity(intent);
            }
        }
    }
}
