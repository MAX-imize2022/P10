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
    [Activity(Label = "ExerciseLevel3")]
    public class ExerciseLevel3 : Activity,Android.Views.View.IOnClickListener
    {
        Button btnExricise3;
      

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ExerciseLevel3Layout);
            InitViews();
            // Create your application here
        }

        private void InitViews()
        {
            btnExricise3 = FindViewById<Button>(Resource.Id.btnExricise3);
            btnExricise3.SetOnClickListener(this);
        }
        public void OnClick(View v)
        {
            if (v == btnExricise3)
            {
                Intent intent = new Intent(this, typeof(ExplainLevel4));
                StartActivity(intent);
            }
        }
    }
}