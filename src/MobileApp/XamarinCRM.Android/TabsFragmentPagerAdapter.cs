using System;
using Android.Support.V4.App;
using Android.Support.V4.View;
using Java.Lang;

namespace XamarinCRMAndroid
{
    public class TabsFragmentPagerAdapter : FragmentPagerAdapter
    {
        private Fragment[] fragments;
        private FragmentManager supportFragmentManager;
        private ICharSequence[] titles;

        public TabsFragmentPagerAdapter(FragmentManager fm, Fragment[] fragments, ICharSequence[] titles) : base(fm)
        {
            this.fragments = fragments;
            this.titles = titles;
        }

        public override int Count
        {
            get
            {
                return fragments.Length;
            }
        }

        public override Fragment GetItem(int position)
        {
            // throw new NotImplementedException();
            return fragments[position];
        }

        public override ICharSequence GetPageTitleFormatted(int position)
        {
            return titles[position];
        }
    }
}