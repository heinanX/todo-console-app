using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using TodoConsoleApp.Models;
using TodoConsoleApp.Validation;
using static System.Collections.Specialized.BitVector32;

namespace TodoConsoleApp.Services
{
    internal class MenuServices
    {
        private TodoService _todoService = new TodoService();

        public List<string> startMenu = new List<string>() {
        "Exit",
        "Create New List",
        };

        public List<string> secondaryMenu = new List<string>() {
        "Exit",
        "Show All",
        "Create New",
        "Delete",
        "Mark as Completed"
        };


        public void DisplayMenu(List<string> menu)
        {
            int index = 0;
            if (menu.Count > 2)
            {
                Console.WriteLine("");
                Console.WriteLine("----------------- Main Menu: -----------------");
            }

            foreach (string option in menu)
            {
                Console.WriteLine($"{index}. {option}");
                index++;
            }
        }

        private int ValidateAction(List<string> menu)
        {
            int maxNum = menu.Count -1;

            while (true)
            {
                Console.WriteLine("");
                Console.WriteLine($"---  Chose an action by entering a number [0 - {maxNum}]");
                Console.WriteLine("");

                string? action = Console.ReadLine();
                (bool isValid, int num) = InputValidation.IsNumber(action);

                if (!isValid || !InputValidation.NumberIsInRange(num, maxNum))
                {
                    Console.WriteLine($"{action} is not a valid number");
                    Console.WriteLine("");
                    continue;
                }
                return num;
            }
        }

        private void HandleAction(int action)
        {
            switch (action)
            {
                case 0: return;

                case 1:
                    _todoService.ListAllTodos();
                    break;
                case 2:
                    _todoService.CreateTodo();
                    break;
                case 3:
                    _todoService.DeleteTodo();
                    break;
                case 4:
                    _todoService.MarkAsDone();
                    break;
            }
        }

        private int RunStartMenu()
        {
            DisplayMenu(startMenu);
            int action = ValidateAction(startMenu);
            return action;
        }

        private void RunSecondaryMenu()
        {
            bool isActive = true;
            while (isActive)
            {
                DisplayMenu(secondaryMenu);
                int newAction = ValidateAction(secondaryMenu);

                while (true)
                {
                    HandleAction(newAction);
                    break;
                }
                if (newAction == 0)
                {
                    isActive = false;
                }

            }
        }


        public void RunApp()
        {
            Console.WriteLine("initializing app...");
            Console.WriteLine();
            Console.WriteLine("----------------- Start Menu: -----------------");

            int action = RunStartMenu();
            if (action == 1)
            {
                RunSecondaryMenu();
            }

             Console.WriteLine("--- Exiting");
        }
    }
}
