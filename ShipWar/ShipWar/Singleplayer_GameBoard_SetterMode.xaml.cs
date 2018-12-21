using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Resources;

namespace ShipWar
{
    /// <summary>
    /// Interaktionslogik für Singleplayer_GameBoard.xaml
    /// </summary>
    public partial class Singleplayer_GameBoard_SetterMode : UserControl
    {
        // Gloabal Values
        MainWindow SW_mainWindow;
        Player GamePlayer;
        System.Windows.Forms.Timer timer1;

        // Ship Values
        // SHIP_MARKER
        private int SelectedShip = 0;
        public Button[] Ship_Button = new Button[4];
        public int placedCnt_Ship1 = 0;
        public int placedCnt_Ship2 = 0;
        public int placedCnt_Ship3 = 0;
        public int placedCnt_Ship4 = 0;
        List<PlacedShips> Placed_Ship1 = new List<PlacedShips>();
        List<PlacedShips> Placed_Ship2 = new List<PlacedShips>();
        List<PlacedShips> Placed_Ship3 = new List<PlacedShips>();
        List<PlacedShips> Placed_Ship4 = new List<PlacedShips>();
        Image[] RedLights_Ship1 = new Image[Ship.ship1_Max];
        Image[] RedLights_Ship2 = new Image[Ship.ship2_Max];
        Image[] RedLights_Ship3 = new Image[Ship.ship3_Max];
        Image[] RedLights_Ship4 = new Image[Ship.ship4_Max];
        //public PlacedShips placedShips;

        // Game Modes
        private string ActGameMode;
        private const string SetterMode = "SetterMode";
        private const string AttackMode = "AttackMode";

        // Game Board Values
        private int actRadar = 1;
        private Const.Nav actNav = Const.Nav.NORTH;
        private bool DumpSelected = false;
        GameBoardField[,] GameMapArray = new GameBoardField[12, 12];
        GameBoardField[,] GameMap_Radar_Array = new GameBoardField[12, 12];


        public Singleplayer_GameBoard_SetterMode(MainWindow i_mainWindow, Player i_player)
        {
            InitializeComponent();
            SW_mainWindow = i_mainWindow;
            GamePlayer = i_player;
            
            timer1 = new System.Windows.Forms.Timer();
            timer1.Interval = 1000;
            timer1.Tick += new EventHandler(TurnRadar);
            timer1.Start();

        }

        private void TurnRadar(object sender, EventArgs e)
        {
            IMG_Radar.Source = (ImageSource)Application.Current.Resources["INST_Radar_" + Convert.ToString(actRadar)];
            if (actRadar == 18)
            {
                actRadar = 1;
            } else
            {
                actRadar += 1;
            }
        }

        public void Singleplayer_GameBoard_SetterMode_Loaded(object sender, RoutedEventArgs e)
        {
            FillGameBoard_Info();
            FillGameMapArray();
            FillRedLights();
            ActGameMode = SetterMode;
            // SHIP_MARKER
            Ship_Button[0] = BTN_Ship1;
            Ship_Button[1] = BTN_Ship2;            
            Ship_Button[2] = BTN_Ship3;
            Ship_Button[3] = BTN_Ship4;
        }

        #region Fill Functions ------------------------------------------------------------------------------------------------------------------------------------------------------------------
        private void FillGameBoard_Info()
        {
            LBL_oPlayerNumber.Content = Convert.ToString(GamePlayer.playerId);
            LBL_oPlayerName.Content = GamePlayer.playerName;
            LBL_oPlayerTotalPoints.Content = Convert.ToString(GamePlayer.playerPoints);
        }

        private void FillRedLights()
        {
            RedLights_Ship1[0] = IMG_Ship1Cnt1;
            RedLights_Ship1[1] = IMG_Ship1Cnt2;
            RedLights_Ship1[2] = IMG_Ship1Cnt3;

            RedLights_Ship2[0] = IMG_Ship2Cnt1;
            RedLights_Ship2[1] = IMG_Ship2Cnt2;

            RedLights_Ship3[0] = IMG_Ship3Cnt1;

            RedLights_Ship4[0] = IMG_Ship4Cnt1;
            RedLights_Ship4[1] = IMG_Ship4Cnt2;
        }

        private void FillGameMapArray(bool addMouseOver = true)
        {
            #region A
            GameMapArray[0, 0] = new GameBoardField(BTN_GB_A1);
            GameMapArray[0, 1] = new GameBoardField(BTN_GB_A2);
            GameMapArray[0, 2] = new GameBoardField(BTN_GB_A3);
            GameMapArray[0, 3] = new GameBoardField(BTN_GB_A4);
            GameMapArray[0, 4] = new GameBoardField(BTN_GB_A5);
            GameMapArray[0, 5] = new GameBoardField(BTN_GB_A6);
            GameMapArray[0, 6] = new GameBoardField(BTN_GB_A7);
            GameMapArray[0, 7] = new GameBoardField(BTN_GB_A8);
            GameMapArray[0, 8] = new GameBoardField(BTN_GB_A9);
            GameMapArray[0, 9] = new GameBoardField(BTN_GB_A10);
            GameMapArray[0, 10] = new GameBoardField(BTN_GB_A11);
            GameMapArray[0, 11] = new GameBoardField(BTN_GB_A12);
            #endregion
            #region B
            GameMapArray[1, 0] = new GameBoardField(BTN_GB_B1);
            GameMapArray[1, 1] = new GameBoardField(BTN_GB_B2);
            GameMapArray[1, 2] = new GameBoardField(BTN_GB_B3);
            GameMapArray[1, 3] = new GameBoardField(BTN_GB_B4);
            GameMapArray[1, 4] = new GameBoardField(BTN_GB_B5);
            GameMapArray[1, 5] = new GameBoardField(BTN_GB_B6);
            GameMapArray[1, 6] = new GameBoardField(BTN_GB_B7);
            GameMapArray[1, 7] = new GameBoardField(BTN_GB_B8);
            GameMapArray[1, 8] = new GameBoardField(BTN_GB_B9);
            GameMapArray[1, 9] = new GameBoardField(BTN_GB_B10);
            GameMapArray[1, 10] = new GameBoardField(BTN_GB_B11);
            GameMapArray[1, 11] = new GameBoardField(BTN_GB_B12);
            #endregion
            #region C
            GameMapArray[2, 0] = new GameBoardField(BTN_GB_C1);
            GameMapArray[2, 1] = new GameBoardField(BTN_GB_C2);
            GameMapArray[2, 2] = new GameBoardField(BTN_GB_C3);
            GameMapArray[2, 3] = new GameBoardField(BTN_GB_C4);
            GameMapArray[2, 4] = new GameBoardField(BTN_GB_C5);
            GameMapArray[2, 5] = new GameBoardField(BTN_GB_C6);
            GameMapArray[2, 6] = new GameBoardField(BTN_GB_C7);
            GameMapArray[2, 7] = new GameBoardField(BTN_GB_C8);
            GameMapArray[2, 8] = new GameBoardField(BTN_GB_C9);
            GameMapArray[2, 9] = new GameBoardField(BTN_GB_C10);
            GameMapArray[2, 10] = new GameBoardField(BTN_GB_C11);
            GameMapArray[2, 11] = new GameBoardField(BTN_GB_C12);
            #endregion
            #region D
            GameMapArray[3, 0] = new GameBoardField(BTN_GB_D1);
            GameMapArray[3, 1] = new GameBoardField(BTN_GB_D2);
            GameMapArray[3, 2] = new GameBoardField(BTN_GB_D3);
            GameMapArray[3, 3] = new GameBoardField(BTN_GB_D4);
            GameMapArray[3, 4] = new GameBoardField(BTN_GB_D5);
            GameMapArray[3, 5] = new GameBoardField(BTN_GB_D6);
            GameMapArray[3, 6] = new GameBoardField(BTN_GB_D7);
            GameMapArray[3, 7] = new GameBoardField(BTN_GB_D8);
            GameMapArray[3, 8] = new GameBoardField(BTN_GB_D9);
            GameMapArray[3, 9] = new GameBoardField(BTN_GB_D10);
            GameMapArray[3, 10] = new GameBoardField(BTN_GB_D11);
            GameMapArray[3, 11] = new GameBoardField(BTN_GB_D12);
            #endregion
            #region E 4
            GameMapArray[4, 0] = new GameBoardField(BTN_GB_E1);
            GameMapArray[4, 1] = new GameBoardField(BTN_GB_E2);
            GameMapArray[4, 2] = new GameBoardField(BTN_GB_E3);
            GameMapArray[4, 3] = new GameBoardField(BTN_GB_E4);
            GameMapArray[4, 4] = new GameBoardField(BTN_GB_E5);
            GameMapArray[4, 5] = new GameBoardField(BTN_GB_E6);
            GameMapArray[4, 6] = new GameBoardField(BTN_GB_E7);
            GameMapArray[4, 7] = new GameBoardField(BTN_GB_E8);
            GameMapArray[4, 8] = new GameBoardField(BTN_GB_E9);
            GameMapArray[4, 9] = new GameBoardField(BTN_GB_E10);
            GameMapArray[4, 10] = new GameBoardField(BTN_GB_E11);
            GameMapArray[4, 11] = new GameBoardField(BTN_GB_E12);
            #endregion
            #region F 5
            GameMapArray[5, 0] = new GameBoardField(BTN_GB_F1);
            GameMapArray[5, 1] = new GameBoardField(BTN_GB_F2);
            GameMapArray[5, 2] = new GameBoardField(BTN_GB_F3);
            GameMapArray[5, 3] = new GameBoardField(BTN_GB_F4);
            GameMapArray[5, 4] = new GameBoardField(BTN_GB_F5);
            GameMapArray[5, 5] = new GameBoardField(BTN_GB_F6);
            GameMapArray[5, 6] = new GameBoardField(BTN_GB_F7);
            GameMapArray[5, 7] = new GameBoardField(BTN_GB_F8);
            GameMapArray[5, 8] = new GameBoardField(BTN_GB_F9);
            GameMapArray[5, 9] = new GameBoardField(BTN_GB_F10);
            GameMapArray[5, 10] = new GameBoardField(BTN_GB_F11);
            GameMapArray[5, 11] = new GameBoardField(BTN_GB_F12);
            #endregion
            #region G 6
            GameMapArray[6, 0] = new GameBoardField(BTN_GB_G1);
            GameMapArray[6, 1] = new GameBoardField(BTN_GB_G2);
            GameMapArray[6, 2] = new GameBoardField(BTN_GB_G3);
            GameMapArray[6, 3] = new GameBoardField(BTN_GB_G4);
            GameMapArray[6, 4] = new GameBoardField(BTN_GB_G5);
            GameMapArray[6, 5] = new GameBoardField(BTN_GB_G6);
            GameMapArray[6, 6] = new GameBoardField(BTN_GB_G7);
            GameMapArray[6, 7] = new GameBoardField(BTN_GB_G8);
            GameMapArray[6, 8] = new GameBoardField(BTN_GB_G9);
            GameMapArray[6, 9] = new GameBoardField(BTN_GB_G10);
            GameMapArray[6, 10] = new GameBoardField(BTN_GB_G11);
            GameMapArray[6, 11] = new GameBoardField(BTN_GB_G12);
            #endregion
            #region H 7
            GameMapArray[7, 0] = new GameBoardField(BTN_GB_H1);
            GameMapArray[7, 1] = new GameBoardField(BTN_GB_H2);
            GameMapArray[7, 2] = new GameBoardField(BTN_GB_H3);
            GameMapArray[7, 3] = new GameBoardField(BTN_GB_H4);
            GameMapArray[7, 4] = new GameBoardField(BTN_GB_H5);
            GameMapArray[7, 5] = new GameBoardField(BTN_GB_H6);
            GameMapArray[7, 6] = new GameBoardField(BTN_GB_H7);
            GameMapArray[7, 7] = new GameBoardField(BTN_GB_H8);
            GameMapArray[7, 8] = new GameBoardField(BTN_GB_H9);
            GameMapArray[7, 9] = new GameBoardField(BTN_GB_H10);
            GameMapArray[7, 10] = new GameBoardField(BTN_GB_H11);
            GameMapArray[7, 11] = new GameBoardField(BTN_GB_H12);
            #endregion
            #region I 8
            GameMapArray[8, 0] = new GameBoardField(BTN_GB_I1);
            GameMapArray[8, 1] = new GameBoardField(BTN_GB_I2);
            GameMapArray[8, 2] = new GameBoardField(BTN_GB_I3);
            GameMapArray[8, 3] = new GameBoardField(BTN_GB_I4);
            GameMapArray[8, 4] = new GameBoardField(BTN_GB_I5);
            GameMapArray[8, 5] = new GameBoardField(BTN_GB_I6);
            GameMapArray[8, 6] = new GameBoardField(BTN_GB_I7);
            GameMapArray[8, 7] = new GameBoardField(BTN_GB_I8);
            GameMapArray[8, 8] = new GameBoardField(BTN_GB_I9);
            GameMapArray[8, 9] = new GameBoardField(BTN_GB_I10);
            GameMapArray[8, 10] = new GameBoardField(BTN_GB_I11);
            GameMapArray[8, 11] = new GameBoardField(BTN_GB_I12);
            #endregion
            #region J 9
            GameMapArray[9, 0] = new GameBoardField(BTN_GB_J1);
            GameMapArray[9, 1] = new GameBoardField(BTN_GB_J2);
            GameMapArray[9, 2] = new GameBoardField(BTN_GB_J3);
            GameMapArray[9, 3] = new GameBoardField(BTN_GB_J4);
            GameMapArray[9, 4] = new GameBoardField(BTN_GB_J5);
            GameMapArray[9, 5] = new GameBoardField(BTN_GB_J6);
            GameMapArray[9, 6] = new GameBoardField(BTN_GB_J7);
            GameMapArray[9, 7] = new GameBoardField(BTN_GB_J8);
            GameMapArray[9, 8] = new GameBoardField(BTN_GB_J9);
            GameMapArray[9, 9] = new GameBoardField(BTN_GB_J10);
            GameMapArray[9, 10] = new GameBoardField(BTN_GB_J11);
            GameMapArray[9, 11] = new GameBoardField(BTN_GB_J12);
            #endregion
            #region K 10
            GameMapArray[10, 0] = new GameBoardField(BTN_GB_K1);
            GameMapArray[10, 1] = new GameBoardField(BTN_GB_K2);
            GameMapArray[10, 2] = new GameBoardField(BTN_GB_K3);
            GameMapArray[10, 3] = new GameBoardField(BTN_GB_K4);
            GameMapArray[10, 4] = new GameBoardField(BTN_GB_K5);
            GameMapArray[10, 5] = new GameBoardField(BTN_GB_K6);
            GameMapArray[10, 6] = new GameBoardField(BTN_GB_K7);
            GameMapArray[10, 7] = new GameBoardField(BTN_GB_K8);
            GameMapArray[10, 8] = new GameBoardField(BTN_GB_K9);
            GameMapArray[10, 9] = new GameBoardField(BTN_GB_K10);
            GameMapArray[10, 10] = new GameBoardField(BTN_GB_K11);
            GameMapArray[10, 11] = new GameBoardField(BTN_GB_K12);
            #endregion
            #region L 11
            GameMapArray[11, 0] = new GameBoardField(BTN_GB_L1);
            GameMapArray[11, 1] = new GameBoardField(BTN_GB_L2);
            GameMapArray[11, 2] = new GameBoardField(BTN_GB_L3);
            GameMapArray[11, 3] = new GameBoardField(BTN_GB_L4);
            GameMapArray[11, 4] = new GameBoardField(BTN_GB_L5);
            GameMapArray[11, 5] = new GameBoardField(BTN_GB_L6);
            GameMapArray[11, 6] = new GameBoardField(BTN_GB_L7);
            GameMapArray[11, 7] = new GameBoardField(BTN_GB_L8);
            GameMapArray[11, 8] = new GameBoardField(BTN_GB_L9);
            GameMapArray[11, 9] = new GameBoardField(BTN_GB_L10);
            GameMapArray[11, 10] = new GameBoardField(BTN_GB_L11);
            GameMapArray[11, 11] = new GameBoardField(BTN_GB_L12);
            #endregion

            if (addMouseOver)
            {
                for (int i = 0; i < 12; i++)
                {
                    for (int x = 0; x < 12; x++)
                    {
                        GameMapArray[i, x].fieldButton.MouseEnter += new MouseEventHandler(MouseEnterGameBoardButton);
                        GameMapArray[i, x].fieldButton.MouseLeave += new MouseEventHandler(MouseLeaveGameBoardButton);
                        GameMapArray[i, x].fieldButton.MouseWheel += new MouseWheelEventHandler(MouseWheelGameBoardButton);
                    }
                }
            }
        }

        private void FillGameMap_Attack_Array(bool addMouseOver = true)
        {
            #region A
            GameMap_Radar_Array[0, 0] =  new GameBoardField(BTN_RADARFIELD_GB_A1);
            GameMap_Radar_Array[0, 1] =  new GameBoardField(BTN_RADARFIELD_GB_A2);
            GameMap_Radar_Array[0, 2] =  new GameBoardField(BTN_RADARFIELD_GB_A3);
            GameMap_Radar_Array[0, 3] =  new GameBoardField(BTN_RADARFIELD_GB_A4);
            GameMap_Radar_Array[0, 4] =  new GameBoardField(BTN_RADARFIELD_GB_A5);
            GameMap_Radar_Array[0, 5] =  new GameBoardField(BTN_RADARFIELD_GB_A6);
            GameMap_Radar_Array[0, 6] =  new GameBoardField(BTN_RADARFIELD_GB_A7);
            GameMap_Radar_Array[0, 7] =  new GameBoardField(BTN_RADARFIELD_GB_A8);
            GameMap_Radar_Array[0, 8] =  new GameBoardField(BTN_RADARFIELD_GB_A9);
            GameMap_Radar_Array[0, 9] =  new GameBoardField(BTN_RADARFIELD_GB_A10);
            GameMap_Radar_Array[0, 10] = new GameBoardField(BTN_RADARFIELD_GB_A11);
            GameMap_Radar_Array[0, 11] = new GameBoardField(BTN_RADARFIELD_GB_A12);
            #endregion
            #region B
            GameMap_Radar_Array[1, 0] =  new GameBoardField(BTN_RADARFIELD_GB_B1);
            GameMap_Radar_Array[1, 1] =  new GameBoardField(BTN_RADARFIELD_GB_B2);
            GameMap_Radar_Array[1, 2] =  new GameBoardField(BTN_RADARFIELD_GB_B3);
            GameMap_Radar_Array[1, 3] =  new GameBoardField(BTN_RADARFIELD_GB_B4);
            GameMap_Radar_Array[1, 4] =  new GameBoardField(BTN_RADARFIELD_GB_B5);
            GameMap_Radar_Array[1, 5] =  new GameBoardField(BTN_RADARFIELD_GB_B6);
            GameMap_Radar_Array[1, 6] =  new GameBoardField(BTN_RADARFIELD_GB_B7);
            GameMap_Radar_Array[1, 7] =  new GameBoardField(BTN_RADARFIELD_GB_B8);
            GameMap_Radar_Array[1, 8] =  new GameBoardField(BTN_RADARFIELD_GB_B9);
            GameMap_Radar_Array[1, 9] =  new GameBoardField(BTN_RADARFIELD_GB_B10);
            GameMap_Radar_Array[1, 10] = new GameBoardField(BTN_RADARFIELD_GB_B11);
            GameMap_Radar_Array[1, 11] = new GameBoardField(BTN_RADARFIELD_GB_B12);
            #endregion
            #region C
            GameMap_Radar_Array[2, 0] =  new GameBoardField(BTN_RADARFIELD_GB_C1);
            GameMap_Radar_Array[2, 1] =  new GameBoardField(BTN_RADARFIELD_GB_C2);
            GameMap_Radar_Array[2, 2] =  new GameBoardField(BTN_RADARFIELD_GB_C3);
            GameMap_Radar_Array[2, 3] =  new GameBoardField(BTN_RADARFIELD_GB_C4);
            GameMap_Radar_Array[2, 4] =  new GameBoardField(BTN_RADARFIELD_GB_C5);
            GameMap_Radar_Array[2, 5] =  new GameBoardField(BTN_RADARFIELD_GB_C6);
            GameMap_Radar_Array[2, 6] =  new GameBoardField(BTN_RADARFIELD_GB_C7);
            GameMap_Radar_Array[2, 7] =  new GameBoardField(BTN_RADARFIELD_GB_C8);
            GameMap_Radar_Array[2, 8] =  new GameBoardField(BTN_RADARFIELD_GB_C9);
            GameMap_Radar_Array[2, 9] =  new GameBoardField(BTN_RADARFIELD_GB_C10);
            GameMap_Radar_Array[2, 10] = new GameBoardField(BTN_RADARFIELD_GB_C11);
            GameMap_Radar_Array[2, 11] = new GameBoardField(BTN_RADARFIELD_GB_C12);
            #endregion
            #region D
            GameMap_Radar_Array[3, 0] =  new GameBoardField(BTN_RADARFIELD_GB_D1);
            GameMap_Radar_Array[3, 1] =  new GameBoardField(BTN_RADARFIELD_GB_D2);
            GameMap_Radar_Array[3, 2] =  new GameBoardField(BTN_RADARFIELD_GB_D3);
            GameMap_Radar_Array[3, 3] =  new GameBoardField(BTN_RADARFIELD_GB_D4);
            GameMap_Radar_Array[3, 4] =  new GameBoardField(BTN_RADARFIELD_GB_D5);
            GameMap_Radar_Array[3, 5] =  new GameBoardField(BTN_RADARFIELD_GB_D6);
            GameMap_Radar_Array[3, 6] =  new GameBoardField(BTN_RADARFIELD_GB_D7);
            GameMap_Radar_Array[3, 7] =  new GameBoardField(BTN_RADARFIELD_GB_D8);
            GameMap_Radar_Array[3, 8] =  new GameBoardField(BTN_RADARFIELD_GB_D9);
            GameMap_Radar_Array[3, 9] =  new GameBoardField(BTN_RADARFIELD_GB_D10);
            GameMap_Radar_Array[3, 10] = new GameBoardField(BTN_RADARFIELD_GB_D11);
            GameMap_Radar_Array[3, 11] = new GameBoardField(BTN_RADARFIELD_GB_D12);
            #endregion
            #region E 4
            GameMap_Radar_Array[4, 0] =  new GameBoardField(BTN_RADARFIELD_GB_E1);
            GameMap_Radar_Array[4, 1] =  new GameBoardField(BTN_RADARFIELD_GB_E2);
            GameMap_Radar_Array[4, 2] =  new GameBoardField(BTN_RADARFIELD_GB_E3);
            GameMap_Radar_Array[4, 3] =  new GameBoardField(BTN_RADARFIELD_GB_E4);
            GameMap_Radar_Array[4, 4] =  new GameBoardField(BTN_RADARFIELD_GB_E5);
            GameMap_Radar_Array[4, 5] =  new GameBoardField(BTN_RADARFIELD_GB_E6);
            GameMap_Radar_Array[4, 6] =  new GameBoardField(BTN_RADARFIELD_GB_E7);
            GameMap_Radar_Array[4, 7] =  new GameBoardField(BTN_RADARFIELD_GB_E8);
            GameMap_Radar_Array[4, 8] =  new GameBoardField(BTN_RADARFIELD_GB_E9);
            GameMap_Radar_Array[4, 9] =  new GameBoardField(BTN_RADARFIELD_GB_E10);
            GameMap_Radar_Array[4, 10] = new GameBoardField(BTN_RADARFIELD_GB_E11);
            GameMap_Radar_Array[4, 11] = new GameBoardField(BTN_RADARFIELD_GB_E12);
            #endregion
            #region F 5
            GameMap_Radar_Array[5, 0] =  new GameBoardField(BTN_RADARFIELD_GB_F1);
            GameMap_Radar_Array[5, 1] =  new GameBoardField(BTN_RADARFIELD_GB_F2);
            GameMap_Radar_Array[5, 2] =  new GameBoardField(BTN_RADARFIELD_GB_F3);
            GameMap_Radar_Array[5, 3] =  new GameBoardField(BTN_RADARFIELD_GB_F4);
            GameMap_Radar_Array[5, 4] =  new GameBoardField(BTN_RADARFIELD_GB_F5);
            GameMap_Radar_Array[5, 5] =  new GameBoardField(BTN_RADARFIELD_GB_F6);
            GameMap_Radar_Array[5, 6] =  new GameBoardField(BTN_RADARFIELD_GB_F7);
            GameMap_Radar_Array[5, 7] =  new GameBoardField(BTN_RADARFIELD_GB_F8);
            GameMap_Radar_Array[5, 8] =  new GameBoardField(BTN_RADARFIELD_GB_F9);
            GameMap_Radar_Array[5, 9] =  new GameBoardField(BTN_RADARFIELD_GB_F10);
            GameMap_Radar_Array[5, 10] = new GameBoardField(BTN_RADARFIELD_GB_F11);
            GameMap_Radar_Array[5, 11] = new GameBoardField(BTN_RADARFIELD_GB_F12);
            #endregion
            #region G 6
            GameMap_Radar_Array[6, 0] =  new GameBoardField(BTN_RADARFIELD_GB_G1);
            GameMap_Radar_Array[6, 1] =  new GameBoardField(BTN_RADARFIELD_GB_G2);
            GameMap_Radar_Array[6, 2] =  new GameBoardField(BTN_RADARFIELD_GB_G3);
            GameMap_Radar_Array[6, 3] =  new GameBoardField(BTN_RADARFIELD_GB_G4);
            GameMap_Radar_Array[6, 4] =  new GameBoardField(BTN_RADARFIELD_GB_G5);
            GameMap_Radar_Array[6, 5] =  new GameBoardField(BTN_RADARFIELD_GB_G6);
            GameMap_Radar_Array[6, 6] =  new GameBoardField(BTN_RADARFIELD_GB_G7);
            GameMap_Radar_Array[6, 7] =  new GameBoardField(BTN_RADARFIELD_GB_G8);
            GameMap_Radar_Array[6, 8] =  new GameBoardField(BTN_RADARFIELD_GB_G9);
            GameMap_Radar_Array[6, 9] =  new GameBoardField(BTN_RADARFIELD_GB_G10);
            GameMap_Radar_Array[6, 10] = new GameBoardField(BTN_RADARFIELD_GB_G11);
            GameMap_Radar_Array[6, 11] = new GameBoardField(BTN_RADARFIELD_GB_G12);
            #endregion
            #region H 7
            GameMap_Radar_Array[7, 0] =  new GameBoardField(BTN_RADARFIELD_GB_H1);
            GameMap_Radar_Array[7, 1] =  new GameBoardField(BTN_RADARFIELD_GB_H2);
            GameMap_Radar_Array[7, 2] =  new GameBoardField(BTN_RADARFIELD_GB_H3);
            GameMap_Radar_Array[7, 3] =  new GameBoardField(BTN_RADARFIELD_GB_H4);
            GameMap_Radar_Array[7, 4] =  new GameBoardField(BTN_RADARFIELD_GB_H5);
            GameMap_Radar_Array[7, 5] =  new GameBoardField(BTN_RADARFIELD_GB_H6);
            GameMap_Radar_Array[7, 6] =  new GameBoardField(BTN_RADARFIELD_GB_H7);
            GameMap_Radar_Array[7, 7] =  new GameBoardField(BTN_RADARFIELD_GB_H8);
            GameMap_Radar_Array[7, 8] =  new GameBoardField(BTN_RADARFIELD_GB_H9);
            GameMap_Radar_Array[7, 9] =  new GameBoardField(BTN_RADARFIELD_GB_H10);
            GameMap_Radar_Array[7, 10] = new GameBoardField(BTN_RADARFIELD_GB_H11);
            GameMap_Radar_Array[7, 11] = new GameBoardField(BTN_RADARFIELD_GB_H12);
            #endregion
            #region I 8
            GameMap_Radar_Array[8, 0] =  new GameBoardField(BTN_RADARFIELD_GB_I1);
            GameMap_Radar_Array[8, 1] =  new GameBoardField(BTN_RADARFIELD_GB_I2);
            GameMap_Radar_Array[8, 2] =  new GameBoardField(BTN_RADARFIELD_GB_I3);
            GameMap_Radar_Array[8, 3] =  new GameBoardField(BTN_RADARFIELD_GB_I4);
            GameMap_Radar_Array[8, 4] =  new GameBoardField(BTN_RADARFIELD_GB_I5);
            GameMap_Radar_Array[8, 5] =  new GameBoardField(BTN_RADARFIELD_GB_I6);
            GameMap_Radar_Array[8, 6] =  new GameBoardField(BTN_RADARFIELD_GB_I7);
            GameMap_Radar_Array[8, 7] =  new GameBoardField(BTN_RADARFIELD_GB_I8);
            GameMap_Radar_Array[8, 8] =  new GameBoardField(BTN_RADARFIELD_GB_I9);
            GameMap_Radar_Array[8, 9] =  new GameBoardField(BTN_RADARFIELD_GB_I10);
            GameMap_Radar_Array[8, 10] = new GameBoardField(BTN_RADARFIELD_GB_I11);
            GameMap_Radar_Array[8, 11] = new GameBoardField(BTN_RADARFIELD_GB_I12);
            #endregion
            #region J 9
            GameMap_Radar_Array[9, 0] =  new GameBoardField(BTN_RADARFIELD_GB_J1);
            GameMap_Radar_Array[9, 1] =  new GameBoardField(BTN_RADARFIELD_GB_J2);
            GameMap_Radar_Array[9, 2] =  new GameBoardField(BTN_RADARFIELD_GB_J3);
            GameMap_Radar_Array[9, 3] =  new GameBoardField(BTN_RADARFIELD_GB_J4);
            GameMap_Radar_Array[9, 4] =  new GameBoardField(BTN_RADARFIELD_GB_J5);
            GameMap_Radar_Array[9, 5] =  new GameBoardField(BTN_RADARFIELD_GB_J6);
            GameMap_Radar_Array[9, 6] =  new GameBoardField(BTN_RADARFIELD_GB_J7);
            GameMap_Radar_Array[9, 7] =  new GameBoardField(BTN_RADARFIELD_GB_J8);
            GameMap_Radar_Array[9, 8] =  new GameBoardField(BTN_RADARFIELD_GB_J9);
            GameMap_Radar_Array[9, 9] =  new GameBoardField(BTN_RADARFIELD_GB_J10);
            GameMap_Radar_Array[9, 10] = new GameBoardField(BTN_RADARFIELD_GB_J11);
            GameMap_Radar_Array[9, 11] = new GameBoardField(BTN_RADARFIELD_GB_J12);
            #endregion
            #region K 10
            GameMap_Radar_Array[10, 0] =  new GameBoardField(BTN_RADARFIELD_GB_K1);
            GameMap_Radar_Array[10, 1] =  new GameBoardField(BTN_RADARFIELD_GB_K2);
            GameMap_Radar_Array[10, 2] =  new GameBoardField(BTN_RADARFIELD_GB_K3);
            GameMap_Radar_Array[10, 3] =  new GameBoardField(BTN_RADARFIELD_GB_K4);
            GameMap_Radar_Array[10, 4] =  new GameBoardField(BTN_RADARFIELD_GB_K5);
            GameMap_Radar_Array[10, 5] =  new GameBoardField(BTN_RADARFIELD_GB_K6);
            GameMap_Radar_Array[10, 6] =  new GameBoardField(BTN_RADARFIELD_GB_K7);
            GameMap_Radar_Array[10, 7] =  new GameBoardField(BTN_RADARFIELD_GB_K8);
            GameMap_Radar_Array[10, 8] =  new GameBoardField(BTN_RADARFIELD_GB_K9);
            GameMap_Radar_Array[10, 9] =  new GameBoardField(BTN_RADARFIELD_GB_K10);
            GameMap_Radar_Array[10, 10] = new GameBoardField(BTN_RADARFIELD_GB_K11);
            GameMap_Radar_Array[10, 11] = new GameBoardField(BTN_RADARFIELD_GB_K12);
            #endregion
            #region L 11
            GameMap_Radar_Array[11, 0] =  new GameBoardField(BTN_RADARFIELD_GB_L1);
            GameMap_Radar_Array[11, 1] =  new GameBoardField(BTN_RADARFIELD_GB_L2);
            GameMap_Radar_Array[11, 2] =  new GameBoardField(BTN_RADARFIELD_GB_L3);
            GameMap_Radar_Array[11, 3] =  new GameBoardField(BTN_RADARFIELD_GB_L4);
            GameMap_Radar_Array[11, 4] =  new GameBoardField(BTN_RADARFIELD_GB_L5);
            GameMap_Radar_Array[11, 5] =  new GameBoardField(BTN_RADARFIELD_GB_L6);
            GameMap_Radar_Array[11, 6] =  new GameBoardField(BTN_RADARFIELD_GB_L7);
            GameMap_Radar_Array[11, 7] =  new GameBoardField(BTN_RADARFIELD_GB_L8);
            GameMap_Radar_Array[11, 8] =  new GameBoardField(BTN_RADARFIELD_GB_L9);
            GameMap_Radar_Array[11, 9] =  new GameBoardField(BTN_RADARFIELD_GB_L10);
            GameMap_Radar_Array[11, 10] = new GameBoardField(BTN_RADARFIELD_GB_L11);
            GameMap_Radar_Array[11, 11] = new GameBoardField(BTN_RADARFIELD_GB_L12);
            #endregion

            if (addMouseOver)
            {
                for (int i = 0; i < 12; i++)
                {
                    for (int x = 0; x < 12; x++)
                    {
                        GameMap_Radar_Array[i, x].fieldButton.MouseEnter += new MouseEventHandler(MouseEnterGameBoardButton);
                        GameMap_Radar_Array[i, x].fieldButton.MouseLeave += new MouseEventHandler(MouseLeaveGameBoardButton);
                    }
                }
            }
        }
        #endregion

        #region Visualization Functions ---------------------------------------------------------------------------------------------------------------------------------------------------------
        private void MouseWheelGameBoardButton(object sender, RoutedEventArgs e)
        {
            TurnCompass(BTN_placeShips_TurnShip);
            Coords btnCoords = Coords.GetBtnCoords(((Button)sender).Uid);
            for(int i = 0; i < 12; i++)
            {
                if (GameMapArray[btnCoords.yCoord, i].fieldState == Const.FieldState.FREE)
                {
                    GameMapArray[btnCoords.yCoord, i].fieldButton.Style = (Style)Application.Current.Resources["GB_SetterMode_Mainfield_Default_Button"];
                }
                if (GameMapArray[i, btnCoords.xCoord].fieldState == Const.FieldState.FREE)
                {
                    GameMapArray[i, btnCoords.xCoord].fieldButton.Style = (Style)Application.Current.Resources["GB_SetterMode_Mainfield_Default_Button"];
                }
            }
        }

        private void MouseEnterGameBoardButton (object sender, RoutedEventArgs e)
        {
            string actGameMode = ActGameMode;
            bool isMainfield = ((Button)sender).Name.Substring(0, 9) == "BTN_RADARFIELD_GB_".Substring(0, 9) ? false: true;
            string btnTyp = actGameMode == SetterMode ? "Mainfield" : isMainfield ? "Mainfield" : "Radarfield";
            

            if(!DumpSelected)
            {
                Coords buttonCoords = Coords.GetBtnCoords(((Button)sender).Uid);
                if (SelectedShip == 0)
                {
                    if (isMainfield)
                    {
                        if (GameMapArray[buttonCoords.yCoord, buttonCoords.xCoord].fieldState == Const.FieldState.SHIP)
                        {
                            Ship ship = GameMapArray[buttonCoords.yCoord, buttonCoords.xCoord].ship;
                            LBL_oType.Content = Convert.ToString(ship.shipTyp);
                            LBL_oLength.Content = Convert.ToString(ship.shipLength);
                            LBL_oHealth.Content = Convert.ToString(ship.shipHealth * 100 / ship.shipLength) + " %";
                            Mouse.OverrideCursor = ((TextBlock)Application.Current.Resources["SW_PLACE_SHIP_INFO_CURSOR"]).Cursor;
                        }
                        else
                        {
                            GameMapArray[buttonCoords.yCoord, buttonCoords.xCoord].fieldButton.Style = (Style)Application.Current.Resources["GB_" + actGameMode + "_" + btnTyp + "_MouseOver_Button"];
                        }
                    } else
                    {
                        if (GameMap_Radar_Array[buttonCoords.yCoord, buttonCoords.xCoord].fieldState == Const.FieldState.SHIP)
                        {
                            Ship ship = GameMap_Radar_Array[buttonCoords.yCoord, buttonCoords.xCoord].ship;
                            LBL_oType.Content = Convert.ToString(ship.shipTyp);
                            LBL_oLength.Content = Convert.ToString(ship.shipLength);
                            LBL_oHealth.Content = Convert.ToString(ship.shipHealth * 100 / ship.shipLength) + " %";
                            Mouse.OverrideCursor = ((TextBlock)Application.Current.Resources["SW_PLACE_SHIP_INFO_CURSOR"]).Cursor;
                        }
                        else 
                        {
                            GameMap_Radar_Array[buttonCoords.yCoord, buttonCoords.xCoord].fieldButton.Style = (Style)Application.Current.Resources["GB_" + actGameMode + "_" + btnTyp + "_MouseOver_Button"];
                        }
                    }
                } else if (Coords.ConfirmCoords(actNav, SelectedShip, buttonCoords, GameMapArray))
                {
                    //if (Coords.ConfirmBlocks(actNav, SelectedShip, buttonCoords, GameMapArray))
                    //{
                        for (int i = 0; i < Ship.GetShipLength(SelectedShip); i++)
                        {
                            Coords.GetNextCoordsByDirection(actNav, buttonCoords, i);
                            if (isMainfield)
                            {
                                Mouse.OverrideCursor = ((TextBlock)Application.Current.Resources["SW_PLACE_SHIP_CURSOR"]).Cursor;
                                GameMapArray[buttonCoords.yCoord, buttonCoords.xCoord].fieldButton.Style = (Style)Application.Current.Resources["GB_" + actGameMode + "_" + btnTyp + "_MouseOver_Button"];
                            }
                            else
                            {
                                GameMap_Radar_Array[buttonCoords.yCoord, buttonCoords.xCoord].fieldButton.Style = (Style)Application.Current.Resources["GB_" + actGameMode + "_" + btnTyp + "_MouseOver_Button"];
                            }
                        }
                    //}
                } else if (isMainfield ? GameMapArray[buttonCoords.yCoord, buttonCoords.xCoord].fieldState == Const.FieldState.SHIP : 
                                         GameMap_Radar_Array[buttonCoords.yCoord, buttonCoords.xCoord].fieldState == Const.FieldState.SHIP)
                {
                    Ship ship = isMainfield ? GameMapArray[buttonCoords.yCoord, buttonCoords.xCoord].ship : GameMap_Radar_Array[buttonCoords.yCoord, buttonCoords.xCoord].ship;
                    LBL_oType.Content = Convert.ToString(ship.shipTyp);
                    LBL_oLength.Content = Convert.ToString(ship.shipLength);
                    LBL_oHealth.Content = Convert.ToString(ship.shipHealth * 100 / ship.shipLength) + " %";
                    Mouse.OverrideCursor = ((TextBlock)Application.Current.Resources["SW_PLACE_SHIP_INFO_CURSOR"]).Cursor;
                }
            } else
            {
                Coords buttonCoords = Coords.GetBtnCoords(((Button)sender).Uid);
                if (GameMapArray[buttonCoords.yCoord, buttonCoords.xCoord].fieldState == Const.FieldState.SHIP)
                {
                    Mouse.OverrideCursor = ((TextBlock)Application.Current.Resources["SW_PLACE_RECYCLE_SHIP_CURSOR"]).Cursor;
                }
            }


        }

        private void MouseLeaveGameBoardButton(object sender, RoutedEventArgs e)
        {
            string actGameMode = ActGameMode;
            bool isMainfield = ((Button)sender).Name.Substring(0, 9) == "BTN_RADARFIELD_GB_".Substring(0, 9) ? false : true;
            string btnTyp = actGameMode == SetterMode ? "Mainfield" : isMainfield ? "Mainfield" : "Radarfield";


            if (!DumpSelected)
            {
                Coords buttonCoords = Coords.GetBtnCoords(((Button)sender).Uid);
                if (SelectedShip == 0)
                {
                    if (isMainfield)
                    {
                        if (GameMapArray[buttonCoords.yCoord, buttonCoords.xCoord].fieldState == Const.FieldState.SHIP)
                        {
                            LBL_oType.Content = " - ";
                            LBL_oLength.Content = " - ";
                            LBL_oHealth.Content = " - %";

                            Mouse.OverrideCursor = ((TextBlock)Application.Current.Resources["SW_STD_CURSOR"]).Cursor;
                        }
                        else
                        {
                            GameMapArray[buttonCoords.yCoord, buttonCoords.xCoord].fieldButton.Style = (Style)Application.Current.Resources["GB_" + actGameMode + "_" + btnTyp + "_Default_Button"];
                        }
                    }
                    else
                    {
                        if (GameMap_Radar_Array[buttonCoords.yCoord, buttonCoords.xCoord].fieldState == Const.FieldState.SHIP)
                        {
                            LBL_oType.Content = " - ";
                            LBL_oLength.Content = " - ";
                            LBL_oHealth.Content = " - %";

                            Mouse.OverrideCursor = ((TextBlock)Application.Current.Resources["SW_STD_CURSOR"]).Cursor;
                        }
                        else
                        {
                            GameMap_Radar_Array[buttonCoords.yCoord, buttonCoords.xCoord].fieldButton.Style = (Style)Application.Current.Resources["GB_" + actGameMode + "_" + btnTyp + "_Default_Button"];
                        }
                    }
                }
                else if (Coords.ConfirmCoords(actNav, SelectedShip, buttonCoords, GameMapArray))
                {
                    //if (Coords.ConfirmBlocks(actNav, SelectedShip, buttonCoords, GameMapArray))
                    //{
                        for (int i = 0; i < Ship.GetShipLength(SelectedShip); i++)
                        {
                            Coords.GetNextCoordsByDirection(actNav, buttonCoords, i);
                            if (isMainfield)
                            {
                                Mouse.OverrideCursor = ((TextBlock)Application.Current.Resources["SW_STD_CURSOR"]).Cursor;
                                GameMapArray[buttonCoords.yCoord, buttonCoords.xCoord].fieldButton.Style = (Style)Application.Current.Resources["GB_" + actGameMode + "_" + btnTyp + "_Default_Button"];
                            }
                            else
                            {
                                Mouse.OverrideCursor = ((TextBlock)Application.Current.Resources["SW_STD_CURSOR"]).Cursor;
                                GameMap_Radar_Array[buttonCoords.yCoord, buttonCoords.xCoord].fieldButton.Style = (Style)Application.Current.Resources["GB_" + actGameMode + "_" + btnTyp + "_Default_Button"];
                            }
                        }
                    //}
                }
                else if (isMainfield ? GameMapArray[buttonCoords.yCoord, buttonCoords.xCoord].fieldState == Const.FieldState.SHIP :
                                       GameMap_Radar_Array[buttonCoords.yCoord, buttonCoords.xCoord].fieldState == Const.FieldState.SHIP)
                {
                    LBL_oType.Content = " - ";
                    LBL_oLength.Content = " - ";
                    LBL_oHealth.Content = " - %";
                    Mouse.OverrideCursor = ((TextBlock)Application.Current.Resources["SW_STD_CURSOR"]).Cursor;
                }
            }
            else
            {
                Coords buttonCoords = Coords.GetBtnCoords(((Button)sender).Uid);
                if (GameMapArray[buttonCoords.yCoord, buttonCoords.xCoord].fieldState == Const.FieldState.SHIP)
                {
                    Mouse.OverrideCursor = ((TextBlock)Application.Current.Resources["SW_STD_CURSOR"]).Cursor;
                }
            }

        }
        #endregion

        #region Button Functions ----------------------------------------------------------------------------------------------------------------------------------------------------------------
        // SHIP_MARKER
        private void BTN_Ship1_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedShip != 1)
            {
                SelectedShip = 1;
                SetBackDumpState();
                SetBackSelectedShipButton();
                ((Button)sender).Style = (Style)Application.Current.Resources["GB_SetterMode_Mainfield_SelectedShip_Button"];
            } else
            {
                SelectedShip = 0;
                SetBackSelectedShipButton();
            }
        }

        private void BTN_Ship2_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedShip != 2)
            { 
                SelectedShip = 2;
                SetBackDumpState();
                SetBackSelectedShipButton();
                ((Button)sender).Style = (Style)Application.Current.Resources["GB_SetterMode_Mainfield_SelectedShip_Button"];
            }
            else
            {
                SelectedShip = 0;
                SetBackSelectedShipButton();
            }
        }

        private void BTN_Ship3_Click(object sender, RoutedEventArgs e)
        {
            if(SelectedShip != 3) { 
                SelectedShip = 3;
                SetBackDumpState();
                SetBackSelectedShipButton();
                ((Button)sender).Style = (Style)Application.Current.Resources["GB_SetterMode_Mainfield_SelectedShip_Button"];
            }
            else
            {
                SelectedShip = 0;
                SetBackSelectedShipButton();
            }
        }

        private void BTN_Ship4_Click(object sender, RoutedEventArgs e)
        {
            if(SelectedShip != 4) { 
                SelectedShip = 4;
                SetBackDumpState();
                SetBackSelectedShipButton();
                ((Button)sender).Style = (Style)Application.Current.Resources["GB_SetterMode_Mainfield_SelectedShip_Button"];
            }
            else
            {
                SelectedShip = 0;
                SetBackSelectedShipButton();
            }
        }

        private void BTN_GB_Clicked(object sender, RoutedEventArgs e)
        {
            switch (ActGameMode)
            {
                case SetterMode:
                    if (!DumpSelected)
                    {
                        if (SelectedShip != 0)
                        {
                            Ship setShip = new Ship(SelectedShip, false);
                            SetShip(setShip, Coords.GetBtnCoords(((Button)sender).Uid));
                        }
                    }
                    else
                    {
                        DumpShip(Coords.GetBtnCoords(((Button)sender).Uid));
                        Mouse.OverrideCursor = ((TextBlock)Application.Current.Resources["SW_STD_CURSOR"]).Cursor;
                    }
                    break;
                default: break;
            }
        }
        
        private void BTN_placeShips_TurnShip_Click(object sender, RoutedEventArgs e)
        {
            Button thisButton = (Button)sender;
            TurnCompass(thisButton);
        }

        private void TurnCompass(Button thisButton)
        {
            if (actNav == Const.Nav.NORTH)
            {
                actNav = Const.Nav.EAST;
                thisButton.Style = (Style)Application.Current.Resources["Nav_Image_East"];
            }
            else if (actNav == Const.Nav.EAST)
            {

                actNav = Const.Nav.SOUTH;
                thisButton.Style = (Style)Application.Current.Resources["Nav_Image_South"];
            }
            else if (actNav == Const.Nav.SOUTH)
            {
                actNav = Const.Nav.WEST;
                thisButton.Style = (Style)Application.Current.Resources["Nav_Image_West"];
            }
            else if (actNav == Const.Nav.WEST)
            {
                actNav = Const.Nav.NORTH;
                thisButton.Style = (Style)Application.Current.Resources["Nav_Image_North"];
            }
        }

        private void BTN_placeShips_DumpShip_Click(object sender, RoutedEventArgs e)
        {
            if (!DumpSelected)
            {
                DumpSelected = true;
                ((Button)sender).Style = (Style)Application.Current.Resources["GB_DumpShip_Selected"];
                SetBackSelectedShipButton();
                SelectedShip = 0;
            }
            else
            {
                SetBackDumpState();
            }
        }

        private void SetBackDumpState()
        {
            DumpSelected = false;
            BTN_placeShips_DumpShip.Style = (Style)Application.Current.Resources["GB_DumpShip_Default"];
            Mouse.OverrideCursor = null;
        }
        #endregion

        private void SetBackSelectedShipButton()
        {
            for(int i = 0; i < Ship_Button.Length; i++)
            {
                Ship_Button[i].Style = (Style)Application.Current.Resources["GB_SetterMode_Mainfield_Default_Button"];
            }
        }

        private void DumpShip(Coords i_coords)
        {
            List<List<PlacedShips>> allPlacedShips = new List<List<PlacedShips>>();
            // !! ATTENTION !!
            // If you added a new shipTyp you need to add a new placedShip-List for this new shipTyp
            // And you need to add the new placedShip-List to this function!  
            GetAllPlacedShipsLists(allPlacedShips);
            bool breakAfterChange = false;

            foreach(List<PlacedShips> placedShipsList in allPlacedShips)
            {
                foreach(PlacedShips placedShip in placedShipsList)
                {
                    foreach(Coords CoordsPart in placedShip.shipCoords)
                    {
                        if (Coords.CompareCoords(CoordsPart, i_coords))
                        {
                            // We found the ship which was selected by the user
                            SetBackShipTypCnt(placedShip.shipTyp);
                            Ship.SetBackGameMapFields(placedShip, placedShip.shipTyp, GameMapArray);
                            placedShipsList.RemoveAt(placedShipsList.IndexOf(placedShip));
                            breakAfterChange = true;
                            break;
                        }
                    }
                    if(breakAfterChange) { break; }
                }
                if (breakAfterChange) { break; }
            }
        }

        private void GetAllPlacedShipsLists(List<List<PlacedShips>> i_List)
        {
            // SHIP_MARKER
            // !! ATTENTION !!
            // If you added a new shipTyp you need to add a new placedShip-List for this new shipTyp
            // And you need to add the new placedShip-List to this function! 
            i_List.Add(Placed_Ship1);
            i_List.Add(Placed_Ship2);
            i_List.Add(Placed_Ship3);
            i_List.Add(Placed_Ship4);
        }

        private void SetBackShipTypCnt(int shipTyp)
        {
            // SHIP_MARKER
            switch (shipTyp)
            {
                case 1:
                    SwitchShipRedLights(RedLights_Ship1[placedCnt_Ship1 - 1], false);
                    placedCnt_Ship1 -= 1; break;
                case 2:
                    SwitchShipRedLights(RedLights_Ship2[placedCnt_Ship2 - 1], false);
                    placedCnt_Ship2 -= 1; break;
                case 3:
                    SwitchShipRedLights(RedLights_Ship3[placedCnt_Ship3 - 1], false);
                    placedCnt_Ship3 -= 1; break;
                case 4:
                    SwitchShipRedLights(RedLights_Ship4[placedCnt_Ship4 - 1], false);
                    placedCnt_Ship4 -= 1; break;
            }
        }

        #region Set Ships -----------------------------------------------------------------------------------------------------------------------------------------------------------------------
        private void SetShip(Ship i_ship, Coords buttonCoords)
        {
            Coords[] placedCoords = new Coords[i_ship.shipLength];
            if (Coords.ConfirmCoords(actNav, i_ship.shipTyp, buttonCoords, GameMapArray, placedCoords))
            {
                Coords realButtonCoords = new Coords(buttonCoords.yCoord, buttonCoords.xCoord);
                if (Coords.ConfirmBlocks(actNav, i_ship.shipTyp, buttonCoords, GameMapArray))
                {
                    for (int i = 0; i < Ship.GetShipLength(i_ship.shipTyp); i++)
                    {
                        Coords.SetNextCoordsByDirection(actNav, realButtonCoords, i, placedCoords, i_ship, GameMapArray);
                    }

                    // SHIP_MARKER
                    switch (SelectedShip)
                    {
                        case 1:
                            Ship.CheckShipCnt(Placed_Ship1, placedCoords, Ship.ship1_Max, i_ship.shipTyp, ref placedCnt_Ship1, GameMapArray);
                            SwitchShipRedLights(RedLights_Ship1[placedCnt_Ship1 - 1], true);
                            break;
                        case 2:
                            Ship.CheckShipCnt(Placed_Ship2, placedCoords, Ship.ship2_Max, i_ship.shipTyp, ref placedCnt_Ship2, GameMapArray);
                            SwitchShipRedLights(RedLights_Ship2[placedCnt_Ship2 - 1], true);
                            break;
                        case 3:
                            Ship.CheckShipCnt(Placed_Ship3, placedCoords, Ship.ship3_Max, i_ship.shipTyp, ref placedCnt_Ship3, GameMapArray);
                            SwitchShipRedLights(RedLights_Ship3[placedCnt_Ship3 - 1], true);
                            break;
                        case 4:
                            Ship.CheckShipCnt(Placed_Ship4, placedCoords, Ship.ship4_Max, i_ship.shipTyp, ref placedCnt_Ship4, GameMapArray);
                            SwitchShipRedLights(RedLights_Ship4[placedCnt_Ship4 - 1], true);
                            break;
                        default: break;
                    }
                }
            }
        }

        private void SwitchShipRedLights(Image i_img, bool On)
        {
            i_img.Source = (ImageSource)Application.Current.Resources["IMG_RedLight_" + (On == true ? "On" : "Off")];
        }

        private void SetShipsAutomatic()
        {
            while (placedCnt_Ship1 < Ship.ship1_Max)
            {
                CreateRndShip(1);
            }
            while (placedCnt_Ship2 < Ship.ship2_Max)
            {
                CreateRndShip(2);
            }
            while (placedCnt_Ship3 < Ship.ship3_Max)
            {
                CreateRndShip(3);
            }
            while (placedCnt_Ship4 < Ship.ship4_Max)
            {
                CreateRndShip(4);
            }
        }

        private void CreateRndShip(int i_shipTyp)
        {
            Ship newShip;
            Random rnd = new Random();
            newShip = new Ship(i_shipTyp, false);
            actNav = GetRandomNav(rnd.Next(5));
            Coords newCoords = new Coords(rnd.Next(0, 12), rnd.Next(0, 12));
            SetShip(newShip, newCoords);
        }

        private Const.Nav GetRandomNav(int rnd)
        {
            switch (rnd)
            {
                case 0: return Const.Nav.NORTH;
                case 1: return Const.Nav.EAST;
                case 2: return Const.Nav.SOUTH;
                case 3: return Const.Nav.WEST;
                default: return Const.Nav.NORTH;
            }
        }

        #endregion

        private void BTN_GoBack_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.Timer timer1 = new System.Windows.Forms.Timer();
            timer1.Interval = 500;
            timer1.Tick += new EventHandler(GoBack);
            timer1.Start();
            UserControl singleplayer_userSelect = new Singleplayer_UserSelect(SW_mainWindow, new Nocksoft.IO.ConfigFiles.INIFile(Player.iniPath));
            SW_mainWindow.MainContent.Content = singleplayer_userSelect;
        }

        private void GoBack(object sender, EventArgs e)
        {
            ((Button)sender).Style = (Style)Application.Current.Resources["ToogleDown_Button"];
            StopTimer();
        }

        private void StopTimer()
        {
            timer1.Stop();
        }

       
        private void SwitchGameMode(string i_mode)
        {
            switch(i_mode)
            {
                case SetterMode:
                    ActGameMode = SetterMode;
                    break;
                case AttackMode:
                    ActGameMode = AttackMode;
                    CNVS_ATTACKMODE_INFO.Visibility = Visibility.Visible;
                    CNVS_FLEET_OVERVIEW.Visibility = Visibility.Visible;
                    CNVS_ATTACK_RADAR.Visibility = Visibility.Visible;
                    CNVS_ATTACKMODE.Visibility = Visibility.Visible;

                    CNVS_SETTERMODE.Visibility = Visibility.Hidden;
                    CNVS_RADAR.Visibility = Visibility.Hidden;
                    CNVS_SHIPMODI.Visibility = Visibility.Hidden;
                    CNVS_Ships.Visibility = Visibility.Hidden;

                    SelectedShip = 0;
                    break;
                default:break;
            }
        }

        private void BTN_StartAttack_Click(object sender, RoutedEventArgs e)
        {
            ((Button)sender).Style = (Style)Application.Current.Resources["ToogleDown_Button"];
            //SwitchMainFieldButtonToRadarStyle();
            //SwitchGameMode(AttackMode);
            timer1.Stop();
            UserControl singleplayer_gameboard_attackmode = new Singleplayer_GameBoard_AttackMode(SW_mainWindow, GamePlayer, Placed_Ship1, Placed_Ship2, Placed_Ship3, Placed_Ship4, GameMapArray);
            SW_mainWindow.MainContent.Content = singleplayer_gameboard_attackmode;

        }

        private void BTN_SetShipsAuto_Click(object sender, RoutedEventArgs e)
        {
            SetShipsAutomatic();
        }
    }
}
