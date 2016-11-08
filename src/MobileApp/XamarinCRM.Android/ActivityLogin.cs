
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Support.V7.App;
using Android.Support.V4.Widget;
using Android.Support.Design.Widget;
using Android.Support.V4.View;

namespace XamarinCRMAndroid
{
    [Activity(Label = "@string/app_name", MainLauncher = true)]
    public class ActivityLogin : AppCompatActivity
    {
        string[] items;

        DrawerLayout drawerLayout;
        NavigationView navigationView;
        TabLayout tabLayout;

        protected override void OnCreate(Bundle bundle)
        {
            // base.OnCreate(savedInstanceState);
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.layout_login);

            var toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            //Enable support action bar to display hamburger
            //SupportActionBar.SetHomeAsUpIndicator(Resource.Drawable.ic_menu);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);

            drawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            navigationView = FindViewById<NavigationView>(Resource.Id.nav_view);
            tabLayout = FindViewById<TabLayout>(Resource.Id.sliding_tabs);
            FnInitTabLayout();
            /*  tabLayout.AddTab(tabLayout.NewTab().SetText("Draft"));
              tabLayout.AddTab(tabLayout.NewTab().SetText("Paid"));
              tabLayout.AddTab(tabLayout.NewTab().SetText("UnPaid"));
              tabLayout.AddTab(tabLayout.NewTab().SetText("All")); */
            //tabLayout.setTabGravity(TabLayout.GRAVITY_FILL);
            navigationView.NavigationItemSelected += (sender, e) =>
            {
                e.MenuItem.SetChecked(true);
                //react to click here and swap fragments or navigate
                drawerLayout.CloseDrawers();
            };

            //  CreateTab(typeof(All), "All", "All");
            //   CreateTab(typeof(paid), "paid", "paid");
            //   CreateTab(typeof(unpaid), "unpaid", "unpaid");


            //  items = new string[] { "Vegetables", "Fruits", "Flower Buds", "Legumes", "Bulbs", "Tubers" };
            //    ListAdapter = new ArrayAdapter<String>(this, Android.Resource.Layout.SimpleListItem1, items);


        }

        void FnInitTabLayout()
        {
            // tabLayout.SetTabTextColors(Android.Graphics.Color.Aqua, Android.Graphics.Color.AntiqueWhite);
            //Fragment array
            var fragments = new Android.Support.V4.App.Fragment[]
            {

   new DraftsFragment(),
    new paidFragment(),
    new unpaidFragment(),
     new AllFragment(),
                };
            //Tab title array
            var titles = CharSequence.ArrayFromStringArray(new[] {

    "Draft",
    "Paid",
    "Unpaid",
  "All",
   });

            var viewPager = FindViewById<ViewPager>(Resource.Id.viewpager);
            //viewpager holding fragment array and tab title text
            viewPager.Adapter = new TabsFragmentPagerAdapter(SupportFragmentManager, fragments, titles);

            // Give the TabLayout the ViewPager 
            tabLayout.SetupWithViewPager(viewPager);
        }

        public void OnClick(IDialogInterface dialog, int which)
        {
            dialog.Dismiss();
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Android.Resource.Id.Home:
                    drawerLayout.OpenDrawer(Android.Support.V4.View.GravityCompat.Start);
                    return true;
            }
            return base.OnOptionsItemSelected(item);
        }



        /*  private void CreateTab(Type activityType, string tag, string label)
          {
              var intent = new Intent(this, activityType);
              intent.AddFlags(ActivityFlags.NewTask);

              var spec = TabHost.NewTabSpec(tag);
              //  var drawableIcon = Resources.GetDrawable(drawableId);
              spec.SetIndicator(label);
              spec.SetContent(intent);

              TabHost.AddTab(spec);
          }

        protected override void OnListItemClick(ListView l, View v, int position, long id)
          {
              var t = items[position];
              Android.Widget.Toast.MakeText(this, t, Android.Widget.ToastLength.Short).Show();
          }*/


        /*     public override bool OnCreateOptionsMenu(IMenu menu)
              {
                 MenuInflater.Inflate(Resource.Menu.options_menu, menu);
                 //return true;
                  return base.OnCreateOptionsMenu(menu); 
              }

              public override bool OnOptionsItemSelected(IMenuItem item)
              {
                  switch (item.ItemId)
                  {
                      case Resource.Id.action_settings:
                          //do something
                          return true;
                      case Resource.Id.action_settings1:
                          //do something
                          return true;
                  }
                  return base.OnOptionsItemSelected(item);
              } */


    }
}