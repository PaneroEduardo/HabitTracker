using HabitTracker.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace HabitTracker.ViewModels
{
    public class HabitsListViewModel : BaseViewModel
    {
        private INavigation _navigation;

        private ObservableCollection<HabitViewModel> _undoneHabits;
        public ObservableCollection<HabitViewModel> UndoneHabits
        {
            get
            {
                return _undoneHabits;
            }
            set
            {
                _undoneHabits = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<HabitViewModel> _doneHabits;
        public ObservableCollection<HabitViewModel> DoneHabits
        {
            get
            {
                return _doneHabits;
            }
            set
            {
                _doneHabits = value;
                OnPropertyChanged();
            }
        }


        public ICommand SearchHabitsCommand { private set; get; }
        public ICommand MarkHabitAsDoneCommand { private set; get; }

        public ICommand AddHabit { private set; get; }


        public HabitsListViewModel(INavigation navigation)
        {
            this._navigation = navigation;
            this.SearchHabitsCommand = new Command(async () => await RefreshHabitsAsync());
            this.SearchHabitsCommand.Execute(null);

            this.MarkHabitAsDoneCommand = new Command<int>(async (int id) => await MarkHabitAsDoneAsync(id));
            this.AddHabit = new Command(async () => await InsertHabit());

        }

        private async Task InsertHabit()
        {
            await App.Context.SaveItemAsync<Habit>(new Habit
            {
                Description = "Tomar vitaminas",
                Category = "Salud",
                Hour = "06:00",
                Duration = 1,
                Enabled = true
            }, true);
        }

        public async Task RefreshHabitsAsync()
        {
            DateTime today = DateTime.Today;
            List<Track> tracks = await App.Context.FilterItemsAsync<Track>(nameof(Track), x => x.Date > today);
            List<Habit> habits = await App.Context.GetItemsAsync<Habit>();

            this.UndoneHabits = new ObservableCollection<HabitViewModel>(habits
                .Where(habit => !tracks.Any(track => track.HabitId == habit.Id))
                .Select(habit => HabitViewModel.Parse(habit)));

            this.DoneHabits = new ObservableCollection<HabitViewModel>(habits
                .Where(habit => tracks.Any(track => track.HabitId == habit.Id))
                .Select(habit => HabitViewModel.Parse(habit)));
        }

        public async Task MarkHabitAsDoneAsync(int id)
        {
            await App.Context.SaveItemAsync(new Track
            {
                HabitId = id,
                Date = DateTime.Now
            }, true);

            await RefreshHabitsAsync();
        }

    }
}
