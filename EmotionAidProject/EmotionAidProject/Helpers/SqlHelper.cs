using System.Collections.Generic;
using SQLite;
using EmotionAidProject.Model;

namespace EmotionAidProject.Helpers
{
    class SqlHelper
    {
        private readonly string fileName;
        private readonly SQLiteConnection conn;

        public SqlHelper()
        {
            this.fileName = "emotionDB.db";
            string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            path = System.IO.Path.Combine(path, fileName);
            conn = new SQLiteConnection(path);
            conn.CreateTable<UserData>();
            conn.CreateTable<TraningData>();
        }

        public List<UserData> GetAllUsers()
        {
            string strSQL = string.Empty;
            strSQL = "SELECT * FROM users";

            return conn.Query<UserData>(strSQL);
        }

        public void Insert(UserData user)
        {
            conn.Insert(user);
        }
        public void Update(UserData user)
        {
            conn.Update(user);
        }
        public void Delete(UserData user)
        {
            conn.Delete(user);
        }
        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public List<TraningData> GetAllTraining()
        {
            string strSQL = string.Empty;
            strSQL = "SELECT * FROM training";


            return conn.Query<TraningData>(strSQL);
        }

        public void InsertTrain(TraningData train)
        {
            conn.Insert(train);
        }
        public void UpdateTrain(TraningData train)
        {
            conn.Update(train);
        }
        public void DeleteTrain(TraningData train)
        {
            conn.Delete(train);
        }
    }
}
