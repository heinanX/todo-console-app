using TodoConsoleApp.Services;

namespace TodoConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MenuServices app = new MenuServices();

            app.RunApp();
        }
    }
}
