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
    /// Interaction logic for MailComposerUserControl.xaml
    /// </summary>
    public partial class MailComposerUserControl : UserControl
    {
        public string Receiver { get; set; }
        public string ReceiverTip { get; set; }
        public string CarbonReceiver { get; set; }
        public string CarbonReceiverTip { get; set; }
        public string BlindCarbonReceiver { get; set; }
        public string BlindCarbonReceiverTip { get; set; }
        public MailComposerUserControl()
        {
            InitializeComponent();
        }
    }
}
