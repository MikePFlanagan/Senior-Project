using MusicAcademyCRM.Model;
using MusicAcademyCRM.Service;
using Xamarin.Forms;

namespace MusicAcademyCRM.ViewModels
{
    public class AddNewPageViewModel
    {
        public Meeting NewMeeting { get; set; } = new Meeting();

        public Command Submit { get; set; }

        public AddNewPageViewModel()
        {
            var data = DataService.Instance.Data;

            Submit = new Command(() => { data.Add(NewMeeting); });
        }
    }
}

