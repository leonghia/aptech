using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodosJSON.util;
using System.Data;

namespace TodosJSON.controller
{
    internal class TodoController
    {

        public static void AddTodos(Todo[] todos)
        {
            MySqlConnection conn = null;
            MySqlCommand command = null;
            try
            {
                conn = DBConnection.GetConnection();
                conn.Open();
                
                
                foreach (Todo todo in todos)
                {
                    command = new MySqlCommand("sp_add_todo", conn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@id_param", todo.id);
                    command.Parameters.AddWithValue("@todo_param", todo.todo);
                    int completed = todo.completed ? 1 : 0;
                    command.Parameters.AddWithValue("@completed_param", completed);
                    command.Parameters.AddWithValue("@user_id_param", todo.userId);

                    if (command.ExecuteNonQuery() > 0)
                    {
                        Console.WriteLine("Insert sucessfully");
                    }
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Console.WriteLine("Insert failed");
            }
            finally
            {
                try
                {
                    conn.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }
    }
}
