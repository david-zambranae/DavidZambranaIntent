using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Widget;
using Android.Content;

namespace DavidZambranaIntent.Views
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        // 
        private Button calculatorMenuButton;
        private Button internetMenuButton;
        private Button messageMenuButton;
        private Button phoneMenuButton;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            // Referencias a los elementos de UI
            calculatorMenuButton = FindViewById<Button>(Resource.Id.calculatorMenuButton);
            messageMenuButton = FindViewById<Button>(Resource.Id.messageMenuButton);
            internetMenuButton = FindViewById<Button>(Resource.Id.internetMenuButton);
            phoneMenuButton = FindViewById<Button>(Resource.Id.phoneMenuButton);


            // Eventos - CLICK
            calculatorMenuButton.Click += CalculatorMenuButton_Click;
            internetMenuButton.Click += InternetMenuButton_Click;
            messageMenuButton.Click += MessageMenuButton_Click;
            phoneMenuButton.Click += PhoneMenuButton_Click;
        }

        private void PhoneMenuButton_Click(object sender, System.EventArgs e)
        {
            Intent intent = new Intent(this, typeof(PhoneActivity));
            StartActivity(intent);
        }

        private void MessageMenuButton_Click(object sender, System.EventArgs e)
        {
            Intent intent = new Intent(this, typeof(MessageActivity));
            StartActivity(intent);
        }

        private void InternetMenuButton_Click(object sender, System.EventArgs e)
        {
            Intent intent = new Intent(this, typeof(InternetActivity));
            StartActivity(intent);
        }

        private void CalculatorMenuButton_Click(object sender, System.EventArgs e)
        {
            Intent intent = new Intent(this, typeof(CalculatorActivity));
            StartActivity(intent);
        }
    }
}