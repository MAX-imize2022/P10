using Android.App;
using Android.Content;
using Android.Gms.Extensions;
using EmotionAidProject.Helpers;
using Firebase.Auth;
using Firebase.Firestore;
using Java.Util;
using SQLite;
using System;
using System.Threading.Tasks;

namespace EmotionAidProject.Model
{
    [Table("users")]
    class UserData
    {
        [PrimaryKey,AutoIncrement]
        public int ID {get; set;}
        public string Mail { get; set; }
        public string Password {get; set;} 
        public int Age {get; set;}
        public string Country { get; set;}
        public string Name {get; set;}
      
        FirebaseAuth firebaseAuthentication;
        FirebaseFirestore database;

        public const string COLLECTION_NAME = "users";
        public const string CURRENT_USER_FILE = "currentUserFile";
        public UserData()
        {
            this.firebaseAuthentication = AppDataHelper.GetFirebaseAuthentication();
            this.database = AppDataHelper.GetFirestore();
        }
        public UserData(string email, string password)
        {
            this.Name = "";
            this.Mail = email;
            this.Password = password;
            this.firebaseAuthentication = AppDataHelper.GetFirebaseAuthentication();
            this.database = AppDataHelper.GetFirestore();
        }
        public UserData(string password, int age, string country, string mail)
        {

            this.Name = "";
            this.Password = password;
            this.Age = age;
            this.Country = country;
            this.Mail = mail;
            this.firebaseAuthentication = AppDataHelper.GetFirebaseAuthentication();
            this.database = AppDataHelper.GetFirestore();
        }
        public UserData(string name, string mail, string password)
        {
            this.Name = name;
            this.Mail = mail;
            this.Password = password;
            this.firebaseAuthentication = AppDataHelper.GetFirebaseAuthentication();
            this.database = AppDataHelper.GetFirestore();
        }
        public UserData(string password, int age ,string country, string username, string email)
        {
          
            this.Password = password;
            this.Age = age;
            this.Country = country;
            this.Name = Name;
            this.Mail = Mail;
            this.firebaseAuthentication = AppDataHelper.GetFirebaseAuthentication();
            this.database = AppDataHelper.GetFirestore();
        }

        public async Task<bool>Login()
        {
            try
            {
                await this.firebaseAuthentication.SignInWithEmailAndPassword(this.Mail , this.Password);
                var editor = Application.Context.GetSharedPreferences(CURRENT_USER_FILE, FileCreationMode.Private).Edit();
                editor.PutString("email", this.Mail);
                editor.PutString("password", this.Password);
                editor.PutString("fullname", this.Name);
                editor.Apply();
            }
            catch(Exception ex)
            {
                string s = ex.Message;
                return false;
            }
            return true;
        }
        public async Task<bool> Register()
        {
            try
            {
                await this.firebaseAuthentication.CreateUserWithEmailAndPassword(this.Mail, this.Password);
            }
            catch
            {

                return false; ;
            }
            try
            {
                HashMap userMap = new HashMap();//
                userMap.Put("email", this.Mail);
                userMap.Put("fullName", this.Name);
                DocumentReference userReference = this.database.Collection(COLLECTION_NAME).Document(this.firebaseAuthentication.CurrentUser.Uid);
                await userReference.Set(userMap);//
            }
            catch
            {

                return false;
            }
            return true;
        }

    }
}