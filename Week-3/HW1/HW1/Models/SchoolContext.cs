using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using MongoDB.Driver;

namespace HW1.Models
{
    public class SchoolContext
    {
        public const string CONNECTION_STRING_NAME = "School";
        public const string DATABASE_NAME = "school";
        public const string STUDENTS_COLLECTION_NAME = "students";
       
        // This is ok... Normally, they would be put into
        // an IoC container.
        private static readonly IMongoClient _client;
        private static readonly IMongoDatabase _database;

        static SchoolContext()
        {
            var connectionString = ConfigurationManager.ConnectionStrings[CONNECTION_STRING_NAME].ConnectionString;
            _client = new MongoClient(connectionString);
            _database = _client.GetDatabase(DATABASE_NAME);
        }

        public IMongoClient Client
        {
            get { return _client; }
        }

        public IMongoCollection<Student> Students
        {
            get { return _database.GetCollection<Student>(STUDENTS_COLLECTION_NAME); }
        }

    }
}