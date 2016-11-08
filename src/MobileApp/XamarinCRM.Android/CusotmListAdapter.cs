using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Java.Lang;
using System.Collections;

namespace XamarinCRMAndroid
{
    class CusotmListAdapter : BaseAdapter
    {

        Activity Context;
        public List<Post> post;

        public CusotmListAdapter(Activity context, List<Post> _list)
        {
            this.Context = context;
            post = _list;
        }


        public override int Count
        {
            get { return post.Count; }
        }

        public override Java.Lang.Object GetItem(int position)
        {
            throw new NotImplementedException();
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View view = convertView;

            // re-use an existing view, if one is available
            // otherwise create a new one
            if (view == null)
                view = Context.LayoutInflater.Inflate(Resource.Layout.ListItemRow, parent, false);

            Post item = post[position];
            view.FindViewById<TextView>(Resource.Id.textView1).Text = item.invoicdid;
            view.FindViewById<TextView>(Resource.Id.textView2).Text = item.name;
            view.FindViewById<TextView>(Resource.Id.textView3).Text = item.Phonenumber;
            view.FindViewById<TextView>(Resource.Id.textView4).Text = item.address;


            return view;


        }
    }
}