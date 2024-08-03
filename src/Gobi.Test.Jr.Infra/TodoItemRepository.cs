using Gobi.Test.Jr.Domain;
using Gobi.Test.Jr.Domain.DTO;
using Gobi.Test.Jr.Domain.Interfaces;
using System.Data.SQLite;

namespace Gobi.Test.Jr.Infra
{
	public class TodoItemRepository : ITodoItemRepository
	{
		public TodoItemRepository()
		{
			CreateDatabase();
			CreateTable();
		}

		private static SQLiteCommand CreateCommand()
		{
			var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Gobi.sqlite");
			var connectionString = $"Data Source={filePath}; Version=3;";
			var connection = new SQLiteConnection(connectionString);

			return new SQLiteCommand(connection);
		}

		private void CreateDatabase()
		{
			var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Gobi.sqlite");

			if (File.Exists(filePath) is false)
			{
				SQLiteConnection.CreateFile(filePath);
			}			
		}

		private void CreateTable()
		{
			var command = CreateCommand();

			command.CommandText = """
                CREATE TABLE IF NOT EXISTS "TodoItem" 
                (
                    "Id" integer NOT NULL PRIMARY KEY AUTOINCREMENT,
                    "Description" TEXT NOT NULL,
                    "Completed" integer NOT NULL
                );
                """;

			command.Connection.Open();
			command.ExecuteNonQuery();
			command.Connection.Close();
		}

	
		public IEnumerable<TodoItem> GetAll()
		{
			return new List<TodoItem>();
		}

        public async Task<bool> CreateItem(TodoItemDTO todoItem)
        {
			if (todoItem == null)
			{
				return false;
			} 
            using (var command = CreateCommand())
            {
                command.CommandText = "INSERT INTO TodoItem (Description, Completed) VALUES (@description, @completed)";
                command.Parameters.AddWithValue("@description", todoItem.Description);
                command.Parameters.AddWithValue("@completed", todoItem.Completed ? 1 : 0);

                command.Connection.Open();
                command.ExecuteNonQuery();
                command.Connection.Close();
            }

			return true;
        }

        public Task<bool> UpdateItem(TodoItemDTO todoItem, int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteItem(int id)
        {
            throw new NotImplementedException();
        }
    }
}
