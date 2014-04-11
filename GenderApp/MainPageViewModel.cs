namespace GenderApp
{
	using System.Collections.ObjectModel;
	using System.ComponentModel;
	using GenderApp.Aggregates;

	public class MainPageViewModel : INotifyPropertyChanged
    {
        private int maleCount;
        private int femaleCount;
        private ObservableCollection<GenderResult> genderContacts;

        public event PropertyChangedEventHandler PropertyChanged;

        public MainPageViewModel()
        {
            this.genderContacts = new ObservableCollection<GenderResult>();
        }

        public ObservableCollection<GenderResult> GenderContacts
        {
            get
            {
                return this.genderContacts;
            }
            set
            {
                this.genderContacts = value;
                this.UpdateProperty("GenderContacts");
            }
        }

        public int MaleCount
        {
            get
            {
                return this.maleCount;
            }

            set
            {
                this.maleCount = value;
                this.UpdateProperty("MaleCount");
            }
        }

        public int FemaleCount
        {
            get
            {
                return this.femaleCount;
            }

            set
            {
                this.femaleCount = value;
                this.UpdateProperty("FemaleCount");
            }
        }

        private void UpdateProperty(string propertyName)
        {
            if (this.PropertyChanged == null)
            {
                return;
            }

            this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
