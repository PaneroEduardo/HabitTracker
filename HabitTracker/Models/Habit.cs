using System;
using System.Collections.Generic;
using System.Text;
using SQLite;


namespace HabitTracker.Models
{
    public class Habit
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string Hour { get; set; }
        public int Duration { get; set; }
        public bool Enabled { get; set; }
       
    }
}
