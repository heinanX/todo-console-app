using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoConsoleApp.Models
{
    internal class TodoItem
    {
        public string title { get; set; }
        public bool isCompleted { get; set; }
        public DateTime dateAdded { get; }

        public TodoItem(string title)
        {
            this.title = title;
            isCompleted = false;
            dateAdded = DateTime.Now;
        }
    }
}
