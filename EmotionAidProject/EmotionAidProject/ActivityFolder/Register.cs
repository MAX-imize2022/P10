using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using EmotionAidProject.ActivityFolder;
using EmotionAidProject.Helpers;
using EmotionAidProject.Model;
using Firebase.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EmotionAidProject
{
    [Activity(Label = "Register")]
    public class Register : Activity, Android.Views.View.IOnClickListener
    {
        Button btnsave;
        EditText etName, etPassword, etMail, etAge, etCountry;

        FirebaseAuth firebaseAuth;
        UserData user;
        Button save;
        ProgressDialog progressDialog;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.RegisterLayout);
            InitViews();
            //  string[] countries = get().getStringArray(Resource.Layout.RegisterLayout);
            AutoCompleteTextView textView= FindViewById<AutoCompleteTextView>(Resource.Id.etCountry);
            var adapter = new ArrayAdapter<String>(this, Resource.Layout.AutoComp, COUNTRIES);
            textView.Adapter = adapter;

        }
       

        private void InitViews()
        {

            btnsave = FindViewById<Button>(Resource.Id.btnsave);
            etName = FindViewById<EditText>(Resource.Id.etName);
            etPassword = FindViewById<EditText>(Resource.Id.etPassword);
            etMail = FindViewById<EditText>(Resource.Id.etMail);
            etAge = FindViewById<EditText>(Resource.Id.etAge);
            etCountry = FindViewById<AutoCompleteTextView>(Resource.Id.etCountry);
            //btnsave.SetOnClickListener(this);
             btnsave.Click += Btnsave_Click;
            
            //btnsave.Click += Btn_save_Click;
        }
      


        public void OnClick(View v)
        {
            if (v == btnsave)
            {
                Intent intent = new Intent(this, typeof(CreatUsers));
                intent.PutExtra("UserName", etName.Text);
                intent.PutExtra("Password", etPassword.Text);
                intent.PutExtra("Email", etMail.Text);
                intent.PutExtra("Age", etAge.Text);
                intent.PutExtra("Country", etCountry.Text);

                StartActivity(intent);
            }
           
        }
        private async void Btnsave_Click(object sender, EventArgs e)
        {
            string username = this.etName.Text;
            if (username == "")
            {
                Toast.MakeText(this, "you should enter your name", ToastLength.Short).Show();
                return;
            }
            string email = this.etMail.Text;
            if (email == "")
            {
                Toast.MakeText(this, "you should enter your email", ToastLength.Short).Show();
                return;
            }
            string password = this.etPassword.Text;
            if (password == "")
            {
                Toast.MakeText(this, "you should enter your password", ToastLength.Short).Show();
                return;
            }

            string age = this.etAge.Text;
            int age1 = int.Parse(age);

            if (age == "" || age1 >120 || age1 < 6)
            {
                Toast.MakeText(this, "You should enter your age or your age needs to be fixed for correct age number scale", ToastLength.Short).Show();
                return;
            }
            string country = this.etCountry.Text;
            if (country == "")
            {
                Toast.MakeText(this, "you should enter your country", ToastLength.Short).Show();
                return;
            }


            //this.firebaseAuth = AppDataHelper.GetFirebaseAuthentication();
            //this.firebaseA    uth.CreateUserWithEmailAndPassword(email, password);
            this.ShowProgressDialogue("Registering............");
            this.user = new UserData(username,email,password);
            if (await this.user.Register() == true)
            {
                Toast.MakeText(this, "register success" + password, ToastLength.Long).Show();
                this.progressDialog.Dismiss();
                this.Finish();
            }
            else
            {
                Toast.MakeText(this, "register failed", ToastLength.Long).Show();
            }
            this.progressDialog.Dismiss();
        }
        static string[] COUNTRIES = new string[] {
  "Afghanistan", "Albania", "Algeria", "American Samoa", "Andorra",
  "Angola", "Anguilla", "Antarctica", "Antigua and Barbuda", "Argentina",
  "Armenia", "Aruba", "Australia", "Austria", "Azerbaijan",
  "Bahrain", "Bangladesh", "Barbados", "Belarus", "Belgium",
  "Belize", "Benin", "Bermuda", "Bhutan", "Bolivia",
  "Bosnia and Herzegovina", "Botswana", "Bouvet Island", "Brazil", "British Indian Ocean Territory",
  "British Virgin Islands", "Brunei", "Bulgaria", "Burkina Faso", "Burundi",
  "Cote d'Ivoire", "Cambodia", "Cameroon", "Canada", "Cape Verde",
  "Cayman Islands", "Central African Republic", "Chad", "Chile", "China",
  "Christmas Island", "Cocos (Keeling) Islands", "Colombia", "Comoros", "Congo",
  "Cook Islands", "Costa Rica", "Croatia", "Cuba", "Cyprus", "Czech Republic",
  "Democratic Republic of the Congo", "Denmark", "Djibouti", "Dominica", "Dominican Republic",
  "East Timor", "Ecuador", "Egypt", "El Salvador", "Equatorial Guinea", "Eritrea",
  "Estonia", "Ethiopia", "Faeroe Islands", "Falkland Islands", "Fiji", "Finland",
  "Former Yugoslav Republic of Macedonia", "France", "French Guiana", "French Polynesia",
  "French Southern Territories", "Gabon", "Georgia", "Germany", "Ghana", "Gibraltar",
  "Greece", "Greenland", "Grenada", "Guadeloupe", "Guam", "Guatemala", "Guinea", "Guinea-Bissau",
  "Guyana", "Haiti", "Heard Island and McDonald Islands", "Honduras", "Hong Kong", "Hungary",
  "Iceland", "India", "Indonesia", "Iran", "Iraq", "Ireland", "Israel", "Italy", "Jamaica",
  "Japan", "Jordan", "Kazakhstan", "Kenya", "Kiribati", "Kuwait", "Kyrgyzstan", "Laos",
  "Latvia", "Lebanon", "Lesotho", "Liberia", "Libya", "Liechtenstein", "Lithuania", "Luxembourg",
  "Macau", "Madagascar", "Malawi", "Malaysia", "Maldives", "Mali", "Malta", "Marshall Islands",
  "Martinique", "Mauritania", "Mauritius", "Mayotte", "Mexico", "Micronesia", "Moldova",
  "Monaco", "Mongolia", "Montserrat", "Morocco", "Mozambique", "Myanmar", "Namibia",
  "Nauru", "Nepal", "Netherlands", "Netherlands Antilles", "New Caledonia", "New Zealand",
  "Nicaragua", "Niger", "Nigeria", "Niue", "Norfolk Island", "North Korea", "Northern Marianas",
  "Norway", "Oman", "Pakistan", "Palau", "Panama", "Papua New Guinea", "Paraguay", "Peru",
  "Philippines", "Pitcairn Islands", "Poland", "Portugal", "Puerto Rico", "Qatar",
  "Reunion", "Romania", "Russia", "Rwanda", "Sqo Tome and Principe", "Saint Helena",
  "Saint Kitts and Nevis", "Saint Lucia", "Saint Pierre and Miquelon",
  "Saint Vincent and the Grenadines", "Samoa", "San Marino", "Saudi Arabia", "Senegal",
  "Seychelles", "Sierra Leone", "Singapore", "Slovakia", "Slovenia", "Solomon Islands",
  "Somalia", "South Africa", "South Georgia and the South Sandwich Islands", "South Korea",
  "Spain", "Sri Lanka", "Sudan", "Suriname", "Svalbard and Jan Mayen", "Swaziland", "Sweden",
  "Switzerland", "Syria", "Taiwan", "Tajikistan", "Tanzania", "Thailand", "The Bahamas",
  "The Gambia", "Togo", "Tokelau", "Tonga", "Trinidad and Tobago", "Tunisia", "Turkey",
  "Turkmenistan", "Turks and Caicos Islands", "Tuvalu", "Virgin Islands", "Uganda",
  "Ukraine", "United Arab Emirates", "United Kingdom",
  "United States", "United States Minor Outlying Islands", "Uruguay", "Uzbekistan",
  "Vanuatu", "Vatican City", "Venezuela", "Vietnam", "Wallis and Futuna", "Western Sahara",
  "Yemen", "Yugoslavia", "Zambia", "Zimbabwe"};
        void ShowProgressDialogue(string status)
        {
            this.progressDialog = new ProgressDialog(this);
            progressDialog.SetCancelable(false);
            progressDialog.SetMessage(status);
            progressDialog.SetProgressStyle(ProgressDialogStyle.Spinner);
            progressDialog.Show();
        }

    }
}