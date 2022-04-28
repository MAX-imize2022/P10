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
    [Activity(Label = "FirstScale")]
    public class FirstScale : Activity,Android.Views.View.IOnClickListener, SeekBar.IOnSeekBarChangeListener
    {
        Button btnFirst;
        SeekBar sb1;
        ImageView iv1;
        int pressure;

        int[] bmp = new int[5] {Resource.Drawable.happy, Resource.Drawable.happy3, Resource.Drawable.boring1, Resource.Drawable.sad1, Resource.Drawable.sad3};

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.FirstScaleLayout);
            InitViews();
            // Create your application here
        }

        private void InitViews()
        {
            btnFirst = FindViewById<Button>(Resource.Id.btnFirst);
            btnFirst.SetOnClickListener(this);
            sb1 = FindViewById<SeekBar>(Resource.Id.sb1);
            sb1.SetOnSeekBarChangeListener(this);
            iv1 = FindViewById<ImageView>(Resource.Id.iv1);

        }

        public void OnClick(View v)
        {
            if (v == btnFirst)
            {
                Intent intent = new Intent(this, typeof(ExplainLevel1));
                StartActivity(intent);
            }
        }

        public void OnProgressChanged(SeekBar seekBar, int progress, bool fromUser)
        {
            pressure = progress/20;

        }

        public void OnStartTrackingTouch(SeekBar seekBar)
        {
            Toast.MakeText(this, "start = ",ToastLength.Short).Show();

        }

        public void OnStopTrackingTouch(SeekBar seekBar)
        {
            Toast.MakeText(this, "stop = ", ToastLength.Short).Show();

            if (pressure > 0 && pressure <=2 )
            {
               iv1.SetBackgroundResource(bmp[0]);
            }
            if (pressure>2 && pressure<= 4)
            {
                iv1.SetBackgroundResource(bmp[1]);
            }
            if (pressure < 4 && pressure <=6)
            {
                iv1.SetBackgroundResource(bmp[2]);
            }
            if (pressure>6 && pressure<=8)
            {
                iv1.SetBackgroundResource(bmp[3]);
            }
            if (pressure > 8 && pressure <= 10)
            {
                iv1.SetBackgroundResource(bmp[4]);
            }
            //switch (pressure)
            //{
            //    case <=2:
            //        iv1.SetBackgroundResource(bmp[0]);
            //        break;
            //    case (4):
            //        break;
            //    case (6):
            //        iv1.SetBackgroundResource(bmp[2]);
            //        break;
            //    case 8:
            //        iv1.SetBackgroundResource(bmp[3]);
            //        break;
            //    case 10:
            //        iv1.SetBackgroundResource(bmp[4]);
            //        break;

            //    default:
            //        iv1.SetBackgroundResource(bmp[0]);
            //        break;

            //}
        
        
        }
            
                
            
            
        


    }
}