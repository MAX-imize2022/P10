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
    [Activity(Label = "ExplainLevel5")]
    public class ExplainLevel5 : Activity,Android.Views.View.IOnClickListener
    {
        Button btnExplain5;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.ExplainLevel5Layout);
            InitViews();


        }

        private void InitViews()
        {
            btnExplain5 = FindViewById<Button>(Resource.Id.btnExplain5);
            btnExplain5.SetOnClickListener(this);

        }
        public void OnClick(View v)
        {
            if (v == btnExplain5)
            {
                Intent intent = new Intent(this, typeof(ExerciseLevel5));
                StartActivity(intent);
            }

        }
    }
}