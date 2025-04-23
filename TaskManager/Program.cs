using System.Drawing;
using TaskManager.Cli;

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

                int enteredNumber;

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
                Console.WriteLine();

                Console.Write("Введите код команды: ");
                enteredNumber = int.Parse(Console.ReadLine());

                switch(enteredNumber)
                {
                    case 1:

                        for (int i = 0; i < tasks.Count; i++)
                        {
                        Console.WriteLine($"\n\n" +
                            $"TaskID: {tasks[i].Id}\n" +
                            $"Title: {tasks[i].Title}\n" +
                            $"Description: {tasks[i].Description}\n" +
                            $"Priority: {tasks[i].Priority}\n" +
                            $"\bDueDate: {tasks[0].DueDate.ToString()}");
                        }


                        break;
                    case 2:
                        // Изменить
                        TaskItem task = new TaskItem("Task", "Description", 3, DateOnly.ParseExact("23.04.2025", "dd.MM.yyyy"));
                        tasks.Add(task);
                        
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

        // Нужно изменить
        //private TaskItem CreateTaskItem()
        //{
        //    TaskItem task = new TaskItem("Task", "Description", 3, DateOnly.ParseExact("23.04.2025", "dd.MM.yyyy"));

        //    return task;
        //}
    }
}
