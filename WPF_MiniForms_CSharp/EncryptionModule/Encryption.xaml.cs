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
using System.Windows.Shapes;

namespace WPF_MiniForms_CSharp.EncryptionModule
{
    /// <summary>
    /// Interaction logic for Encryption.xaml
    /// </summary>
    public partial class Encryption : Window
    {
        private CryptoObject _encryption;

        public Encryption()
        {
            InitializeComponent();
        }

        public Encryption(CryptoObject encryption)
        {
            _encryption = encryption;
        }

        public CryptoObject GetEncryptionObject => _encryption;
    }
}
