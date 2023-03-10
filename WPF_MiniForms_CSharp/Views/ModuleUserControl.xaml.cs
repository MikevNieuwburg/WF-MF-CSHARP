using System.Windows.Controls;
using WPF_MiniForms_CSharp.Core;

namespace WPF_MiniForms_CSharp.Views
{
    /// <summary>
    /// Interaction logic for ModuleUserControl.xaml
    /// </summary>
    public partial class ModuleUserControl : UserControl
    {
        private object obj;
        private readonly Modules _modules;
        public System.Collections.Generic.List<string> AvailableModules { get; private set; }

        public ModuleUserControl()
        {
            InitializeComponent();
            DataContext = this;
            AvailableModules = _modules.GetModuleNames();
            obj = AvailableModules;
        }
    }
}
