using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoConsoleApp.Models;
using TodoConsoleApp.Validation;

namespace TodoConsoleApp.Services
{
    internal class TodoService
    {
        public List<TodoItem> todoItems = new List<TodoItem>();

        public void CreateTodo()
        {
            Console.WriteLine("----------------- CREATE TODO -----------------");
            Console.WriteLine("");
            Console.WriteLine("Enter todos, or enter 0 to cancel: ");
            while (true)
            {
                string? input = Console.ReadLine();
                if (input == "0")
                {
                    return;
                }
                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Todo cannot be empty.");
                    continue;
                }
                TodoItem newTask = new TodoItem(input);
                todoItems.Add(newTask);
                Console.WriteLine($"-- {input} saved to list");
            }
        }


        public void ListAllTodos()
        {
            Console.WriteLine("----------------- Todos -----------------");
            
            for (int i = 0; i < todoItems.Count; i++)
            {
                Console.WriteLine($"TASK {i+1}: {todoItems[i].title} ---- Completed: {todoItems[i].isCompleted}");
            }
            Console.WriteLine("-----------------       -----------------");
            Console.WriteLine("");
        }

        public void DeleteTodo()
        {
            Console.WriteLine("----------------- DELETE TODO -----------------");
            Console.WriteLine("");
            ListAllTodos();
            Console.WriteLine("Enter the todo you want to delete, or 0 to cancel");
            Console.WriteLine("");
            string? input = Console.ReadLine();
            if (input == "0")
            {
                return;
            }
            if (!todoItems.Any(item => item.title == input))
            {
                Console.WriteLine("--- Error. Todo doesn't exist");
            }
                todoItems.RemoveAll(item => item.title == input);
                Console.WriteLine($"--- {input} deleted");
        }
        
        public void MarkAsDone()
        {

        }

    }
}
