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
    /// Interaktionslogik für StartMenue.xaml
    /// </summary>
    public partial class StartMenue : UserControl
    {
        private MainWindow SW_MainWindow;
        private INIFile PlayerData;
        public StartMenue(MainWindow i_mainWindow, INIFile i_playerData)
        {
            InitializeComponent();
            SW_MainWindow = i_mainWindow;
            PlayerData = i_playerData;
            
        }

        private void StartMenue_Loaded(object sender, RoutedEventArgs e)
        {

        }

        #region Button

        private void SwitchButtonImage(Image i_img, string i_btnName)
        {
            i_img.Source = (ImageSource)FindResource(i_btnName);
        }

        private void BTN_Singleplayer_Click(object sender, RoutedEventArgs e)
        {
            SwitchButtonImage(IMG_BTN_Singleplayer, BTN_Singleplayer.Name + "_Pressed");

            UserControl SingleplayerContent = new Singleplayer_UserSelect(SW_MainWindow, PlayerData);
            SW_MainWindow.MainContent.Content = SingleplayerContent;
        }

        private void BTN_SingleplayerMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            SwitchButtonImage(IMG_BTN_Singleplayer, BTN_Singleplayer.Name + "_Pressed");
        }

        private void BTN_Multiplayer_Click(object sender, RoutedEventArgs e)
        {
            SwitchButtonImage(IMG_BTN_Multiplayer, BTN_Multiplayer.Name);
        }

        private void BTN_MultiplayerMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            SwitchButtonImage(IMG_BTN_Multiplayer, BTN_Multiplayer.Name + "_Pressed");
        }
        #endregion
    }
}
