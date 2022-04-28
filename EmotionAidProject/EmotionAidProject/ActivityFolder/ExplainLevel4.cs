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
    [Activity(Label = "ExplainLevel4")]
    public class ExplainLevel4 : Activity,Android.Views.View.IOnClickListener
    {
        Button btnexplain4;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.ExplainLevel4Layout);
            InitViews();


        }

        private void InitViews()
        {
            btnexplain4 = FindViewById<Button>(Resource.Id.btnexplain4);
            btnexplain4.SetOnClickListener(this);

        }
        public void OnClick(View v)
        {
            if (v == btnexplain4)
            {
                Intent intent = new Intent(this, typeof(ExerciseLevel4));
                StartActivity(intent);
            }

        }
    }
}