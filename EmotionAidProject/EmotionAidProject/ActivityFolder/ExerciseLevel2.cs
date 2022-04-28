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
    [Activity(Label = "ExerciseLevel2")]
    
    public class ExerciseLevel2 : Activity,Android.Views.View.IOnClickListener
    {
        Button btnExricise2;
       

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.ExerciseLevel2Layout);
            InitViews();

        }

        private void InitViews()
        {
            btnExricise2 = FindViewById<Button>(Resource.Id.btnExricise2);
            btnExricise2.SetOnClickListener(this);
        }
        public void OnClick(View v)
        {
            if (v == btnExricise2)
            {
                Intent intent = new Intent(this, typeof(ExplainLevel3));
                StartActivity(intent);
            }
        }
    }
}