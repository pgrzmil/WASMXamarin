using System;

using Android.App;
using Android.OS;

namespace WASMXamarin.Droid
{
    [Activity(Label = "LayoutActivity")]
    public class LayoutActivity : ListActivity
    {
        static String[] MOBILE_OS = new String[] { "Android", "iOS", "WindowsMobile", "Blackberry", "Android"};
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            ListAdapter = new MobileArrayAdapter(this, MOBILE_OS);
        }
    }
}