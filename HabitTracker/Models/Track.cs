using SQLite;
using System;

namespace HabitTracker.Models
{
    public class Track
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int HabitId { get; set; }
        public DateTime Date { get; set; }

    }
}