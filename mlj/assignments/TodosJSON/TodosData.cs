using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodosJSON
{
    internal class TodosData
    {
        public Todo[] todos { get; set; }
        public int total { get; set; }
        public int skip { get; set; }
        public int limit { get; set; }
        

        public void Display()
        {
            foreach (Todo todo in todos)
            {
                Console.WriteLine(todo);
                Console.WriteLine(new String('-', 150));
            }
        }

    }

    internal class Todo
    {
        public int id { get; set; }
        public string todo { get; set; }
        public bool completed { get; set; }
        public int userId { get; set; }

        public override string ToString()
        {
            return $"id: {id}\n" +
                $"todo: {todo}\n" +
                $"completed: {completed}\n" +
                $"userId: {userId}\n";
        }
    }
}
