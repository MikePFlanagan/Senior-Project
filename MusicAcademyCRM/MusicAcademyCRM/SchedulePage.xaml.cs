using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MusicAcademyCRM.Views;
using Xamarin.Forms;

namespace MusicAcademyCRM
{
    
    public partial class SchedulePage
    {
        public SchedulePage()
        {
            InitializeComponent();
        }

        private void MenuItem_OnClicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new AddNewPage(), true);
        }
    }

    
}