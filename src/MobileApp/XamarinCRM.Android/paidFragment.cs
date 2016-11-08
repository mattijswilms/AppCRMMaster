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

namespace XamarinCRMAndroid
{
    [Activity(Label = "paid")]
    public class paidFragment : Android.Support.V4.App.Fragment
    {
        string[] items;
        View view;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            /*  TextView textview = new TextView(this);
              textview.Text = "This is the My paid tab";
              SetContentView(textview); */

            //    items = new string[] { "saumya", "jay", "srushti", "shaurya" };
            //   ListAdapter = new ArrayAdapter<String>(this, Android.Resource.Layout.SimpleListItem1, items);
        }

        /*  protected override void OnListItemClick(ListView l, View v, int position, long id)
          {
              var t = items[position];
              Android.Widget.Toast.MakeText(this, t, Android.Widget.ToastLength.Short).Show();
          }  */


        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment 
            view = inflater.Inflate(Resource.Layout.PaidFragmentLayout, container, false);
            return view;
        }
    }
}