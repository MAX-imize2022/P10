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
    [Activity(Label = "ExerciseLevel4")]
    public class ExerciseLevel4 : Activity,Android.Views.View.IOnClickListener
    {
        Button btnExricise4;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ExerciseLevel4Layout);
            InitViews();

            // Create your application here
        }

        private void InitViews()
        {
            btnExricise4 = FindViewById<Button>(Resource.Id.btnExricise4);
            btnExricise4.SetOnClickListener(this);
        }
        public void OnClick(View v)
        {
            if (v == btnExricise4)
            {
                Intent intent = new Intent(this, typeof(ExplainLevel5));
                StartActivity(intent);
            }
        }
    }
}