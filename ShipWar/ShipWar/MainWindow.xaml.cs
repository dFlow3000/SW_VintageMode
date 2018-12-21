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
using Nocksoft.IO.ConfigFiles;
using System.IO;

namespace ShipWar
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        INIFile playerData;

        public const string ERROR_MESSAGE = "ERROR"; 
        public const string WARNING_MESSAGE = "WARNING";
        public const string INFO_MESSAGE = "INFO";


        public MainWindow()
        {
            InitializeComponent();
        }

        public void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Directory.CreateDirectory(Const.iniFolderPath);
            playerData = INIFile.CheckIfIniExists(Player.iniPath);

            UserControl UC_StartMenue = new StartMenue(this, playerData);
            MainContent.Content = UC_StartMenue;
        }

        #region Titelbar
        private void TB_dragNdrop(object sender, RoutedEventArgs e)
        {
            this.DragMove();
        }

        private void BTN_Window_Close_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void BTN_Window_Minimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
        #endregion

        #region Messagebar
        public void MessageBar(string messageTyp, string messageHeader, string messageText)
        {
            CNVS_MESSAGE_BAR.Visibility = Visibility.Visible;
            LBL_oMessageBarHeader.Content = messageHeader;
            LBL_oMessageBarText.Text = messageText;
        }
        #endregion

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CNVS_MESSAGE_BAR.Visibility = Visibility.Hidden;
        }
    }
}
