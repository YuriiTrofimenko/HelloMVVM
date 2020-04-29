namespace HelloMVVM.ViewModels
{
    using Catel.Data;
    using Catel.MVVM;
    using System.Threading.Tasks;
    using System.Windows;

    public class MainWindowViewModel : ViewModelBase
    {
        public static readonly PropertyData FirstNameProperty;
        public static readonly PropertyData LastNameProperty;
        public Command ShowFirstName { get; private set; }
        static MainWindowViewModel()
        {
            FirstNameProperty
                = RegisterProperty(nameof(FirstName), typeof(string), null);
            LastNameProperty
                = RegisterProperty(nameof(LastName), typeof(string), null);
        }
        
        public MainWindowViewModel()
        {
            ShowFirstName = new Command(OnShowFirstNameExecute, OnShowFirstNameCanExecute);
        }

        public override string Title { get { return "Welcome to HelloMVVM"; } }

        public string FirstName
        {
            get {
                if (IsCheked)
                    return GetValue<string>(FirstNameProperty);
                else
                    return "";
            }
            set { SetValue(FirstNameProperty, value); }
        }

        public string LastName
        {
            get
            {
                if (IsCheked)
                    return GetValue<string>(LastNameProperty);
                else
                    return "";
            }
            set { SetValue(LastNameProperty, value); }
        }

        // TODO: Register models with the vmpropmodel codesnippet
        // TODO: Register view model properties with the vmprop or vmpropviewmodeltomodel codesnippets
        // TODO: Register commands with the vmcommand or vmcommandwithcanexecute codesnippets


        public bool IsCheked
        {
            get { return GetValue<bool>(IsChekedProperty); }
            set { SetValue(IsChekedProperty, value); }
        }

        public static readonly PropertyData IsChekedProperty = RegisterProperty(nameof(IsCheked), typeof(bool), null);

        private void OnShowFirstNameExecute()
        {
            MessageBox.Show(FirstName);
        }

        private bool OnShowFirstNameCanExecute()
        {
            return IsCheked;
        }



        protected override async Task InitializeAsync()
        {
            await base.InitializeAsync();

            // TODO: subscribe to events here
        }

        protected override async Task CloseAsync()
        {
            // TODO: unsubscribe from events here

            await base.CloseAsync();
        }
    }
}
