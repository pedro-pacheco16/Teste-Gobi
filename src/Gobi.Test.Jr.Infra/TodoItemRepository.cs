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

        public async Task <IEnumerable<TodoItem>> GetAll()
        {
            var items = new List<TodoItem>();

            using (var command = CreateCommand())
            {
                command.CommandText = "SELECT Id, Description, Completed FROM TodoItem ORDER BY Completed ASC";
                command.Connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        items.Add(new TodoItem()
                        {
                            Id = reader.GetInt32(0),
                            Description = reader.GetString(1),
                            Completed = reader.GetInt32(2) == 1
                        });
                    }
                    command.Connection.Close();
                }
                return items;
            }
        }

        public async Task<TodoItem?> GetById(int id)
        {
            if (id < 0)
            {
				return null;
			}
			
            TodoItem? todoItem = null;

			using (var command = CreateCommand())
			{
				command.CommandText = "SELECT Id, Description, Completed FROM TodoItem WHERE Id = @id";
				command.Parameters.AddWithValue("@id", id);

				command.Connection.Open();
				using (var reader = command.ExecuteReader())
				{
					if (reader.Read())
					{
						todoItem = new TodoItem()
						{
							Id = reader.GetInt32(0),
							Description = reader.GetString(1),
							Completed = reader.GetInt32(2) == 1
						};
					}
					command.Connection.Close();
				}
			}

			return todoItem;
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

        public async Task<bool> UpdateItem(TodoItemDTO todoItem, int id)
        {
            if (todoItem == null)
            {
                return false;
            }
            using (var command = CreateCommand())
            {
                command.CommandText = "UPDATE TodoItem SET Description = @Description, Completed = @Completed WHERE Id = @Id";
                command.Parameters.AddWithValue("@Description", todoItem.Description);
                command.Parameters.AddWithValue("@Completed", todoItem.Completed ? 1 : 0);
                command.Parameters.AddWithValue("@Id", id);

                command.Connection.Open();
                int rowsAffected = await command.ExecuteNonQueryAsync();
                command.Connection.Close();

                return rowsAffected > 0;
            }

        }

        public async Task<bool> DeleteItem(int id)
        {
            using (var command = CreateCommand())
            {
                command.CommandText = "DELETE FROM TodoItem WHERE Id = @Id";
                command.Parameters.AddWithValue("@id", id);

                command.Connection.Open();
                int rowsAffected = await command.ExecuteNonQueryAsync();
                command.Connection.Close();

                return rowsAffected > 0;
            }
        }
    }
}
