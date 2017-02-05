using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FolderIconCreator
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            BitmapSource bs = WinHelper.ExtractIcon(@"C:\Windows\System32\Shell32.dll", 134);

            this.imageFolder.Source = bs;
            
             bs = WinHelper.ExtractAssociatedIcon(@"C:\Windows\System32\Shell32.dll");

            this.imageFolder2.Source = bs;
            
        }
    }
}
