using System.Linq;
using System.Windows;
using GenderApp.Aggregates;
using Microsoft.Phone.Controls;
using Microsoft.Practices.Unity;
using System.Linq;

namespace GenderApp
{
	public partial class MainPage : PhoneApplicationPage
	{
		private MainPageViewModel mainPageViewModel;

		// Constructor
		public MainPage()
		{
			InitializeComponent();

			this.mainPageViewModel = new MainPageViewModel();
			this.DataContext = this.mainPageViewModel;
			// Sample code to localize the ApplicationBar
			//BuildLocalizedApplicationBar();
			this.Loaded += MainPage_Loaded;
		}

		async void MainPage_Loaded(object sender, RoutedEventArgs e)
		{
			var contactRetreiver = UnityManager.Container.Resolve<IGenderContactsRetriever>();
			var contacts = await contactRetreiver.GetContacts();
			contacts = contacts.Take(500);

			this.Progress.Maximum = contacts.Count();
			this.Progress.Value = 0;
			this.Progress.IsIndeterminate = false;

			var genderRetriever = UnityManager.Container.Resolve<IGenderRetriever>();
			foreach (var contact in contacts)
			{
				var result = (await genderRetriever.GetContactsAsync(new GenderRequest[] { contact })).First();
				this.mainPageViewModel.GenderContacts.Add(result);
				switch (result.Gender)
				{
					case Gender.Male:
						this.mainPageViewModel.MaleCount++;
						break;
					case Gender.Female:
						this.mainPageViewModel.FemaleCount++;
						break;
					default:
						break;
				}

				this.Progress.Value++;
			}

			this.Progress.Visibility = System.Windows.Visibility.Collapsed;
			this.ResultsList.Visibility = System.Windows.Visibility.Visible;
		}

		// Sample code for building a localized ApplicationBar
		//private void BuildLocalizedApplicationBar()
		//{
		//    // Set the page's ApplicationBar to a new instance of ApplicationBar.
		//    ApplicationBar = new ApplicationBar();

		//    // Create a new button and set the text value to the localized string from AppResources.
		//    ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
		//    appBarButton.Text = AppResources.AppBarButtonText;
		//    ApplicationBar.Buttons.Add(appBarButton);

		//    // Create a new menu item with the localized string from AppResources.
		//    ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
		//    ApplicationBar.MenuItems.Add(appBarMenuItem);
		//}
	}
}