using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Domain
{
    public enum PriorityLevel : byte
    {
        VeryLow = 2,
        Low = 4,
        Medium = 6,
        High = 8,
        VeryHigh = 10
    }
    public class TaskItem
    {
        public Guid Id { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public bool IsCompleted { get; private set; }
        
        public PriorityLevel Priority { get; private set; }
        public DateOnly DueDate { get; private set; }

        public TaskItem(string title, string description, PriorityLevel priority, DateOnly dueDate)
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

        public void ChangeTaskPriority(PriorityLevel priority)
        {
            Priority = priority;
        }

        public void ToggleCompletionStatus()
        {
            IsCompleted = !IsCompleted;
        }
    }
}