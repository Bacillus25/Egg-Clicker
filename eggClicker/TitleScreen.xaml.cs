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

namespace eggClicker
{
    /// <summary>
    /// Interaction logic for TitleScreen.xaml
    /// </summary>
    public partial class TitleScreen : Window
    {
        public TitleScreen()
        {
            InitializeComponent();
        }

        private void btnNewGame_Click(object sender, RoutedEventArgs e)
        {
            TitleScreen oTitleScreen = new TitleScreen();
            MainWindow oMainWindow = new MainWindow();
            oMainWindow.Show();
            oTitleScreen.Close();
            Close();
        }

        private void btnContinue_Click(object sender, RoutedEventArgs e)
        {
            MainWindow oMainWindow = new MainWindow();
            oMainWindow.Show();
            oMainWindow.btnLoad_Click_1();
            Close();
        }
    }
}
