using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Domain;

namespace TaskManager.Application
{
    public class InputValidator
    {
        public static byte GetCommandNumber()
        {

            byte commandNumber;

            while (true)
            {
                Console.Write("\nВведите код команды: ");

                if (byte.TryParse(Console.ReadLine(), out commandNumber)) break;
                else Console.WriteLine("Ошибка: введена некорректная команда!");
            }

            return commandNumber;
        }
        public static string ValidateString(string message)
        {
            string title;

            do
            {
                Console.Write($"\n{message}");
                title = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(title))
                    Console.WriteLine("Имя задачи не может быть пустым!");
            } while (string.IsNullOrWhiteSpace(title));

            return title;
        }

        public static PriorityLevel ValidateTaskPriorityLevel()
        {
            PriorityLevel priority;

            while (true)
            {
                Console.Write("\nВыберите приоритет задачи [2] - Очень низкий, [4] - Низкий, [6] - Средний, [8] - Высокий, [10] - Очень высокий\nПриоритет: ");

                if (byte.TryParse(Console.ReadLine(), out byte priorityValue) && Enum.IsDefined(typeof(PriorityLevel), priorityValue))
                {
                    priority = (PriorityLevel)priorityValue;
                    break;
                }
                else
                {
                    Console.WriteLine("Ошибка: некорректное значение приоритета!");
                }
            }

            return priority;
        }

        public static DateOnly ValidateTaskDueDate()
        {
            DateOnly date;

            while (true)
            {
                Console.Write("\nВведите дедлайн задачи: ");

                if (DateOnly.TryParseExact(Console.ReadLine(), "dd.MM.yyyy", out date))
                    break;
                else
                    Console.WriteLine("Ошибка: некорретное значение даты!");

            }

            return date;
        }

    }
}
