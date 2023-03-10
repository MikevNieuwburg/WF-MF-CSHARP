using Org.BouncyCastle.Asn1.Mozilla;
using System;
using System.Windows.Controls;

namespace WPF_MiniForms_CSharp.Views
{
    /// <summary>
    /// Interaction logic for ModuleUserControl.xaml
    /// </summary>
    public partial class ModuleUserControl : UserControl
    {
        private object obj;
        public event UserControlEvent ButtonClick;
        public delegate void UserControlEvent(object sender, object passedModule);

        public void StartProcess()
        {
            Console.WriteLine("Process Started!");
            // some code here..
            OnProcessCompleted();
        }

        protected virtual void OnProcessCompleted()
        {
            ButtonClick?.Invoke(this, obj);
        }

        public ModuleUserControl()
        {
            InitializeComponent();
        }
    }
}
