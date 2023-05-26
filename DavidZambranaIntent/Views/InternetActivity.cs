
using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Webkit;
using Android.Widget;
using System;
using System.Text;
using System.Text.RegularExpressions;

namespace DavidZambranaIntent.Views
{
    [Activity(Label = "Internet")]
    public class InternetActivity : AppCompatActivity
    {
        private ImageButton searchButton;
        private EditText searchInput;
        private WebView webView;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_browser);

            searchInput = FindViewById<EditText>(Resource.Id.searchInput);
            searchButton = FindViewById<ImageButton>(Resource.Id.searchButton);
            webView = FindViewById<WebView>(Resource.Id.embeddedBrowser);

            // Configuración del WebView
            webView.SetWebViewClient(new WebViewClient());
            webView.Settings.JavaScriptEnabled = true;


            searchButton.Click += SearchButton_Click;
        }

        private void SearchButton_Click(object sender, System.EventArgs e)
        {
            string pattern = @"^(https?://)?([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?$";
            Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);;

            string input = searchInput.Text.Trim();
            // Validar la URL
            bool isValidUrl = regex.IsMatch(input);

            if (!isValidUrl)
            {
                input = input.Insert(0, $"https://www.google.com/search?q=");
            }

            webView.LoadUrl(input);
        }
    }
}