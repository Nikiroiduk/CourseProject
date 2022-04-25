using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace CourseProjectBL
{
    public class DataServices
    {
        private MongoCRUD db = new MongoCRUD("CourseProject");

        public User GetUserByLogin(string login)
        {
            var collection = db.LoadRecords<User>("Users");
            foreach (var rec in collection)
            {
                if (rec.Login == login)
                {
                    return db.LoadRecordById<User>("Users", rec.Id);
                }
            }
            return null;
        }

        public bool AddNewUser(string Login, string Password)
        {
            db.InsertRecord("Users", new User { Login = Login, Password = Security.EncryptPlainTextToCipherText(Password) });
            return true;
        }

    }
}
