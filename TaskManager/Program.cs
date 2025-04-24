using System.Diagnostics;
using System.Drawing;
using System.Threading.Tasks;
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
            byte priority;
            DateOnly date;

            // Ввод названия задачи
            title = ValidateString("Введите имя задачи: ");

            // Ввод описания задачи
            description = ValidateString("Введите описание задачи: ");           

            Console.Write("Выберите приоритет задачи [2] - Очень низкий, [4] - Низкий, [6] - Средний, [8] - Высокий, [10] - Очень высокий\n: ");
            priority = byte.Parse(Console.ReadLine());
            PriorityLevel priorityLevel = (PriorityLevel)priority;

            Console.Write("Введите дедлайн задачи: ");
            date = DateOnly.ParseExact(Console.ReadLine(), "dd.MM.yyyy");

            TaskItem task = new TaskItem(title, description, priorityLevel, date);
            tasks.Add(task);
        }

        static string ValidateString(string message)
        {
            string title;

            do
            {
                Console.Write($"\n\n{message}");
                title = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(title))
                    Console.WriteLine("Имя задачи не может быть пустым!");
            } while (string.IsNullOrWhiteSpace(title));

            return message;
        }
    }
}
