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
    [Activity(Label = "ExerciseLevel5")]
    public class ExerciseLevel5 : Activity,Android.Views.View.IOnClickListener
    {
        Button btnExricise5;

       
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ExerciseLevel5Layout);
            InitViews();


        }

        private void InitViews()
        {
            btnExricise5 = FindViewById<Button>(Resource.Id.btnExricise5);
            btnExricise5.SetOnClickListener(this);

        }
        public void OnClick(View v)
        {
            if (v == btnExricise5)
            {
                Intent intent = new Intent(this, typeof(LastScale));
                StartActivity(intent);
            }

        }
    }
}