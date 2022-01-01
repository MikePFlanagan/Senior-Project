using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MusicAcademyCRM.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddNewPage : ContentPage
	{
        public AddNewPage()
		{
			InitializeComponent ();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync(true);
        }

        private void ToolBarItem_Clicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync(true);
        }
    }
}