
using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V7.App;
using Android.Widget;

namespace DavidZambranaIntent.Views
{
    [Activity(Label = "Mensaje")]
    public class MessageActivity : AppCompatActivity
    {
        private ImageButton shareButton;
        private EditText messageField;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_message);

            shareButton = FindViewById<ImageButton>(Resource.Id.shareButton);
            messageField = FindViewById<EditText>(Resource.Id.messageField);

            shareButton.Click += ShareButton_Click;   
        }

        private void ShareButton_Click(object sender, System.EventArgs e)
        {
            string text = messageField.Text.Trim();

            if (!string.IsNullOrEmpty(text))
            {
                Intent intent = new Intent(Intent.ActionSend);
                intent.SetType("text/plain");
                intent.PutExtra(Intent.ExtraText, text);

                StartActivity(Intent.CreateChooser(intent, "Compartir Texto"));
            }
            else
            {
                Toast.MakeText(this, "El campo no puede estar vacío", ToastLength.Short).Show();
            }
        }
    }
}