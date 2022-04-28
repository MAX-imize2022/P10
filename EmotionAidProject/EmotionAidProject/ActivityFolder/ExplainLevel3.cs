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
    [Activity(Label = "ExplainLevel3")]
    public class ExplainLevel3 : Activity,Android.Views.View.IOnClickListener
    {
        Button btnExplain3;

        

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.ExplainLevel3Layout);
            InitViews();


        }

        private void InitViews()
        {
            btnExplain3 = FindViewById<Button>(Resource.Id.btnExplain3);
            btnExplain3.SetOnClickListener(this);

        }
        public void OnClick(View v)
        {
            if (v == btnExplain3)
            {
                Intent intent = new Intent(this, typeof(ExerciseLevel3));
                StartActivity(intent);
            }

        }
    }
}