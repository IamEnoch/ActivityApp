using ActivityApp.Models;
using ActivityApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivityApp.ViewModel
{
    public partial class MainPageViewModel : BaseViewModel
    {
        public ObservableCollection<ActivityModel> Activity { get; } = new();
        ActivityService ActivityService;

        public MainPageViewModel(ActivityService activityService)
        {
            Title = $"{nameof(MainPage)}";
            ActivityService = activityService;
        }

        public async Task GetActivityAsync()
        {
            if (IsBusy == true)
                return;

            try
            {
                IsBusy = true;

                var activity = await ActivityService.GetActivityAsync();

                Activity.Add(activity);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Unable to get monkeys: {ex.Message}");
                await Shell.Current.DisplayAlert("Error!", ex.Message, "OK");
            }
            finally
            {
                IsBusy = false;
            }

        }
    }
}
