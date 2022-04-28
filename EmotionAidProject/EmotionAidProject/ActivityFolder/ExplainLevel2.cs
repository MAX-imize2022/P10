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
    [Activity(Label = "ExplainLevel2")]
    public class ExplainLevel2 : Activity,Android.Views.View.IOnClickListener
    {
        Button btnexplainlevel2;

        

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ExplainLevel2Layout);
            InitViews();
            // Create your application here
        }

        private void InitViews()
        {
            btnexplainlevel2 = FindViewById<Button>(Resource.Id.btnexplainlevel2);
            btnexplainlevel2.SetOnClickListener(this);
        }
        public void OnClick(View v)
        {
            if (v == btnexplainlevel2)
            {
                Intent intent = new Intent(this, typeof(ExerciseLevel2));
                StartActivity(intent);
            }
        }
    }
}