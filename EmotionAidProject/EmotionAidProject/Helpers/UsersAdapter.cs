using Android.Content;
using Android.Views;
using Android.Widget;
using EmotionAidProject.ActivityFolder;
using EmotionAidProject.Model;
using System.Collections.Generic;

namespace EmotionAidProject.Helpers
{
    class UsersAdapter : BaseAdapter<UserData>
    {

        private readonly Context context;
        private readonly List<UserData> userLst;

        public UsersAdapter(Context context,List<UserData>userLst)
        {
            this.context = context;
            this.userLst = userLst;
        }

        public List<UserData> GetList()
        {
            return this.userLst;
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
            LayoutInflater layoutInflater = ((CreatUsers)context).LayoutInflater;
            View view = layoutInflater.Inflate(Resource.Layout.UserRow, parent, false);
            TextView tvName = view.FindViewById<TextView>(Resource.Id.tvName);
            TextView tvAge = view.FindViewById<TextView>(Resource.Id.tvAge);
            TextView tvCountry = view.FindViewById<TextView>(Resource.Id.tvCountry);
            UserData currentUser = userLst[position];
            if (currentUser != null)
            {
                tvName.Text = "" + currentUser.Name;
                tvAge.Text = currentUser.Age.ToString();
                tvCountry.Text = currentUser.Country;
            }

            return view;
        }

        //Fill in cound here, currently 0
        public override int Count
        {
            get
            {
                return this.userLst.Count;
            }
        }

        public override UserData this[int position]
        {
            get { return this.userLst[position]; }
        }
    }

    //class UsersAdapterViewHolder : Java.Lang.Object
    //{
    //    //Your adapter views to re-use
    //    //public TextView Title { get; set; }
    //}

    
}