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
    [Activity(Label = "ExplainLevel1")]
    public class ExplainLevel1 : Activity,Android.Views.View.IOnClickListener
    {
        Button btnfirstexplain;

      

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.ExplainLevel1Layout);
            InitViews();

            // Create your application here
        }

        private void InitViews()
        {
            btnfirstexplain = FindViewById<Button>(Resource.Id.btnfirstexplain);
            btnfirstexplain.SetOnClickListener(this);
        }
        public void OnClick(View v)
        {
            if (v == btnfirstexplain)
            {
                Intent intent = new Intent(this, typeof(ExerciseLevel1));
                StartActivity(intent);
            }

        }
    }
}