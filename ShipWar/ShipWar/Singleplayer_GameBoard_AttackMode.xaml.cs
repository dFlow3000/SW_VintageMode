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

namespace ShipWar
{
    /// <summary>
    /// Interaktionslogik für Singleplayer_GameBoard_AttackMode.xaml
    /// </summary>
    public partial class Singleplayer_GameBoard_AttackMode : UserControl
    {
        MainWindow SW_MainWindow;
        Player GamePlayer;

        // User Stuff from Setter Mode
        List<PlacedShips> User_Placed_Ship1 = new List<PlacedShips>();
        List<PlacedShips> User_Placed_Ship2 = new List<PlacedShips>();
        List<PlacedShips> User_Placed_Ship3 = new List<PlacedShips>();
        List<PlacedShips> User_Placed_Ship4 = new List<PlacedShips>();
        GameBoardField[,] User_GameMap_Radar_Array = new GameBoardField[12, 12];
        GameBoardField[,] SM_User_GameMap_Array = new GameBoardField[12, 12];

        // Computer Stuff
        List<PlacedShips> Computer_Placed_Ship1 = new List<PlacedShips>();
        List<PlacedShips> Computer_Placed_Ship2 = new List<PlacedShips>();
        List<PlacedShips> Computer_Placed_Ship3 = new List<PlacedShips>();
        List<PlacedShips> Computer_Placed_Ship4 = new List<PlacedShips>();
        GameBoardField[,] Computer_GameMap_Array = new GameBoardField[12, 12];
        int Computer_placedCnt_Ship1 = 0;
        int Computer_placedCnt_Ship2 = 0;
        int Computer_placedCnt_Ship3 = 0;
        int Computer_placedCnt_Ship4 = 0;
        List<Coords> Computer_Strike_Coords = new List<Coords>();
        ComputerCoordsIntelligence CciCoords;
        bool CheckCCI_Coords = false;
        bool oldHitGuess = false;

        public Singleplayer_GameBoard_AttackMode(MainWindow i_MainWindow, Player i_player, List<PlacedShips> UPS1, List<PlacedShips> UPS2, List<PlacedShips> UPS3, List<PlacedShips> UPS4, GameBoardField[,] UGameMap)
        {
            InitializeComponent();
            SW_MainWindow = i_MainWindow;
            GamePlayer = i_player;
            User_Placed_Ship1 = UPS1;
            User_Placed_Ship2 = UPS2;
            User_Placed_Ship3 = UPS3;
            User_Placed_Ship4 = UPS4;
            SM_User_GameMap_Array = UGameMap;
        }

        public void Singleplayer_GameBoard_AttackMode_Loaded(object sender, RoutedEventArgs e)
        {
            FillGameBoardInfo();
            FillComputer_GameMap_Array();
            FillGameMap_Radar_Array();
            CopySM_ButtonToAM_Button();
            SetComputerShips();
        }

        #region Fill ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        private void FillGameBoardInfo()
        {
            LBL_oPlayerName.Content = GamePlayer.playerName;
            LBL_oPlayerNumber.Content = Convert.ToString(GamePlayer.playerId);
            LBL_oPlayerTotalPoints.Content = Convert.ToString(GamePlayer.playerPoints);
        }

        private void CopySM_ButtonToAM_Button()
        {
            for (int i = 0; i < 12; i++)
            {
                for (int x = 0; x < 12; x++)
                {
                    if (SM_User_GameMap_Array[i, x].fieldState == Const.FieldState.SHIP)
                    {
                        User_GameMap_Radar_Array[i, x].fieldState = Const.FieldState.SHIP;
                        User_GameMap_Radar_Array[i, x].ship = SM_User_GameMap_Array[i, x].ship;
                        User_GameMap_Radar_Array[i, x].fieldButton.Style = (Style)Application.Current.Resources["GB_AttackMode_Radarfield_Ship_Button"];
                    }
                }
            }
        }

        private void FillComputer_GameMap_Array(bool addMouseOver = true)
        {
            #region A
            Computer_GameMap_Array[0, 0] = new GameBoardField(BTN_GB_A1);
            Computer_GameMap_Array[0, 1] = new GameBoardField(BTN_GB_A2);
            Computer_GameMap_Array[0, 2] = new GameBoardField(BTN_GB_A3);
            Computer_GameMap_Array[0, 3] = new GameBoardField(BTN_GB_A4);
            Computer_GameMap_Array[0, 4] = new GameBoardField(BTN_GB_A5);
            Computer_GameMap_Array[0, 5] = new GameBoardField(BTN_GB_A6);
            Computer_GameMap_Array[0, 6] = new GameBoardField(BTN_GB_A7);
            Computer_GameMap_Array[0, 7] = new GameBoardField(BTN_GB_A8);
            Computer_GameMap_Array[0, 8] = new GameBoardField(BTN_GB_A9);
            Computer_GameMap_Array[0, 9] = new GameBoardField(BTN_GB_A10);
            Computer_GameMap_Array[0, 10] = new GameBoardField(BTN_GB_A11);
            Computer_GameMap_Array[0, 11] = new GameBoardField(BTN_GB_A12);
            #endregion      
            #region B       
            Computer_GameMap_Array[1, 0] = new GameBoardField(BTN_GB_B1);
            Computer_GameMap_Array[1, 1] = new GameBoardField(BTN_GB_B2);
            Computer_GameMap_Array[1, 2] = new GameBoardField(BTN_GB_B3);
            Computer_GameMap_Array[1, 3] = new GameBoardField(BTN_GB_B4);
            Computer_GameMap_Array[1, 4] = new GameBoardField(BTN_GB_B5);
            Computer_GameMap_Array[1, 5] = new GameBoardField(BTN_GB_B6);
            Computer_GameMap_Array[1, 6] = new GameBoardField(BTN_GB_B7);
            Computer_GameMap_Array[1, 7] = new GameBoardField(BTN_GB_B8);
            Computer_GameMap_Array[1, 8] = new GameBoardField(BTN_GB_B9);
            Computer_GameMap_Array[1, 9] = new GameBoardField(BTN_GB_B10);
            Computer_GameMap_Array[1, 10] = new GameBoardField(BTN_GB_B11);
            Computer_GameMap_Array[1, 11] = new GameBoardField(BTN_GB_B12);
            #endregion      
            #region C       
            Computer_GameMap_Array[2, 0] = new GameBoardField(BTN_GB_C1);
            Computer_GameMap_Array[2, 1] = new GameBoardField(BTN_GB_C2);
            Computer_GameMap_Array[2, 2] = new GameBoardField(BTN_GB_C3);
            Computer_GameMap_Array[2, 3] = new GameBoardField(BTN_GB_C4);
            Computer_GameMap_Array[2, 4] = new GameBoardField(BTN_GB_C5);
            Computer_GameMap_Array[2, 5] = new GameBoardField(BTN_GB_C6);
            Computer_GameMap_Array[2, 6] = new GameBoardField(BTN_GB_C7);
            Computer_GameMap_Array[2, 7] = new GameBoardField(BTN_GB_C8);
            Computer_GameMap_Array[2, 8] = new GameBoardField(BTN_GB_C9);
            Computer_GameMap_Array[2, 9] = new GameBoardField(BTN_GB_C10);
            Computer_GameMap_Array[2, 10] = new GameBoardField(BTN_GB_C11);
            Computer_GameMap_Array[2, 11] = new GameBoardField(BTN_GB_C12);
            #endregion      
            #region D       
            Computer_GameMap_Array[3, 0] = new GameBoardField(BTN_GB_D1);
            Computer_GameMap_Array[3, 1] = new GameBoardField(BTN_GB_D2);
            Computer_GameMap_Array[3, 2] = new GameBoardField(BTN_GB_D3);
            Computer_GameMap_Array[3, 3] = new GameBoardField(BTN_GB_D4);
            Computer_GameMap_Array[3, 4] = new GameBoardField(BTN_GB_D5);
            Computer_GameMap_Array[3, 5] = new GameBoardField(BTN_GB_D6);
            Computer_GameMap_Array[3, 6] = new GameBoardField(BTN_GB_D7);
            Computer_GameMap_Array[3, 7] = new GameBoardField(BTN_GB_D8);
            Computer_GameMap_Array[3, 8] = new GameBoardField(BTN_GB_D9);
            Computer_GameMap_Array[3, 9] = new GameBoardField(BTN_GB_D10);
            Computer_GameMap_Array[3, 10] = new GameBoardField(BTN_GB_D11);
            Computer_GameMap_Array[3, 11] = new GameBoardField(BTN_GB_D12);
            #endregion      
            #region E 4     
            Computer_GameMap_Array[4, 0] = new GameBoardField(BTN_GB_E1);
            Computer_GameMap_Array[4, 1] = new GameBoardField(BTN_GB_E2);
            Computer_GameMap_Array[4, 2] = new GameBoardField(BTN_GB_E3);
            Computer_GameMap_Array[4, 3] = new GameBoardField(BTN_GB_E4);
            Computer_GameMap_Array[4, 4] = new GameBoardField(BTN_GB_E5);
            Computer_GameMap_Array[4, 5] = new GameBoardField(BTN_GB_E6);
            Computer_GameMap_Array[4, 6] = new GameBoardField(BTN_GB_E7);
            Computer_GameMap_Array[4, 7] = new GameBoardField(BTN_GB_E8);
            Computer_GameMap_Array[4, 8] = new GameBoardField(BTN_GB_E9);
            Computer_GameMap_Array[4, 9] = new GameBoardField(BTN_GB_E10);
            Computer_GameMap_Array[4, 10] = new GameBoardField(BTN_GB_E11);
            Computer_GameMap_Array[4, 11] = new GameBoardField(BTN_GB_E12);
            #endregion      
            #region F 5     
            Computer_GameMap_Array[5, 0] = new GameBoardField(BTN_GB_F1);
            Computer_GameMap_Array[5, 1] = new GameBoardField(BTN_GB_F2);
            Computer_GameMap_Array[5, 2] = new GameBoardField(BTN_GB_F3);
            Computer_GameMap_Array[5, 3] = new GameBoardField(BTN_GB_F4);
            Computer_GameMap_Array[5, 4] = new GameBoardField(BTN_GB_F5);
            Computer_GameMap_Array[5, 5] = new GameBoardField(BTN_GB_F6);
            Computer_GameMap_Array[5, 6] = new GameBoardField(BTN_GB_F7);
            Computer_GameMap_Array[5, 7] = new GameBoardField(BTN_GB_F8);
            Computer_GameMap_Array[5, 8] = new GameBoardField(BTN_GB_F9);
            Computer_GameMap_Array[5, 9] = new GameBoardField(BTN_GB_F10);
            Computer_GameMap_Array[5, 10] = new GameBoardField(BTN_GB_F11);
            Computer_GameMap_Array[5, 11] = new GameBoardField(BTN_GB_F12);
            #endregion      
            #region G 6     
            Computer_GameMap_Array[6, 0] = new GameBoardField(BTN_GB_G1);
            Computer_GameMap_Array[6, 1] = new GameBoardField(BTN_GB_G2);
            Computer_GameMap_Array[6, 2] = new GameBoardField(BTN_GB_G3);
            Computer_GameMap_Array[6, 3] = new GameBoardField(BTN_GB_G4);
            Computer_GameMap_Array[6, 4] = new GameBoardField(BTN_GB_G5);
            Computer_GameMap_Array[6, 5] = new GameBoardField(BTN_GB_G6);
            Computer_GameMap_Array[6, 6] = new GameBoardField(BTN_GB_G7);
            Computer_GameMap_Array[6, 7] = new GameBoardField(BTN_GB_G8);
            Computer_GameMap_Array[6, 8] = new GameBoardField(BTN_GB_G9);
            Computer_GameMap_Array[6, 9] = new GameBoardField(BTN_GB_G10);
            Computer_GameMap_Array[6, 10] = new GameBoardField(BTN_GB_G11);
            Computer_GameMap_Array[6, 11] = new GameBoardField(BTN_GB_G12);
            #endregion      
            #region H 7     
            Computer_GameMap_Array[7, 0] = new GameBoardField(BTN_GB_H1);
            Computer_GameMap_Array[7, 1] = new GameBoardField(BTN_GB_H2);
            Computer_GameMap_Array[7, 2] = new GameBoardField(BTN_GB_H3);
            Computer_GameMap_Array[7, 3] = new GameBoardField(BTN_GB_H4);
            Computer_GameMap_Array[7, 4] = new GameBoardField(BTN_GB_H5);
            Computer_GameMap_Array[7, 5] = new GameBoardField(BTN_GB_H6);
            Computer_GameMap_Array[7, 6] = new GameBoardField(BTN_GB_H7);
            Computer_GameMap_Array[7, 7] = new GameBoardField(BTN_GB_H8);
            Computer_GameMap_Array[7, 8] = new GameBoardField(BTN_GB_H9);
            Computer_GameMap_Array[7, 9] = new GameBoardField(BTN_GB_H10);
            Computer_GameMap_Array[7, 10] = new GameBoardField(BTN_GB_H11);
            Computer_GameMap_Array[7, 11] = new GameBoardField(BTN_GB_H12);
            #endregion      
            #region I 8     
            Computer_GameMap_Array[8, 0] = new GameBoardField(BTN_GB_I1);
            Computer_GameMap_Array[8, 1] = new GameBoardField(BTN_GB_I2);
            Computer_GameMap_Array[8, 2] = new GameBoardField(BTN_GB_I3);
            Computer_GameMap_Array[8, 3] = new GameBoardField(BTN_GB_I4);
            Computer_GameMap_Array[8, 4] = new GameBoardField(BTN_GB_I5);
            Computer_GameMap_Array[8, 5] = new GameBoardField(BTN_GB_I6);
            Computer_GameMap_Array[8, 6] = new GameBoardField(BTN_GB_I7);
            Computer_GameMap_Array[8, 7] = new GameBoardField(BTN_GB_I8);
            Computer_GameMap_Array[8, 8] = new GameBoardField(BTN_GB_I9);
            Computer_GameMap_Array[8, 9] = new GameBoardField(BTN_GB_I10);
            Computer_GameMap_Array[8, 10] = new GameBoardField(BTN_GB_I11);
            Computer_GameMap_Array[8, 11] = new GameBoardField(BTN_GB_I12);
            #endregion      
            #region J 9     
            Computer_GameMap_Array[9, 0] = new GameBoardField(BTN_GB_J1);
            Computer_GameMap_Array[9, 1] = new GameBoardField(BTN_GB_J2);
            Computer_GameMap_Array[9, 2] = new GameBoardField(BTN_GB_J3);
            Computer_GameMap_Array[9, 3] = new GameBoardField(BTN_GB_J4);
            Computer_GameMap_Array[9, 4] = new GameBoardField(BTN_GB_J5);
            Computer_GameMap_Array[9, 5] = new GameBoardField(BTN_GB_J6);
            Computer_GameMap_Array[9, 6] = new GameBoardField(BTN_GB_J7);
            Computer_GameMap_Array[9, 7] = new GameBoardField(BTN_GB_J8);
            Computer_GameMap_Array[9, 8] = new GameBoardField(BTN_GB_J9);
            Computer_GameMap_Array[9, 9] = new GameBoardField(BTN_GB_J10);
            Computer_GameMap_Array[9, 10] = new GameBoardField(BTN_GB_J11);
            Computer_GameMap_Array[9, 11] = new GameBoardField(BTN_GB_J12);
            #endregion      
            #region K 10    
            Computer_GameMap_Array[10, 0] = new GameBoardField(BTN_GB_K1);
            Computer_GameMap_Array[10, 1] = new GameBoardField(BTN_GB_K2);
            Computer_GameMap_Array[10, 2] = new GameBoardField(BTN_GB_K3);
            Computer_GameMap_Array[10, 3] = new GameBoardField(BTN_GB_K4);
            Computer_GameMap_Array[10, 4] = new GameBoardField(BTN_GB_K5);
            Computer_GameMap_Array[10, 5] = new GameBoardField(BTN_GB_K6);
            Computer_GameMap_Array[10, 6] = new GameBoardField(BTN_GB_K7);
            Computer_GameMap_Array[10, 7] = new GameBoardField(BTN_GB_K8);
            Computer_GameMap_Array[10, 8] = new GameBoardField(BTN_GB_K9);
            Computer_GameMap_Array[10, 9] = new GameBoardField(BTN_GB_K10);
            Computer_GameMap_Array[10, 10] = new GameBoardField(BTN_GB_K11);
            Computer_GameMap_Array[10, 11] = new GameBoardField(BTN_GB_K12);
            #endregion      
            #region L 11    
            Computer_GameMap_Array[11, 0] = new GameBoardField(BTN_GB_L1);
            Computer_GameMap_Array[11, 1] = new GameBoardField(BTN_GB_L2);
            Computer_GameMap_Array[11, 2] = new GameBoardField(BTN_GB_L3);
            Computer_GameMap_Array[11, 3] = new GameBoardField(BTN_GB_L4);
            Computer_GameMap_Array[11, 4] = new GameBoardField(BTN_GB_L5);
            Computer_GameMap_Array[11, 5] = new GameBoardField(BTN_GB_L6);
            Computer_GameMap_Array[11, 6] = new GameBoardField(BTN_GB_L7);
            Computer_GameMap_Array[11, 7] = new GameBoardField(BTN_GB_L8);
            Computer_GameMap_Array[11, 8] = new GameBoardField(BTN_GB_L9);
            Computer_GameMap_Array[11, 9] = new GameBoardField(BTN_GB_L10);
            Computer_GameMap_Array[11, 10] = new GameBoardField(BTN_GB_L11);
            Computer_GameMap_Array[11, 11] = new GameBoardField(BTN_GB_L12);
            #endregion

            if (addMouseOver)
            {
                for (int i = 0; i < 12; i++)
                {
                    for (int x = 0; x < 12; x++)
                    {
                        Computer_GameMap_Array[i, x].fieldButton.MouseEnter += new MouseEventHandler(MouseEnterGameBoardButton);
                        Computer_GameMap_Array[i, x].fieldButton.MouseLeave += new MouseEventHandler(MouseLeaveGameBoardButton);
                    }
                }
            }
        }

        private void FillGameMap_Radar_Array(bool addMouseOver = true)
        {
            #region A
            User_GameMap_Radar_Array[0, 0] = new GameBoardField(BTN_RADARFIELD_GB_A1);
            User_GameMap_Radar_Array[0, 1] = new GameBoardField(BTN_RADARFIELD_GB_A2);
            User_GameMap_Radar_Array[0, 2] = new GameBoardField(BTN_RADARFIELD_GB_A3);
            User_GameMap_Radar_Array[0, 3] = new GameBoardField(BTN_RADARFIELD_GB_A4);
            User_GameMap_Radar_Array[0, 4] = new GameBoardField(BTN_RADARFIELD_GB_A5);
            User_GameMap_Radar_Array[0, 5] = new GameBoardField(BTN_RADARFIELD_GB_A6);
            User_GameMap_Radar_Array[0, 6] = new GameBoardField(BTN_RADARFIELD_GB_A7);
            User_GameMap_Radar_Array[0, 7] = new GameBoardField(BTN_RADARFIELD_GB_A8);
            User_GameMap_Radar_Array[0, 8] = new GameBoardField(BTN_RADARFIELD_GB_A9);
            User_GameMap_Radar_Array[0, 9] = new GameBoardField(BTN_RADARFIELD_GB_A10);
            User_GameMap_Radar_Array[0, 10] = new GameBoardField(BTN_RADARFIELD_GB_A11);
            User_GameMap_Radar_Array[0, 11] = new GameBoardField(BTN_RADARFIELD_GB_A12);
            #endregion      
            #region B       
            User_GameMap_Radar_Array[1, 0] = new GameBoardField(BTN_RADARFIELD_GB_B1);
            User_GameMap_Radar_Array[1, 1] = new GameBoardField(BTN_RADARFIELD_GB_B2);
            User_GameMap_Radar_Array[1, 2] = new GameBoardField(BTN_RADARFIELD_GB_B3);
            User_GameMap_Radar_Array[1, 3] = new GameBoardField(BTN_RADARFIELD_GB_B4);
            User_GameMap_Radar_Array[1, 4] = new GameBoardField(BTN_RADARFIELD_GB_B5);
            User_GameMap_Radar_Array[1, 5] = new GameBoardField(BTN_RADARFIELD_GB_B6);
            User_GameMap_Radar_Array[1, 6] = new GameBoardField(BTN_RADARFIELD_GB_B7);
            User_GameMap_Radar_Array[1, 7] = new GameBoardField(BTN_RADARFIELD_GB_B8);
            User_GameMap_Radar_Array[1, 8] = new GameBoardField(BTN_RADARFIELD_GB_B9);
            User_GameMap_Radar_Array[1, 9] = new GameBoardField(BTN_RADARFIELD_GB_B10);
            User_GameMap_Radar_Array[1, 10] = new GameBoardField(BTN_RADARFIELD_GB_B11);
            User_GameMap_Radar_Array[1, 11] = new GameBoardField(BTN_RADARFIELD_GB_B12);
            #endregion      
            #region C       
            User_GameMap_Radar_Array[2, 0] = new GameBoardField(BTN_RADARFIELD_GB_C1);
            User_GameMap_Radar_Array[2, 1] = new GameBoardField(BTN_RADARFIELD_GB_C2);
            User_GameMap_Radar_Array[2, 2] = new GameBoardField(BTN_RADARFIELD_GB_C3);
            User_GameMap_Radar_Array[2, 3] = new GameBoardField(BTN_RADARFIELD_GB_C4);
            User_GameMap_Radar_Array[2, 4] = new GameBoardField(BTN_RADARFIELD_GB_C5);
            User_GameMap_Radar_Array[2, 5] = new GameBoardField(BTN_RADARFIELD_GB_C6);
            User_GameMap_Radar_Array[2, 6] = new GameBoardField(BTN_RADARFIELD_GB_C7);
            User_GameMap_Radar_Array[2, 7] = new GameBoardField(BTN_RADARFIELD_GB_C8);
            User_GameMap_Radar_Array[2, 8] = new GameBoardField(BTN_RADARFIELD_GB_C9);
            User_GameMap_Radar_Array[2, 9] = new GameBoardField(BTN_RADARFIELD_GB_C10);
            User_GameMap_Radar_Array[2, 10] = new GameBoardField(BTN_RADARFIELD_GB_C11);
            User_GameMap_Radar_Array[2, 11] = new GameBoardField(BTN_RADARFIELD_GB_C12);
            #endregion      
            #region D       
            User_GameMap_Radar_Array[3, 0] = new GameBoardField(BTN_RADARFIELD_GB_D1);
            User_GameMap_Radar_Array[3, 1] = new GameBoardField(BTN_RADARFIELD_GB_D2);
            User_GameMap_Radar_Array[3, 2] = new GameBoardField(BTN_RADARFIELD_GB_D3);
            User_GameMap_Radar_Array[3, 3] = new GameBoardField(BTN_RADARFIELD_GB_D4);
            User_GameMap_Radar_Array[3, 4] = new GameBoardField(BTN_RADARFIELD_GB_D5);
            User_GameMap_Radar_Array[3, 5] = new GameBoardField(BTN_RADARFIELD_GB_D6);
            User_GameMap_Radar_Array[3, 6] = new GameBoardField(BTN_RADARFIELD_GB_D7);
            User_GameMap_Radar_Array[3, 7] = new GameBoardField(BTN_RADARFIELD_GB_D8);
            User_GameMap_Radar_Array[3, 8] = new GameBoardField(BTN_RADARFIELD_GB_D9);
            User_GameMap_Radar_Array[3, 9] = new GameBoardField(BTN_RADARFIELD_GB_D10);
            User_GameMap_Radar_Array[3, 10] = new GameBoardField(BTN_RADARFIELD_GB_D11);
            User_GameMap_Radar_Array[3, 11] = new GameBoardField(BTN_RADARFIELD_GB_D12);
            #endregion      
            #region E 4     
            User_GameMap_Radar_Array[4, 0] = new GameBoardField(BTN_RADARFIELD_GB_E1);
            User_GameMap_Radar_Array[4, 1] = new GameBoardField(BTN_RADARFIELD_GB_E2);
            User_GameMap_Radar_Array[4, 2] = new GameBoardField(BTN_RADARFIELD_GB_E3);
            User_GameMap_Radar_Array[4, 3] = new GameBoardField(BTN_RADARFIELD_GB_E4);
            User_GameMap_Radar_Array[4, 4] = new GameBoardField(BTN_RADARFIELD_GB_E5);
            User_GameMap_Radar_Array[4, 5] = new GameBoardField(BTN_RADARFIELD_GB_E6);
            User_GameMap_Radar_Array[4, 6] = new GameBoardField(BTN_RADARFIELD_GB_E7);
            User_GameMap_Radar_Array[4, 7] = new GameBoardField(BTN_RADARFIELD_GB_E8);
            User_GameMap_Radar_Array[4, 8] = new GameBoardField(BTN_RADARFIELD_GB_E9);
            User_GameMap_Radar_Array[4, 9] = new GameBoardField(BTN_RADARFIELD_GB_E10);
            User_GameMap_Radar_Array[4, 10] = new GameBoardField(BTN_RADARFIELD_GB_E11);
            User_GameMap_Radar_Array[4, 11] = new GameBoardField(BTN_RADARFIELD_GB_E12);
            #endregion      
            #region F 5     
            User_GameMap_Radar_Array[5, 0] = new GameBoardField(BTN_RADARFIELD_GB_F1);
            User_GameMap_Radar_Array[5, 1] = new GameBoardField(BTN_RADARFIELD_GB_F2);
            User_GameMap_Radar_Array[5, 2] = new GameBoardField(BTN_RADARFIELD_GB_F3);
            User_GameMap_Radar_Array[5, 3] = new GameBoardField(BTN_RADARFIELD_GB_F4);
            User_GameMap_Radar_Array[5, 4] = new GameBoardField(BTN_RADARFIELD_GB_F5);
            User_GameMap_Radar_Array[5, 5] = new GameBoardField(BTN_RADARFIELD_GB_F6);
            User_GameMap_Radar_Array[5, 6] = new GameBoardField(BTN_RADARFIELD_GB_F7);
            User_GameMap_Radar_Array[5, 7] = new GameBoardField(BTN_RADARFIELD_GB_F8);
            User_GameMap_Radar_Array[5, 8] = new GameBoardField(BTN_RADARFIELD_GB_F9);
            User_GameMap_Radar_Array[5, 9] = new GameBoardField(BTN_RADARFIELD_GB_F10);
            User_GameMap_Radar_Array[5, 10] = new GameBoardField(BTN_RADARFIELD_GB_F11);
            User_GameMap_Radar_Array[5, 11] = new GameBoardField(BTN_RADARFIELD_GB_F12);
            #endregion      
            #region G 6     
            User_GameMap_Radar_Array[6, 0] = new GameBoardField(BTN_RADARFIELD_GB_G1);
            User_GameMap_Radar_Array[6, 1] = new GameBoardField(BTN_RADARFIELD_GB_G2);
            User_GameMap_Radar_Array[6, 2] = new GameBoardField(BTN_RADARFIELD_GB_G3);
            User_GameMap_Radar_Array[6, 3] = new GameBoardField(BTN_RADARFIELD_GB_G4);
            User_GameMap_Radar_Array[6, 4] = new GameBoardField(BTN_RADARFIELD_GB_G5);
            User_GameMap_Radar_Array[6, 5] = new GameBoardField(BTN_RADARFIELD_GB_G6);
            User_GameMap_Radar_Array[6, 6] = new GameBoardField(BTN_RADARFIELD_GB_G7);
            User_GameMap_Radar_Array[6, 7] = new GameBoardField(BTN_RADARFIELD_GB_G8);
            User_GameMap_Radar_Array[6, 8] = new GameBoardField(BTN_RADARFIELD_GB_G9);
            User_GameMap_Radar_Array[6, 9] = new GameBoardField(BTN_RADARFIELD_GB_G10);
            User_GameMap_Radar_Array[6, 10] = new GameBoardField(BTN_RADARFIELD_GB_G11);
            User_GameMap_Radar_Array[6, 11] = new GameBoardField(BTN_RADARFIELD_GB_G12);
            #endregion      
            #region H 7     
            User_GameMap_Radar_Array[7, 0] = new GameBoardField(BTN_RADARFIELD_GB_H1);
            User_GameMap_Radar_Array[7, 1] = new GameBoardField(BTN_RADARFIELD_GB_H2);
            User_GameMap_Radar_Array[7, 2] = new GameBoardField(BTN_RADARFIELD_GB_H3);
            User_GameMap_Radar_Array[7, 3] = new GameBoardField(BTN_RADARFIELD_GB_H4);
            User_GameMap_Radar_Array[7, 4] = new GameBoardField(BTN_RADARFIELD_GB_H5);
            User_GameMap_Radar_Array[7, 5] = new GameBoardField(BTN_RADARFIELD_GB_H6);
            User_GameMap_Radar_Array[7, 6] = new GameBoardField(BTN_RADARFIELD_GB_H7);
            User_GameMap_Radar_Array[7, 7] = new GameBoardField(BTN_RADARFIELD_GB_H8);
            User_GameMap_Radar_Array[7, 8] = new GameBoardField(BTN_RADARFIELD_GB_H9);
            User_GameMap_Radar_Array[7, 9] = new GameBoardField(BTN_RADARFIELD_GB_H10);
            User_GameMap_Radar_Array[7, 10] = new GameBoardField(BTN_RADARFIELD_GB_H11);
            User_GameMap_Radar_Array[7, 11] = new GameBoardField(BTN_RADARFIELD_GB_H12);
            #endregion      
            #region I 8     
            User_GameMap_Radar_Array[8, 0] = new GameBoardField(BTN_RADARFIELD_GB_I1);
            User_GameMap_Radar_Array[8, 1] = new GameBoardField(BTN_RADARFIELD_GB_I2);
            User_GameMap_Radar_Array[8, 2] = new GameBoardField(BTN_RADARFIELD_GB_I3);
            User_GameMap_Radar_Array[8, 3] = new GameBoardField(BTN_RADARFIELD_GB_I4);
            User_GameMap_Radar_Array[8, 4] = new GameBoardField(BTN_RADARFIELD_GB_I5);
            User_GameMap_Radar_Array[8, 5] = new GameBoardField(BTN_RADARFIELD_GB_I6);
            User_GameMap_Radar_Array[8, 6] = new GameBoardField(BTN_RADARFIELD_GB_I7);
            User_GameMap_Radar_Array[8, 7] = new GameBoardField(BTN_RADARFIELD_GB_I8);
            User_GameMap_Radar_Array[8, 8] = new GameBoardField(BTN_RADARFIELD_GB_I9);
            User_GameMap_Radar_Array[8, 9] = new GameBoardField(BTN_RADARFIELD_GB_I10);
            User_GameMap_Radar_Array[8, 10] = new GameBoardField(BTN_RADARFIELD_GB_I11);
            User_GameMap_Radar_Array[8, 11] = new GameBoardField(BTN_RADARFIELD_GB_I12);
            #endregion      
            #region J 9     
            User_GameMap_Radar_Array[9, 0] = new GameBoardField(BTN_RADARFIELD_GB_J1);
            User_GameMap_Radar_Array[9, 1] = new GameBoardField(BTN_RADARFIELD_GB_J2);
            User_GameMap_Radar_Array[9, 2] = new GameBoardField(BTN_RADARFIELD_GB_J3);
            User_GameMap_Radar_Array[9, 3] = new GameBoardField(BTN_RADARFIELD_GB_J4);
            User_GameMap_Radar_Array[9, 4] = new GameBoardField(BTN_RADARFIELD_GB_J5);
            User_GameMap_Radar_Array[9, 5] = new GameBoardField(BTN_RADARFIELD_GB_J6);
            User_GameMap_Radar_Array[9, 6] = new GameBoardField(BTN_RADARFIELD_GB_J7);
            User_GameMap_Radar_Array[9, 7] = new GameBoardField(BTN_RADARFIELD_GB_J8);
            User_GameMap_Radar_Array[9, 8] = new GameBoardField(BTN_RADARFIELD_GB_J9);
            User_GameMap_Radar_Array[9, 9] = new GameBoardField(BTN_RADARFIELD_GB_J10);
            User_GameMap_Radar_Array[9, 10] = new GameBoardField(BTN_RADARFIELD_GB_J11);
            User_GameMap_Radar_Array[9, 11] = new GameBoardField(BTN_RADARFIELD_GB_J12);
            #endregion      
            #region K 10    
            User_GameMap_Radar_Array[10, 0] = new GameBoardField(BTN_RADARFIELD_GB_K1);
            User_GameMap_Radar_Array[10, 1] = new GameBoardField(BTN_RADARFIELD_GB_K2);
            User_GameMap_Radar_Array[10, 2] = new GameBoardField(BTN_RADARFIELD_GB_K3);
            User_GameMap_Radar_Array[10, 3] = new GameBoardField(BTN_RADARFIELD_GB_K4);
            User_GameMap_Radar_Array[10, 4] = new GameBoardField(BTN_RADARFIELD_GB_K5);
            User_GameMap_Radar_Array[10, 5] = new GameBoardField(BTN_RADARFIELD_GB_K6);
            User_GameMap_Radar_Array[10, 6] = new GameBoardField(BTN_RADARFIELD_GB_K7);
            User_GameMap_Radar_Array[10, 7] = new GameBoardField(BTN_RADARFIELD_GB_K8);
            User_GameMap_Radar_Array[10, 8] = new GameBoardField(BTN_RADARFIELD_GB_K9);
            User_GameMap_Radar_Array[10, 9] = new GameBoardField(BTN_RADARFIELD_GB_K10);
            User_GameMap_Radar_Array[10, 10] = new GameBoardField(BTN_RADARFIELD_GB_K11);
            User_GameMap_Radar_Array[10, 11] = new GameBoardField(BTN_RADARFIELD_GB_K12);
            #endregion      
            #region L 11    
            User_GameMap_Radar_Array[11, 0] = new GameBoardField(BTN_RADARFIELD_GB_L1);
            User_GameMap_Radar_Array[11, 1] = new GameBoardField(BTN_RADARFIELD_GB_L2);
            User_GameMap_Radar_Array[11, 2] = new GameBoardField(BTN_RADARFIELD_GB_L3);
            User_GameMap_Radar_Array[11, 3] = new GameBoardField(BTN_RADARFIELD_GB_L4);
            User_GameMap_Radar_Array[11, 4] = new GameBoardField(BTN_RADARFIELD_GB_L5);
            User_GameMap_Radar_Array[11, 5] = new GameBoardField(BTN_RADARFIELD_GB_L6);
            User_GameMap_Radar_Array[11, 6] = new GameBoardField(BTN_RADARFIELD_GB_L7);
            User_GameMap_Radar_Array[11, 7] = new GameBoardField(BTN_RADARFIELD_GB_L8);
            User_GameMap_Radar_Array[11, 8] = new GameBoardField(BTN_RADARFIELD_GB_L9);
            User_GameMap_Radar_Array[11, 9] = new GameBoardField(BTN_RADARFIELD_GB_L10);
            User_GameMap_Radar_Array[11, 10] = new GameBoardField(BTN_RADARFIELD_GB_L11);
            User_GameMap_Radar_Array[11, 11] = new GameBoardField(BTN_RADARFIELD_GB_L12);
            #endregion

            if (addMouseOver)
            {
                for (int i = 0; i < 12; i++)
                {
                    for (int x = 0; x < 12; x++)
                    {
                        User_GameMap_Radar_Array[i, x].fieldButton.MouseEnter += new MouseEventHandler(MouseEnterGameBoardButton);
                        User_GameMap_Radar_Array[i, x].fieldButton.MouseLeave += new MouseEventHandler(MouseLeaveGameBoardButton);
                    }
                }
            }
        }

        private void SetComputerShips()
        {
            while (Computer_placedCnt_Ship1 < Ship.ship1_Max)
            {
                CreateRndShip(1);
            }
            while (Computer_placedCnt_Ship2 < Ship.ship2_Max)
            {
                CreateRndShip(2);
            }
            while (Computer_placedCnt_Ship3 < Ship.ship3_Max)
            {
                CreateRndShip(3);
            }
            while (Computer_placedCnt_Ship4 < Ship.ship4_Max)
            {
                CreateRndShip(4);
            }
        }

        private void CreateRndShip(int i_shipTyp)
        {
            Ship newShip;
            Random rnd = new Random();
            newShip = new Ship(i_shipTyp, false);
            Const.Nav newNav = GetRandomNav(rnd.Next(5));
            Coords newCoords = new Coords(rnd.Next(0, 12), rnd.Next(0, 12));
            SetShip(newShip, newCoords, newNav, Computer_GameMap_Array);
        }

        private Const.Nav GetRandomNav(int rnd)
        {
            switch(rnd)
            {
                case 0: return Const.Nav.NORTH;
                case 1: return Const.Nav.EAST;
                case 2: return Const.Nav.SOUTH;
                case 3: return Const.Nav.WEST;
                default:return Const.Nav.NORTH;
            }
        }

        private void SetShip(Ship i_ship, Coords buttonCoords, Const.Nav actNav, GameBoardField[,] GameMapArray)
        {
            Coords[] placedCoords = new Coords[i_ship.shipLength];
            if (Coords.ConfirmCoords(actNav, i_ship.shipTyp, buttonCoords, GameMapArray, placedCoords))
            {
                Coords realButtonCoords = new Coords(buttonCoords.yCoord, buttonCoords.xCoord);
                if (Coords.ConfirmBlocks(actNav, i_ship.shipTyp, buttonCoords, GameMapArray))
                {
                    for (int i = 0; i < Ship.GetShipLength(i_ship.shipTyp); i++)
                    {
                        Coords.SetNextCoordsByDirection(actNav, realButtonCoords, i, placedCoords, i_ship, GameMapArray, false);
                    }

                    // SHIP_MARKER
                    switch (i_ship.shipTyp)
                    {
                        case 1:
                            Ship.CheckShipCnt(Computer_Placed_Ship1, placedCoords, Ship.ship1_Max, i_ship.shipTyp, ref Computer_placedCnt_Ship1, GameMapArray, false);
                            break;
                        case 2:
                            Ship.CheckShipCnt(Computer_Placed_Ship2, placedCoords, Ship.ship2_Max, i_ship.shipTyp, ref Computer_placedCnt_Ship2, GameMapArray, false);
                            break;
                        case 3:
                            Ship.CheckShipCnt(Computer_Placed_Ship3, placedCoords, Ship.ship3_Max, i_ship.shipTyp, ref Computer_placedCnt_Ship3, GameMapArray, false);
                            break;
                        case 4:
                            Ship.CheckShipCnt(Computer_Placed_Ship4, placedCoords, Ship.ship4_Max, i_ship.shipTyp, ref Computer_placedCnt_Ship4, GameMapArray, false);
                            break;
                        default: break;
                    }
                }
            }
        }

        #endregion

        #region Visualization -------------------------------------------------------------------------------------------------------------------------------------------------------------------
        private void MouseEnterGameBoardButton(object sender, RoutedEventArgs e)
        {
            string actGameMode = "AttackMode";
            bool isMainfield = ((Button)sender).Name.Substring(0, 9) == "BTN_RADARFIELD_GB_".Substring(0, 9) ? false : true;
            string btnTyp = isMainfield ? "Mainfield" : "Radarfield";

            Coords buttonCoords = Coords.GetBtnCoords(((Button)sender).Uid);

            if (isMainfield)
            {
                if (/*Computer_GameMap_Array[buttonCoords.yCoord, buttonCoords.xCoord].fieldState != Const.FieldState.SHIP &&*/
                    Computer_GameMap_Array[buttonCoords.yCoord, buttonCoords.xCoord].fieldState != Const.FieldState.MISS      &&
                    Computer_GameMap_Array[buttonCoords.yCoord, buttonCoords.xCoord].fieldState != Const.FieldState.HIT       &&
                    Computer_GameMap_Array[buttonCoords.yCoord, buttonCoords.xCoord].fieldState != Const.FieldState.SUNKENSHIP  )
                {
                    Computer_GameMap_Array[buttonCoords.yCoord, buttonCoords.xCoord].fieldButton.Style = (Style)Application.Current.Resources["GB_" + actGameMode + "_" + btnTyp + "_MouseOver_Button"];
                }
            }
            else
            {
                if (User_GameMap_Radar_Array[buttonCoords.yCoord, buttonCoords.xCoord].fieldState == Const.FieldState.SHIP      ||
                    User_GameMap_Radar_Array[buttonCoords.yCoord, buttonCoords.xCoord].fieldState == Const.FieldState.HIT       ||
                    User_GameMap_Radar_Array[buttonCoords.yCoord, buttonCoords.xCoord].fieldState == Const.FieldState.SUNKENSHIP  )
                {
                    Ship ship = User_GameMap_Radar_Array[buttonCoords.yCoord, buttonCoords.xCoord].ship;
                    LBL_oType.Content = Convert.ToString(ship.shipTyp);
                    LBL_oLength.Content = Convert.ToString(ship.shipLength);
                    LBL_oHealth.Content = Convert.ToString(ship.shipHealth * 100 / ship.shipLength) + " %";
                    if (User_GameMap_Radar_Array[buttonCoords.yCoord, buttonCoords.xCoord].fieldState == Const.FieldState.SUNKENSHIP)
                    {
                        Mouse.OverrideCursor = ((TextBlock)Application.Current.Resources["SW_PLACE_SUNKEN_SHIP_INFO_CURSOR"]).Cursor;
                    } else
                    {
                        Mouse.OverrideCursor = ((TextBlock)Application.Current.Resources["SW_PLACE_SHIP_INFO_CURSOR"]).Cursor;
                    }

                }
                else if (User_GameMap_Radar_Array[buttonCoords.yCoord, buttonCoords.xCoord].fieldState != Const.FieldState.MISS)
                {
                    User_GameMap_Radar_Array[buttonCoords.yCoord, buttonCoords.xCoord].fieldButton.Style = (Style)Application.Current.Resources["GB_" + actGameMode + "_" + btnTyp + "_MouseOver_Button"];
                }
            }
        }

        private void MouseLeaveGameBoardButton(object sender, RoutedEventArgs e)
        {
            string actGameMode = "AttackMode";
            bool isMainfield = ((Button)sender).Name.Substring(0, 9) == "BTN_RADARFIELD_GB_".Substring(0, 9) ? false : true;
            string btnTyp = isMainfield ? "Mainfield" : "Radarfield";


            Coords buttonCoords = Coords.GetBtnCoords(((Button)sender).Uid);

            if (isMainfield)
            {
                if (/*Computer_GameMap_Array[buttonCoords.yCoord, buttonCoords.xCoord].fieldState != Const.FieldState.SHIP &&*/
                    Computer_GameMap_Array[buttonCoords.yCoord, buttonCoords.xCoord].fieldState != Const.FieldState.MISS      &&
                    Computer_GameMap_Array[buttonCoords.yCoord, buttonCoords.xCoord].fieldState != Const.FieldState.HIT       &&
                    Computer_GameMap_Array[buttonCoords.yCoord, buttonCoords.xCoord].fieldState != Const.FieldState.SUNKENSHIP  )
                {
                    Computer_GameMap_Array[buttonCoords.yCoord, buttonCoords.xCoord].fieldButton.Style = (Style)Application.Current.Resources["GB_" + actGameMode + "_" + btnTyp + "_Default_Button"];
                }
            }
            else
            {
                if (User_GameMap_Radar_Array[buttonCoords.yCoord, buttonCoords.xCoord].fieldState == Const.FieldState.SHIP      ||
                    User_GameMap_Radar_Array[buttonCoords.yCoord, buttonCoords.xCoord].fieldState == Const.FieldState.HIT       ||
                    User_GameMap_Radar_Array[buttonCoords.yCoord, buttonCoords.xCoord].fieldState == Const.FieldState.SUNKENSHIP  )
                {
                    LBL_oType.Content = " - ";
                    LBL_oLength.Content = " - ";
                    LBL_oHealth.Content = " - %";
                    Mouse.OverrideCursor = ((TextBlock)Application.Current.Resources["SW_STD_CURSOR"]).Cursor;
                }
                else if (User_GameMap_Radar_Array[buttonCoords.yCoord, buttonCoords.xCoord].fieldState != Const.FieldState.MISS)
                {
                    User_GameMap_Radar_Array[buttonCoords.yCoord, buttonCoords.xCoord].fieldButton.Style = (Style)Application.Current.Resources["GB_" + actGameMode + "_" + btnTyp + "_Default_Button"];
                }
            }
        }

        #endregion

        private void BTN_GB_Clicked(object sender, RoutedEventArgs e)
        {
            Random rnd = new Random();
            Coords rndCoords = new Coords(-1,-1);
            CheckIfShipHit(Coords.GetBtnCoords(((Button)sender).Uid), true);
            do
            {
                rndCoords = new Coords(-1,-1);
                if(CheckCCI_Coords)
                {
                    for(int i = 0; i < 4; i++)
                    {
                        if (CciCoords.cciCoords[i].CoordIs != Const.FieldState.CCI_OLD_HIT)
                        {
                            if (CciCoords.cciCoords[i].CoordIs != Const.FieldState.MISS)
                            {
                                if (CciCoords.cciCoords[i].CoordIs != Const.FieldState.HIT)
                                {
                                    Coords.CopyCoords(rndCoords,CciCoords.cciCoords[i].cciCoords);
                                }
                                else
                                {
                                    Coords middleCoords = CciCoords.cciCoords[i].cciCoords;
                                    int oldCoordIdx = i - 2 < 0 ? i + 2 : i - 2;
                                    CciCoords = new ComputerCoordsIntelligence(middleCoords, User_GameMap_Radar_Array);
                                    Coords oldmiddleCoords = CciCoords.cciCoords[oldCoordIdx].cciCoords;
                                    CciCoords.SetCCI_CoordsFieldState(CciCoords, oldmiddleCoords, Const.FieldState.CCI_OLD_HIT);
                                    for (int x = 0; x < 4; x++)
                                    {
                                        if (CciCoords.cciCoords[x].CoordIs == Const.FieldState.CCI_OLD_HIT)
                                        {
                                            int nextCoordIndex = x + 2 >= 4 ? x - 2 : x + 2;
                                            Coords.CopyCoords(rndCoords,CciCoords.cciCoords[nextCoordIndex].cciCoords);
                                            oldHitGuess = true;
                                            break;
                                        }
                                    }
                                }
                                break;
                            } else
                            {
                                if(oldHitGuess)
                                {
                                    int newMiddleCoords = i + 2 >= 4 ? i - 2 : i + 2;
                                    Coords middleCoords = CciCoords.cciCoords[newMiddleCoords].cciCoords;
                                    CciCoords = new ComputerCoordsIntelligence(middleCoords, User_GameMap_Radar_Array);
                                    for(int x = 0; x < 4; x++)
                                    {
                                        if (CciCoords.cciCoords[x].CoordIs == Const.FieldState.HIT)
                                        {
                                            CciCoords.cciCoords[x].CoordIs = Const.FieldState.CCI_OLD_HIT;
                                            i = x + 2 >= 4 ? x - 2 : x + 2;
                                            i -= 1;
                                            break;
                                        }
                                    }

                                    
                                }
                            }
                        } else
                        {
                            CciCoords = new ComputerCoordsIntelligence(CciCoords.cciCoords[i].cciCoords, User_GameMap_Radar_Array);
                            for (int x = 0; x < 4; x++)
                            {
                                if (CciCoords.cciCoords[x].CoordIs == Const.FieldState.CCI_OLD_HIT)
                                {
                                    int nextCoordIndex = x + 2 >= 4 ? x - 2 : x + 2;
                                    Coords.CopyCoords(rndCoords, CciCoords.cciCoords[i].cciCoords);
                                    break;
                                }
                            }
                        }
                    }
                }
                if (Coords.CompareCoords(rndCoords, new Coords(-1,-1)))
                {
                    rndCoords = new Coords(rnd.Next(0, 12), rnd.Next(0, 12));
                    CheckCCI_Coords = false;
                }
            } while (CheckIfComputerAlreadyChoose(rndCoords));

                CheckIfShipHit(rndCoords, false);
        }

        private bool CheckIfComputerAlreadyChoose(Coords i_Coords)
        {
            foreach(Coords alreadyStrike in Computer_Strike_Coords)
            {
                if(Coords.CompareCoords(alreadyStrike, i_Coords))
                {
                    i_Coords = null;
                    return true;
                }                
            }

            Computer_Strike_Coords.Add(i_Coords);
            return false;
        }

        private void CheckIfShipHit(Coords i_HitCoords, bool playersTurn)
        {
            if(playersTurn)
            {
                if (Computer_GameMap_Array[i_HitCoords.yCoord, i_HitCoords.xCoord].fieldState == Const.FieldState.SHIP)
                {
                    Computer_GameMap_Array[i_HitCoords.yCoord, i_HitCoords.xCoord].fieldButton.Style = (Style)Application.Current.Resources["GB_AttackMode_Mainfield_ShipHit_Button"];
                    Computer_GameMap_Array[i_HitCoords.yCoord, i_HitCoords.xCoord].fieldState = Const.FieldState.HIT;
                    Computer_GameMap_Array[i_HitCoords.yCoord, i_HitCoords.xCoord].ship.shipHealth = CalcNewShipHealth(Computer_GameMap_Array[i_HitCoords.yCoord, i_HitCoords.xCoord].ship.shipHealth);
                    if (Computer_GameMap_Array[i_HitCoords.yCoord, i_HitCoords.xCoord].ship.shipHealth == 0)
                    {
                        SetSunkenShip(i_HitCoords, playersTurn);
                    }


                } else
                {
                    Computer_GameMap_Array[i_HitCoords.yCoord, i_HitCoords.xCoord].fieldButton.Style = (Style)Application.Current.Resources["GB_AttackMode_Mainfield_WaterHit_Button"];
                    Computer_GameMap_Array[i_HitCoords.yCoord, i_HitCoords.xCoord].fieldState = Const.FieldState.MISS;
                }
            } else
            {
                if (User_GameMap_Radar_Array[i_HitCoords.yCoord, i_HitCoords.xCoord].fieldState == Const.FieldState.SHIP)
                {
                    if (!CheckCCI_Coords)
                    {
                        CciCoords = new ComputerCoordsIntelligence(i_HitCoords, User_GameMap_Radar_Array);
                        CheckCCI_Coords = true;
                    }
               
                    User_GameMap_Radar_Array[i_HitCoords.yCoord, i_HitCoords.xCoord].fieldButton.Style = (Style)Application.Current.Resources["GB_AttackMode_Radarfield_ShipHit_Button"];
                    User_GameMap_Radar_Array[i_HitCoords.yCoord, i_HitCoords.xCoord].fieldState = Const.FieldState.HIT;
                    User_GameMap_Radar_Array[i_HitCoords.yCoord, i_HitCoords.xCoord].ship.shipHealth = CalcNewShipHealth(User_GameMap_Radar_Array[i_HitCoords.yCoord, i_HitCoords.xCoord].ship.shipHealth);
                    if (User_GameMap_Radar_Array[i_HitCoords.yCoord, i_HitCoords.xCoord].ship.shipHealth == 0)
                    {
                        SetSunkenShip(i_HitCoords, playersTurn);
                    }
                    if (CheckCCI_Coords)
                    {
                        CciCoords.SetCCI_CoordsFieldState(CciCoords, i_HitCoords, Const.FieldState.HIT);
                    }
                }
                else
                {
                    User_GameMap_Radar_Array[i_HitCoords.yCoord, i_HitCoords.xCoord].fieldButton.Style = (Style)Application.Current.Resources["GB_AttackMode_Radarfield_WaterHit_Button"];
                    User_GameMap_Radar_Array[i_HitCoords.yCoord, i_HitCoords.xCoord].fieldState = Const.FieldState.MISS;
                    if (CheckCCI_Coords)
                    {
                        CciCoords.SetCCI_CoordsFieldState(CciCoords, i_HitCoords, Const.FieldState.MISS);
                    }
                }
            }
        }

        private void SetSunkenShip(Coords i_HitCoords, bool playersTurn)
        {
            List<List<PlacedShips>> allPlacedShips = new List<List<PlacedShips>>();
            GetAllPlacedShipsLists(allPlacedShips, playersTurn);
            bool breakAfterChange = false;

            foreach (List<PlacedShips> placedShipsList in allPlacedShips)
            {
                foreach (PlacedShips placedShip in placedShipsList)
                {
                    foreach (Coords CoordsPart in placedShip.shipCoords)
                    {
                        if (Coords.CompareCoords(CoordsPart, i_HitCoords))
                        {
                            //We found the ship which was hit
                            for (int i = 0; i < placedShip.shipCoords.Length; i++)
                            {
                                if (!playersTurn)
                                {
                                    User_GameMap_Radar_Array[placedShip.shipCoords[i].yCoord, placedShip.shipCoords[i].xCoord].fieldButton.Style =
                                            (Style)Application.Current.Resources["GB_AttackMode_Radarfield_SunkenShip_Button"];
                                    User_GameMap_Radar_Array[placedShip.shipCoords[i].yCoord, placedShip.shipCoords[i].xCoord].fieldState = Const.FieldState.SUNKENSHIP;
                                }
                                else
                                {
                                    Computer_GameMap_Array[placedShip.shipCoords[i].yCoord, placedShip.shipCoords[i].xCoord].fieldButton.Style =
                                        (Style)Application.Current.Resources["GB_AttackMode_Mainfield_SunkenShip_Button"];
                                    Computer_GameMap_Array[placedShip.shipCoords[i].yCoord, placedShip.shipCoords[i].xCoord].fieldState = Const.FieldState.SUNKENSHIP;
                                }
                            }
                            breakAfterChange = true;
                        }
                    }
                    if (breakAfterChange) { break; }
                }
                if (breakAfterChange) { break; }
            }
        }

        private int CalcNewShipHealth(int shipHealth)
        {
            return (shipHealth - 1);
        }

        private void GetAllPlacedShipsLists(List<List<PlacedShips>> i_List, bool playersTurn)
        {
            i_List.Clear();
            if(!playersTurn)
            {
                i_List.Add(User_Placed_Ship1);
                i_List.Add(User_Placed_Ship2);
                i_List.Add(User_Placed_Ship3);
                i_List.Add(User_Placed_Ship4);
            } else
            {
                i_List.Add(Computer_Placed_Ship1);
                i_List.Add(Computer_Placed_Ship2);
                i_List.Add(Computer_Placed_Ship3);
                i_List.Add(Computer_Placed_Ship4);
            }
        }

        private void BTN_GoBack_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BTN_StartAttack_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
