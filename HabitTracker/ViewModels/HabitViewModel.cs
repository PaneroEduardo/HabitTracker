using HabitTracker.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace HabitTracker.ViewModels
{
    public class HabitViewModel : BaseViewModel
    {
        private int _id;
        public int Id { 
            get => _id;
            set
            {
                this._id = value;
                OnPropertyChanged();
            }
        }

        private string _description;
        public string Description {
            get => _description;
            set
            {
                this._description = value;
                OnPropertyChanged();
            }
        }

        private string _category;
        public string Category
        {
            get => _category;
            set
            {
                this._category = value;
                OnPropertyChanged();
            }
        }

        private string _hour;
        public string Hour
        {
            get => _hour;
            set
            {
                this._hour = value;
                OnPropertyChanged();
            }
        }

        private int _duration;
        public int Duration
        {
            get => _duration;
            set
            {
                this._duration = value;
                OnPropertyChanged();
            }
        }

        private bool _enabled;
        public bool Enabled
        {
            get => _enabled;
            set
            {
                this._enabled = value;
                OnPropertyChanged();
            }
        }

        public static HabitViewModel Parse(Habit habit)
        {
            return new HabitViewModel
            {
                Id = habit.Id,
                Description = habit.Description,
                Category = habit.Category,
                Hour = habit.Hour,
                Duration = habit.Duration,
                Enabled = habit.Enabled
            };
        }


    }
}
