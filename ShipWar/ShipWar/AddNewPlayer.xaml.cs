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

namespace ShipWar
{
    /// <summary>
    /// Interaktionslogik für AddNewPlayer.xaml
    /// </summary>
    public partial class AddNewPlayer : UserControl
    {
        // Gloabal Values
        MainWindow SW_mainWindow;
        INIFile PlayerData;

        private int actScreenRow = 1;
        private System.Windows.Forms.Timer timer1 = new System.Windows.Forms.Timer();
        public AddNewPlayer(MainWindow i_MainWindow, INIFile i_PlayerData)
        {
            InitializeComponent();
            SW_mainWindow = i_MainWindow;
            PlayerData = i_PlayerData;
        }

        public void AddNewPlayer_Loaded(object sender, RoutedEventArgs e)
        {
            LBL_sNewPlayerShipWarHeader.Visibility = Visibility.Hidden;
            LBL_sNewPlayerHeader.Visibility = Visibility.Hidden;
            LBL_sNewPlayerName.Visibility = Visibility.Hidden;
            LBL_sNewPlayerNameArrow.Visibility = Visibility.Hidden;
            TBX_iNewPlayerName.Visibility = Visibility.Hidden;

            timer1.Interval = 500;
            timer1.Tick += new EventHandler(AddRowsToScreen);
            timer1.Start();

        }

        private void AddRowsToScreen(object sender, EventArgs e)
        {
            switch(actScreenRow)
            {
                case 1: LBL_sNewPlayerShipWarHeader.Visibility = Visibility.Visible; actScreenRow++; timer1.Interval = 1000; break;
                case 2: LBL_sNewPlayerHeader.Visibility = Visibility.Visible; actScreenRow++; break;
                case 3: LBL_sNewPlayerName.Visibility = Visibility.Visible; actScreenRow++; break;
                case 4: LBL_sNewPlayerNameArrow.Visibility = Visibility.Visible; actScreenRow++; break;
                default: TBX_iNewPlayerName.Visibility = Visibility.Visible; TBX_iNewPlayerName.Focus(); timer1.Stop(); BTN_NewPlayerSignIn.IsEnabled = true; BTN_NewPlayerCoward.IsEnabled = true; break;
            }
        }

        private void BTN_NewPlayerSignIn_Click(object sender, RoutedEventArgs e)
        {
            Player newPlayer = new Player(true);
            newPlayer.playerName = TBX_iNewPlayerName.Text;
            if (newPlayer.playerName == String.Empty)
            {
                LBL_sNewPlayerName.Content = "You need to enter your name!";
                TBX_iNewPlayerName.Text = String.Empty;
                TBX_iNewPlayerName.Focus();
            }
            else if (Player.CheckIfPlayerExists(newPlayer.playerName))
            {
                LBL_sNewPlayerName.Content = newPlayer.playerName + " already exists!";
                TBX_iNewPlayerName.Text = String.Empty;
                TBX_iNewPlayerName.Focus();
            }
            else
            {
                newPlayer.Setter();
                UserControl singleplayer_UserSelect = new Singleplayer_UserSelect(SW_mainWindow, PlayerData, newPlayer);
                SW_mainWindow.MainContent.Content = singleplayer_UserSelect;
            }
        }

        private void BTN_NewPlayerCoward_Click(object sender, RoutedEventArgs e)
        {
            UserControl singleplayer_UserSelect = new Singleplayer_UserSelect(SW_mainWindow, PlayerData);
            SW_mainWindow.MainContent.Content = singleplayer_UserSelect;
        }
    }
}
