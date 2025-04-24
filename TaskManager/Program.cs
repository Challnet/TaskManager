using System.Diagnostics;
using System.Drawing;
using System.Threading.Tasks;
using TaskManager.Cli;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TaskManager
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool isWorking = true;
            List<TaskItem> tasks = new List<TaskItem>();

            while (isWorking)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Task Manager");
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Команды:");
                Console.WriteLine("[1] - Показать список в отдельном окне");
                Console.WriteLine("[2] - Добавить новую задачу");
                Console.WriteLine("[3] - Удалить задачу");
                Console.WriteLine("[4] - Изменить задачу");
                Console.WriteLine("[5] - Выход из программы");
                Console.WriteLine();

                switch(InputValidator.GetCommandNumber())
                {
                    case 1:

                        ShowTaskItems(tasks);

                        break;
                    case 2:
                        
                        AddNewTaskItem(tasks);
                        
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                    case 5:
                        isWorking = false;
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n\nТакой команды не существует!\nПопробуй еще!");
                        break;
                }

                Console.ReadKey();
            }            
        }


        static void ShowTaskItems(List<TaskItem> tasks)
        {
            for (int i = 0; i < tasks.Count; i++)
            {
                Console.ForegroundColor = ConsoleColor.Green;             
                Console.WriteLine($"\n\nЗАДАЧА {i + 1}");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"\n" +     
                    $"Имя задачи: {tasks[i].Title}\n" +
                    $"Описание: {tasks[i].Description}\n" +
                    $"Приоритет: {tasks[i].Priority}\n" +
                    $"\bСрок: {tasks[0].DueDate.ToString()}");
            }
        }

        static void AddNewTaskItem(List<TaskItem> tasks)
        {
            string title, description;
            DateOnly date;
            PriorityLevel priority;

            // Ввод названия задачи
            title = InputValidator.ValidateString("Введите имя задачи: ");

            // Ввод описания задачи
            description = InputValidator.ValidateString("Введите описание задачи: ");

            // Ввод приоритета задачи
            priority = InputValidator.ValidateTaskPriorityLevel();

            // Ввод срока выполнения задачи
            date = InputValidator.ValidateTaskDueDate();

            TaskItem task = new TaskItem(title, description, priority, date);
            tasks.Add(task);
        }
    }
}
