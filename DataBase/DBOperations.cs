using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace AkkaPractice.DataBase
{
    public class DBOperations: IDBOperations
    {
        static string _connectionString;
        public DBOperations()
        {
            _connectionString = "Data Source=LAPTOP-2JOFI7CP\\SQLEXPRESS;Initial Catalog=TODO;Integrated Security=True";

        }


        public void AddToDoInDB(ToDoItem todoItem)
        {
            string query = $"INSERT INTO TaskListToDoApp (ID, Itemname, Status) VALUES (@Id,@ToDoItem,@Status)";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@Id", todoItem.Id);
                    command.Parameters.AddWithValue("@ToDoItem", todoItem.ToDoTask);
                    command.Parameters.AddWithValue("@Status", todoItem.Status);
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        List<ToDoItem> IDBOperations.GetAllItemsInDB()
        {
            var list = new List<ToDoItem>();

            string displayQuery = "select * from TaskListToDoApp";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand(displayQuery, connection))
                {
                    connection.Open();
                    SqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        string guid = dataReader.GetValue(0).ToString();
                        string toDoItem = dataReader.GetValue(1).ToString();
                        string status = dataReader.GetValue(2).ToString();
                        if (Guid.TryParse(guid, out Guid id))
                        {

                            list.Add(new ToDoItem() { Id = id, ToDoTask = toDoItem, Status = ToDoItemStatus.Pending});
                        }
                    }
                }
            }
            return list;

        }

        public void UpdateToDoItemInDB(Guid id, string toDoItem)
        {

            string query = $"UPDATE TaskListToDoApp SET Itemname=@ToDoItem WHERE ID=@Id";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    if (id != Guid.Empty) // (id == Guid.Empty) --> old code
                    {
                        command.Parameters.AddWithValue("@ToDoItem", toDoItem);
                        command.Parameters.AddWithValue("@Id", id);
                    }
                    if (command.ExecuteNonQuery() == 0)
                    {
                        throw new Exception("No record found to update");
                    }
                }
            }
        }
        public void MarkAsCompleteInDB(Guid id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = $"DELETE FROM TaskListToDoApp WHERE ID=@Id";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    command.Parameters.AddWithValue("@Id", id);
                    if (command.ExecuteNonQuery() == 0)
                    {
                        throw new Exception("No record found to mark as complete.");
                    }
                }
            }
        }

      
    }
}
