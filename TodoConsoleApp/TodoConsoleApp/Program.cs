using TodoConsoleApp.Services;

namespace TodoConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MenuServices menuService = new MenuServices();

            menuService.RunApp();
        }
    }
}
