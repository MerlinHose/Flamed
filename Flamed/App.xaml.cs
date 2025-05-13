using System.Data;
using Flamed.Scripts.SQL;

namespace Flamed
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            new Engine();
            return new Window(new AppShell());
        }
    }
}