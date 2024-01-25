using CheckMate.View;
using CheckMate_App.View;

namespace CheckMate
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute("CreateTaskPage", typeof(CreateTaskPage));
            Routing.RegisterRoute("MainPage", typeof(MainPage));
        }
    }
}