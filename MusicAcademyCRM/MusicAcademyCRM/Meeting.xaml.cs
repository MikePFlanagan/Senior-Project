using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MusicAcademyCRM
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    //public partial class Meeting : ContentPage
    //{
    //    public Meeting()
    //    {
    //        InitializeComponent();
    //    }
    //}

    partial class Meeting : INotifyPropertyChanged
    {
        #region private variables

        private string eventName;
        private string organizer;
        private DateTime beginTime;
        private DateTime endTime;
        private Color color;
        private bool isAllDay;
        private string recurrenceRule;

        #endregion

        #region Public Properties
        public string EventName
        {
            get
            {
                return this.eventName;
            }
            set
            {
                this.eventName = value;
                this.RaisePropertyChanged("EventName");
            }
        }
        public string Organizer
        {
            get
            {
                return this.organizer;
            }
            set
            {
                this.organizer = value;
                this.RaisePropertyChanged("Organizer");
            }
        }
        public DateTime BeginTime
        {
            get
            {
                return this.beginTime;
            }
            set
            {
                this.beginTime = value;
                this.RaisePropertyChanged("BeginTime");
            }
        }
        public DateTime EndTime
        {
            get
            {
                return this.endTime;
            }
            set
            {
                this.endTime = value;
                this.RaisePropertyChanged("EndTime");
            }
        }
        public Color Color
        {
            get
            {
                return this.color;
            }
            set
            {
                this.color = value;
                this.RaisePropertyChanged("Color");
            }
        }
        public bool IsAllDay
        {
            get
            {
                return this.isAllDay;
            }
            set
            {
                this.isAllDay = true;
                this.RaisePropertyChanged("IsAllDay");
            }
        }
        public string RecurrenceRule
        {
            get
            {
                return this.recurrenceRule;
            }
            set
            {
                this.recurrenceRule = value;
                this.RaisePropertyChanged("RecurrenceRule");
            }
        }

        #endregion

        #region INotifyPropertyChanged implementation

        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}