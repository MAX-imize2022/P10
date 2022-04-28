using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using EmotionAidProject.ActivityFolder;
using EmotionAidProject.Model;
using System.Collections.Generic;

namespace EmotionAidProject.Helpers
{
    class TrainingAdapter : BaseAdapter<TraningData>
    {

        private readonly Context context;
        private readonly List<TraningData> trainLst;

        public TrainingAdapter(Context context,List<TraningData> trainLst)
        {
            this.context = context;
            this.trainLst = trainLst;
        }
        public List<TraningData> GetList()
        {
            return this.trainLst;
        }


        public override Java.Lang.Object GetItem(int position)
        {
            return position;
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            LayoutInflater layoutInflater = ((ShowTraining)context).LayoutInflater;
            View view = layoutInflater.Inflate(Resource.Layout.TrainRow, parent, false);
            TextView tvDate = view.FindViewById<TextView>(Resource.Id.tvDate);
            TextView tvBefore = view.FindViewById<TextView>(Resource.Id.tvBefore);
            TextView tvAfter = view.FindViewById<TextView>(Resource.Id.tvAfter);
            TraningData currentTrain = trainLst[position];
            if (currentTrain != null)
            {
                tvDate.Text = "" + currentTrain.Tdate;
                tvBefore.Text = currentTrain.PressureB.ToString();
                tvAfter.Text = currentTrain.PressureA.ToString();
            }

            return view;
        }



        //Fill in cound here, currently 0
        public override int Count
        {
            get
            {
                return this.trainLst.Count;
            }
        }

        public override TraningData this[int position]
        {
            get { return this.trainLst[position]; }
        }
    }

    class TrainingAdapterViewHolder : Java.Lang.Object
    {
        //Your adapter views to re-use
        //public TextView Title { get; set; }
    }
}

//getlist
//override