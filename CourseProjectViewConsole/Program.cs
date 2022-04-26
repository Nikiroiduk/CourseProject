using CourseProjectBL;
using System;

namespace CourseProjectViewConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            MongoCRUD db = new MongoCRUD("testDB");
            //db.InsertRecord("testObject", new testPerson { Name = "Meh2", Age = 20 });
            var recs = db.LoadRecords<testPerson>("testObject");
            /*
            foreach (var rec in recs)
            {
                Console.WriteLine($"{rec.Id}\n{rec.Name}\n{rec.Age}\n");
            }

*/
            var person = db.LoadRecordById<testPerson>("testObject", recs[0].Id);
            //person.Age = 21;
            //db.UpsertRecord("testObject", person.Id, person);
            db.DeleteRecord<testPerson>("testObject", person.Id);


            /*Console.WriteLine($"{person.Id}: {person.Name} {person.Age}");*/

            Console.ReadLine();
        }
    }
}
