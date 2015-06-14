using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using HW1.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace HW1
{
    class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();
            p.RemoveMinimumHomeWorkScore();

            Console.ReadKey();
        }

        async void RemoveMinimumHomeWorkScore()
        {
            //create school context
            SchoolContext schoolContext = new SchoolContext();
            List<Score> lstScore = new List<Score>();

            //var cnt = await schoolContext.Students.CountAsync(new BsonDocument());

            Console.Write("Started minimum homework score removal process for each student");

            /*
              remove the lowest homework score for each student. Since there is a single document for each student 
              containing an array of scores, you will need to update the scores array and remove the homework. 
            */
            await schoolContext.Students
               .Find(new BsonDocument())
               .ForEachAsync(async (student) =>
               {
                   Console.WriteLine(student.Name);

                   var score = student.Scores.Where(x => x.Type == "homework").OrderBy(x => x.Value).First();
                   lstScore.Add(score);

                   var filter = new BsonDocument();
                   var update = Builders<Student>.Update.Pull(x => x.Scores, score);
                   Console.WriteLine("Removing minimum homework score {0} for student {1}", score.Value, student.Name);
                   var post = await schoolContext.Students.UpdateManyAsync(filter, update);
               });


            Console.Write("Completed removal process");
        }
    }
}
