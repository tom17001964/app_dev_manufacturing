using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Manufacturing_Society_App.Data
{
    public class SQLiteChatDatabase
    {
        private readonly SQLiteAsyncConnection database;

        public SQLiteChatDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Message>().Wait();
        }

        public Task<List<Message>> GetMessagesAsync()
        {
            return database.Table<Message>().ToListAsync();
        }

        public Task<int> SaveMessageAsync(Message message)
        {
            return database.InsertAsync(message);
        }

        public Task<int> DeleteMessageAsync(Message message)
        {
            return database.DeleteAsync(message);
        }
    }

    public class Message
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Content { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
