using Android.App;
using Android.Support.V4.App;
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

    [Activity(Label = "unpaid", MainLauncher = true, Icon="@drawable/icon")]
    public class unpaidFragment : Android.Support.V4.App.Fragment
    {

       string[] items;
        View view;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            /*   TextView textview = new TextView(this);
               textview.Text = "This is the unpaid tab";
               SetContentView(textview); */

            // items = new string[] { "Apple", "Mango", "Orange"};
            //  ListAdapter = new ArrayAdapter<String>(this, Android.Resource.Layout.SimpleListItem1, items);
        }

        /*  protected override void OnListItemClick(ListView l, View v, int position, long id)
          {
              var t = items[position];
              Android.Widget.Toast.MakeText(this, t, Android.Widget.ToastLength.Short).Show();
          }*/

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment 
            view = inflater.Inflate(Resource.Layout.UnpaidFragmentLayout, container, false);
            return view;
        }
    }
}