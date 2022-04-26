namespace CourseProjectBL.Services
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

        //public bool AddNewUser(string Login, string Password)
        //{
        //    db.InsertRecord("Users", new User { Login = Login, Password = PasswordService.EncryptPlainTextToCipherText(Password) });
        //    return true;
        //}

        public User AddNewUser(string Login, string Password)
        {
            var user = new User { Login = Login, Password = PasswordService.EncryptPlainTextToCipherText(Password) };
            db.InsertRecord("Users", user);
            return user;
        }

        public bool UpdateUserData(User user)
        {
            db.UpsertRecord("Users", user.Id, user);
            return true;
        }

    }
}
