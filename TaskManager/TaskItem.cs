using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Cli
{
    internal class TaskItem
    {
        public Guid Id { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public bool IsCompleted { get; private set; }
        public int Priority { get; private set; }
        public DateOnly DueDate { get; private set; }

        public TaskItem(string title, string description, int priority, DateOnly dueDate)
        {
            Id = Guid.NewGuid();
            Title = title;
            Description = description;
            IsCompleted = false;
            Priority = priority;
            DueDate = dueDate;
        }

        public void ChangeTaskTitle(string title)
        {
            Title = title;
        }

        public void ChangeTaskDescription(string description)
        {
            Description = description;
        }

        public void ChangeTaskPriority(int priority)
        {
            Priority = priority;
        }

        public void ToggleCompletionStatus()
        {
            IsCompleted = !IsCompleted;
        }
    }
}