using Android.App;
using Android.Content;
using Firebase.Firestore;
using Firebase;
using Firebase.Auth;

namespace EmotionAidProject.Helpers
{
    public static class AppDataHelper
    {
        static ISharedPreferences preferences = Application.Context.GetSharedPreferences("userinfo", FileCreationMode.Private);
        static ISharedPreferencesEditor editor;
        static FirebaseFirestore database;
        public static FirebaseFirestore GetFirestore()
        {
            if (database != null)
            {
                return database;
            }
            var app = FirebaseApp.InitializeApp(Application.Context);

            if (app == null)
            {
                var options = new FirebaseOptions.Builder()
                    .SetProjectId("emotionaid-ce349")
                    .SetApplicationId("emotionaid-ce349")
                    .SetApiKey("AIzaSyCcYtmIy-J6KhSMfgT69b5uWWxEc2ADAAo")
                    //.SetDatabaseUrl("https://emotionaidproject.firebaseio.com")
                    .SetStorageBucket("emotionaid-ce349.appspot.com")
                    .Build();

                app = FirebaseApp.InitializeApp(Application.Context, options, "FameliyShopList");
                //FirebaseApp.InitializeApp(context, options, "MarketList");
                database = FirebaseFirestore.GetInstance(app);
            }
            else
            {
                database = FirebaseFirestore.GetInstance(app);
            }
            return database;
        }
        public static FirebaseAuth GetFirebaseAuthentication()
        {
            FirebaseAuth firebaseAuthentication;
            var app = FirebaseApp.InitializeApp(Application.Context);
            if (app == null)
            {
                var options = new FirebaseOptions.Builder()
                .SetProjectId("emotionaid-ce349")
                .SetApplicationId("emotionaid-ce349")
                .SetApiKey("AIzaSyCcYtmIy-J6KhSMfgT69b5uWWxEc2ADAAo")
                //.SetDatabaseUrl("https://emotionaidproject.firebaseio.com")
                .SetStorageBucket("emotionaid-ce349.appspot.com")
                .Build();
               
                app = FirebaseApp.InitializeApp(Application.Context, options);
                firebaseAuthentication = FirebaseAuth.Instance;
            }
            else
            {
                firebaseAuthentication = FirebaseAuth.Instance;
            }
            return firebaseAuthentication;
        }
        public static void SaveUserId(string userId)
        {
            editor = preferences.Edit();
            editor.PutString("userId", userId);
            editor.Apply();
        }

        public static string GetUserId()
        {
            string userId = "";
            userId = preferences.GetString("userId", "");
            return userId;
        }
    }
}
