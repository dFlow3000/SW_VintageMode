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
    /// Interaktionslogik für Singleplayer_UserSelect.xaml
    /// </summary>
    public partial class Singleplayer_UserSelect : UserControl
    {
        private MainWindow SW_MainWindow;
        private INIFile PlayerData;
        private bool PlayerSelected = false;
        Player SelectedPlayer = new Player();
        bool newPlayerAdded = false;
        System.Windows.Forms.Timer timer1;

        public Singleplayer_UserSelect(MainWindow i_mainWindow, INIFile i_playerData, Player i_newPlayer = null)
        {
            InitializeComponent();
            SW_MainWindow = i_mainWindow;
            PlayerData = i_playerData;
            timer1 = new System.Windows.Forms.Timer();
            timer1.Interval = 1000;
            timer1.Tick += new EventHandler(ChangeInst);
            timer1.Start();
            
            if(i_newPlayer != null)
            {
                SelectedPlayer = i_newPlayer;
                newPlayerAdded = true;
                CNVS_Screen_ChoosePlayer.Visibility = Visibility.Hidden;
            }

        }

        private void ChangeInst(object sender, EventArgs e)
        {
            Random rnd = new Random();

            if (rnd.Next(1, 5) % 2 == 0)
            {
                IMG_INST_WARN_1.Source = (ImageSource)Application.Current.Resources["INST_WARN_" + Convert.ToString(rnd.Next(1, 5))];
            }

            if (rnd.Next(1, 5) % 2 == 0)
            {
                IMG_INST_WARN_2.Source = (ImageSource)Application.Current.Resources["INST_WARN_" + Convert.ToString(rnd.Next(1, 5))];
            }

            if (rnd.Next(1, 5) % 2 == 0)
            {
                IMG_INST_WARN_3.Source = (ImageSource)Application.Current.Resources["INST_WARN_" + Convert.ToString(rnd.Next(1, 5))];
            }

            if (rnd.Next(1, 5) % 2 == 0)
            {
                IMG_INST_2.Source = (ImageSource)Application.Current.Resources["INST_2_" + Convert.ToString(rnd.Next(1, 4))];
            }

            if (rnd.Next(1, 5) % 2 == 0)
            {
                IMG_INST_3.Source = (ImageSource)Application.Current.Resources["INST_3_" + Convert.ToString(rnd.Next(1, 4))];
            }

            if (rnd.Next(1, 5) % 2 == 0)
            {
                IMG_INST_4.Source = (ImageSource)Application.Current.Resources["INST_4_" + Convert.ToString(rnd.Next(1, 4))];
            }
        }

        private void Singleplayer_UserSelect_Loaded(object sender, RoutedEventArgs e)
        {
            for(int i = 1; i <= Convert.ToInt32(PlayerData.GetValue(Const.fileSec, Player.fsX_playerCnt)); i++)
            {
                ListBoxItem item = new ListBoxItem();
                item.Content = Convert.ToString(i) + " - " + PlayerData.GetValue(Player.playerSec + Convert.ToString(i), Player.pS_name);
                item.MouseDoubleClick += new MouseButtonEventHandler(CMBX_SelectPlayer_Item_Click);
                item.Style = (Style)Application.Current.Resources["SW_ComboBox_Items"];
                CMBX_LB_SelectPlayer.Items.Add(item);
            }

            if (newPlayerAdded)
            {
                LBL_oPlayerNumber.Content = Convert.ToString(SelectedPlayer.playerId);
                LBL_oPlayerName.Content = SelectedPlayer.playerName;
                LBL_oPlayerPoints.Content = Convert.ToString(SelectedPlayer.playerPoints);
                PlayerSelected = true;
            }
            else
            {
                CNVS_Screen_ChoosePlayer.Visibility = Visibility.Visible;
            }
        }

        #region Button
        private void BTN_NewPlayer_Click(object sender, RoutedEventArgs e)
        {
            timer1.Stop();
            UserControl addNewPlayer = new AddNewPlayer(SW_MainWindow, PlayerData);
            SW_MainWindow.MainContent.Content = addNewPlayer;
        }

        private void BTN_StartGame_Click(object sender, RoutedEventArgs e)
        {
            if (PlayerSelected)
            {
                timer1.Stop();
                UserControl gameBoard = new Singleplayer_GameBoard_SetterMode(SW_MainWindow, SelectedPlayer);
                SW_MainWindow.MainContent.Content = gameBoard;
            } else
            {
                SW_MainWindow.MessageBar(MainWindow.WARNING_MESSAGE, "Select a Player",
                    "To start a game you need to create a new Player or select an existing one!");
            }
        }
        #endregion

        #region Combobox
        private void CMBX_SelectPlayer_Click(object sender, RoutedEventArgs e)
        {
            CMBX_VisiCheck(CMBX_LB_SelectPlayer);
        }

        private void CMBX_SelectPlayer_Item_Click(object sender, RoutedEventArgs e)
        {
            SelectedPlayer = new Player();
            SelectedPlayer.Getter(CMBX_LB_SelectPlayer.SelectedIndex + 1);
            CMBX_LBL_SelectPlayer.Content = SelectedPlayer.playerName;
            CMBX_LB_SelectPlayer.Visibility = Visibility.Hidden;

            CNVS_Screen_ChoosePlayer.Visibility = Visibility.Hidden;

            LBL_oPlayerNumber.Content = Convert.ToString(SelectedPlayer.playerId);
            LBL_oPlayerName.Content = SelectedPlayer.playerName;
            LBL_oPlayerPoints.Content = Convert.ToString(SelectedPlayer.playerPoints);

            PlayerSelected = true;

        }

        private void CMBX_VisiCheck(ListBox i_CMBX_LB)
        {
            if (i_CMBX_LB.Visibility == Visibility.Visible)
            {
                i_CMBX_LB.Visibility = Visibility.Hidden;
            } else
            {
                i_CMBX_LB.Visibility = Visibility.Visible;
            }
        }
        #endregion

        #region Visualization

        #endregion
    }
}
