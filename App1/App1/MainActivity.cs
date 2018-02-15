using Android.App;
using Android.Widget;
using Android.OS;
using Android.Renderscripts;
using Android.Views;

namespace App1
{
    [Activity(Label = "App1", MainLauncher = true)]
    public class MainActivity : Activity
    {
        private TextView txtNumber;
        private bool added = false;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            txtNumber = FindViewById<TextView>(Resource.Id.Number);

            var hello = new TextView(BaseContext);

            hello.Text = "wadafak";

            hello.Gravity = GravityFlags.Center;

            hello.set

            hello.LayoutParameters.Weight = 20f;

            FindViewById<Button>(Resource.Id.Increment).Click += (o, e) =>
            {
                txtNumber.Text = (int.Parse(txtNumber.Text) + 1).ToString();
                if (added)
                {
                    FindViewById<LinearLayout>(Resource.Id.main).RemoveView(hello); //AddView(hello); //LayoutParams(LayoutParams.Matchparent, LayoutParams.WrapContent));
                    added = false;
                }
            };

            FindViewById<Button>(Resource.Id.Decrement).Click += (o, e) =>
            {
                txtNumber.Text = (int.Parse(txtNumber.Text) - 1).ToString();
                if (!added)
                {
                    FindViewById<LinearLayout>(Resource.Id.main)
                        .AddView(hello); //LayoutParams(LayoutParams.Matchparent, LayoutParams.WrapContent));
                    added = true;
                }
            };

        }
    }
}

