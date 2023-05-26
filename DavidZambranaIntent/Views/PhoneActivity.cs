
using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V7.App;
using Android.Widget;
using System;

namespace DavidZambranaIntent.Views
{
    [Activity(Label = "Teléfono")]
    public class PhoneActivity : AppCompatActivity
    {
        private TextView phoneNumber;
        private ImageButton callButton;
        private Button deleteButton;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_phone);

            phoneNumber = FindViewById<TextView>(Resource.Id.dial);
            callButton = FindViewById<ImageButton>(Resource.Id.callButton);
            deleteButton = FindViewById<Button>(Resource.Id.deleteButton);

            Button one = FindViewById<Button>(Resource.Id.one);
            Button two = FindViewById<Button>(Resource.Id.two);
            Button three = FindViewById<Button>(Resource.Id.three);
            Button four = FindViewById<Button>(Resource.Id.four);
            Button five = FindViewById<Button>(Resource.Id.five);
            Button six = FindViewById<Button>(Resource.Id.six);
            Button seven = FindViewById<Button>(Resource.Id.seven);
            Button eight = FindViewById<Button>(Resource.Id.eight);
            Button nine = FindViewById<Button>(Resource.Id.nine);
            Button zero = FindViewById<Button>(Resource.Id.zero);
            Button star = FindViewById<Button>(Resource.Id.star);
            Button sharp = FindViewById<Button>(Resource.Id.plus);

            callButton.Click += CallButton_Click;
            deleteButton.Click += DeleteButton_Click;

            one.Click += Add;
            two.Click += Add;
            three.Click += Add;
            four.Click += Add;
            five.Click += Add;
            six.Click += Add;
            seven.Click += Add;
            eight.Click += Add;
            nine.Click += Add;
            zero.Click += Add;
            star.Click += Add;
            sharp.Click += Add;

        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            string input = phoneNumber.Text;

            if (input.Length > 0)
            {
                input = input.Remove(input.Length - 1);
            }

            phoneNumber.Text = input;
        }

        private void CallButton_Click(object sender, EventArgs e)
        {
            string dial = phoneNumber.Text;

            if (dial.Length > 0)
            {
                var uri = Android.Net.Uri.Parse($"tel:{dial}");
                Intent intent = new Intent(Intent.ActionCall, uri);
                phoneNumber.Text = String.Empty;
                StartActivity(intent);
            }
            else
                Toast.MakeText(this, "El campo no puede estar vacío", ToastLength.Long).Show();

        }

        public void Add(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            phoneNumber.Text += button.Text;
        }
    }
}