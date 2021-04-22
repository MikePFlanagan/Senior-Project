using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using MusicAcademyCRM.Model;
using MusicAcademyCRM.Service;
using Xamarin.Forms;

namespace MusicAcademyCRM.ViewModels
{
    public class ViewModelBase
    {
        public IList<Meeting> Meetings { get; set; }

        public ViewModelBase()
        {
            Meetings = DataService.Instance.Data;
        }
    }
}
