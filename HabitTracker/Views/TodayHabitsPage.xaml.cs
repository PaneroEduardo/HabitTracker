using HabitTracker.Models;
using HabitTracker.ViewModels;
using HabitTracker.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HabitTracker.Views
{
    public partial class TodayHabitsPage : ContentPage
    {

        public TodayHabitsPage()
        {
            BindingContext = new HabitsListViewModel(Navigation);
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
        }
    }
}