using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_MiniForms_CSharp.Views
{
    /// <summary>
    /// Interaction logic for FileModificationUserControl.xaml
    /// </summary>
    public partial class FileModificationUserControl : UserControl
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string FileInputTitle { get; set; }
        public string FileFilterTitle { get; set; }

        public FileModificationUserControl()
        {
            InitializeComponent();
        }
    }
}
