using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamarinCRM.Models;
using XamarinCRM.Pages.Splash;
using XamarinCRM.Services;
using XamarinCRM.Statics;
using XamarinCRM.ViewModels.Sales;
using XamarinCRM.Views;



namespace XamarinCRM.Pages
{
    public partial class Default : ContentPage
    {
        FloatingActionButtonView _Fab;

        public Default()
        {
            InitializeComponent();
        }

        public class Employee
        {
            public string DisplayName { get; set; }

        }

        ObservableCollection<Employee> employees = new ObservableCollection<Employee>();

        public void EmployeeListPage()
        {
            //defined in XAML to follow
            EmployeeView.ItemsSource = employees;

            employees.Add(new Employee { DisplayName = "Rob Finnerty" });
            employees.Add(new Employee { DisplayName = "Bill Wrestler" });
            employees.Add(new Employee { DisplayName = "Dr. Geri-Beth Hooper" });
            employees.Add(new Employee { DisplayName = "Dr. Keith Joyce-Purdy" });
            employees.Add(new Employee { DisplayName = "Sheri Spruce" });
            employees.Add(new Employee { DisplayName = "Burt Indybrick" });




            #region compose view hierarchy
            if (Device.OS == TargetPlatform.Android)
            {
              /*  _Fab = new FloatingActionButtonView
                {
                    ImageName = "fab_add.png",
                    ColorNormal = Palette._001,
                    ColorPressed = Palette._002,
                    ColorRipple = Palette._001,
                    Clicked = (sender, args) =>
                            _SalesDashboardLeadsViewModel.PushTabbedLeadPageCommand.Execute(null),
                };  */

                var absolute = new AbsoluteLayout
                {
                    VerticalOptions = LayoutOptions.FillAndExpand,
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                };

                // Position the pageLayout to fill the entire screen.
                // Manage positioning of child elements on the page by editing the pageLayout.
                AbsoluteLayout.SetLayoutFlags(EmployeeView, AbsoluteLayoutFlags.All);
                AbsoluteLayout.SetLayoutBounds(EmployeeView, new Rectangle(0f, 0f, 1f, 1f));
                absolute.Children.Add(EmployeeView);

                // Overlay the FAB in the bottom-right corner
                AbsoluteLayout.SetLayoutFlags(_Fab, AbsoluteLayoutFlags.PositionProportional);
                AbsoluteLayout.SetLayoutBounds(_Fab, new Rectangle(1f, 1f, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));
                absolute.Children.Add(_Fab);

                Content = absolute;
            }
            else
            {
//ToolbarItems.Add(new ToolbarItem("Add", "add_ios_gray", () =>
                   // _SalesDashboardLeadsViewModel.PushTabbedLeadPageCommand.Execute(null)));

                Content = EmployeeView;
            }
            #endregion

            #region wire up MessagingCenter
            // Catch the login success message from the MessagingCenter.
            // This is really only here for Android, which doesn't fire the OnAppearing() method in the same way that iOS does (every time the page appears on screen).
            Device.OnPlatform(Android: () => MessagingCenter.Subscribe<SplashPage>(this, MessagingServiceConstants.AUTHENTICATED, sender => OnAppearing()));
            #endregion

     
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            Content.IsVisible = true;
        }
    }
    }

