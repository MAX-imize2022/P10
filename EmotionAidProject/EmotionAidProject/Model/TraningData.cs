using SQLite;
using System;


namespace EmotionAidProject.Model
{
    [Table("training")]
    class TraningData
    {
        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }
        public int UserID { get; set; }
        public DateTime Tdate { get; set; }
        public int TraningNumber { get; set; }
        public int PressureB { get; set; }
        public int PressureA { get; set; }
       

        public TraningData()
        {
        }

        public TraningData(int userID, DateTime tdate, int traningNumber)
        {
            UserID = userID;
            Tdate = tdate;
            TraningNumber = traningNumber;
        }

    }
}