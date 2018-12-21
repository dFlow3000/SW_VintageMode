using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ShipWar
{
    public class Ship
    {
        // SHIP_MARKER
        public const int ship1_Max = 3;
        public const int ship2_Max = 2;
        public const int ship3_Max = 1;
        public const int ship4_Max = 2;

        // SHIP_MARKER
        public const int ship1_Length = 2;
        public const int ship2_Length = 3;
        public const int ship3_Length = 4;
        public const int ship4_Length = 2;

        public int shipTyp;
        public int shipLength;
        public int shipHealth;
        public bool gotHit;
        public Ship(int i_shipTyp, bool i_gotHit)
        {
            shipTyp = i_shipTyp;
            shipLength = GetShipLength(i_shipTyp);
            shipHealth = shipLength;
            gotHit = i_gotHit;
        }

        public static int GetShipLength(int shipTyp)
        {
            // SHIP_MARKER
            switch (shipTyp)
            {
                case 1: return ship1_Length;
                case 2: return ship2_Length;
                case 3: return ship3_Length;
                case 4: return ship4_Length;
                default: return 0;
            }
        }

        public static void CheckShipCnt(List<PlacedShips> i_List, Coords[] placedShipCoords, int i_shipTyp_Max, int shipTyp, ref int placedCnt_shipTyp, GameBoardField[,] i_GameMapArray, bool SetterMode = true)
        {
            AddNewShipToPlacedShips(i_List, i_shipTyp_Max, ref placedCnt_shipTyp, shipTyp, placedShipCoords, i_GameMapArray, SetterMode);
        }

        private static void AddNewShipToPlacedShips(List<PlacedShips> i_List, int shipTyp_Max, ref int placedCnt_shipTyp, int shipTyp, Coords[] i_newShipCoords, GameBoardField[,] i_GameMapArray, bool SetterMode)
        {
            if (placedCnt_shipTyp < shipTyp_Max)
            {
                placedCnt_shipTyp += 1;
                AddShipToPlacedList(i_List, shipTyp, i_newShipCoords);
                SetBlocksAroundShip(i_List, i_newShipCoords, i_GameMapArray, SetterMode);

            }
            else
            {
                PlacedShips oldShip = i_List.Last();
                SetBackGameMapFields(oldShip, shipTyp, i_GameMapArray);
                i_List.RemoveAt(i_List.Count - 1);
                AddShipToPlacedList(i_List, shipTyp, i_newShipCoords);
                SetBlocksAroundShip(i_List, i_newShipCoords, i_GameMapArray, SetterMode);
            }
        }

        private static void BlockField(GameBoardField i_field, bool SetterMode)
        {
            if (i_field.fieldState == Const.FieldState.BLOCKED)
            {
                i_field.fieldState = Const.FieldState.DOUBLE_BLOCKED;
                if (SetterMode)
                {
                    i_field.fieldButton.Style = (Style)Application.Current.Resources["GB_SetterMode_Mainfield_DoubleBlockedArea_Button"];
                }
                else
                {
                    i_field.fieldButton.Style = (Style)Application.Current.Resources["GB_AttackMode_Mainfield_Default_Button"];
                }
            }
            else
            {
                i_field.fieldState = Const.FieldState.BLOCKED;
                if (SetterMode)
                {
                    i_field.fieldButton.Style = (Style)Application.Current.Resources["GB_SetterMode_Mainfield_BlockedArea_Button"];
                }
                else
                {
                    i_field.fieldButton.Style = (Style)Application.Current.Resources["GB_AttackMode_Mainfield_Default_Button"];
                }
            }
        }

        public static void SetBlocksAroundShip(List<PlacedShips> i_List, Coords[] i_shipCoords, GameBoardField[,] i_GameMapArray, bool SetterMode = true)
        {
            for (int i = 0; i < i_shipCoords.Length; i++)
            {
                for (int x = 0; x < 4; x++)
                {
                    switch (x)
                    {
                        case (int)Const.Nav.NORTH:
                            if (!Coords.CheckIfCoordsOfThisShip(i_shipCoords, i_shipCoords[i].yCoord - 1, i_shipCoords[i].xCoord))
                            {
                                if (Coords.CheckCoordsForBlock(i_shipCoords[i].yCoord - 1, i_shipCoords[i].xCoord, i_GameMapArray, i_shipCoords) == Const.BlockChecks.FREE)
                                {
                                    BlockField(i_GameMapArray[i_shipCoords[i].yCoord - 1, i_shipCoords[i].xCoord], SetterMode);
                                    Coords.CopyCoords(i_List.Last().blockedCoords[i, x], new Coords(i_shipCoords[i].yCoord - 1, i_shipCoords[i].xCoord));
                                }
                            }
                            break;
                        case (int)Const.Nav.EAST:
                            if (!Coords.CheckIfCoordsOfThisShip(i_shipCoords, i_shipCoords[i].yCoord, i_shipCoords[i].xCoord + 1))
                            {
                                if (Coords.CheckCoordsForBlock(i_shipCoords[i].yCoord, i_shipCoords[i].xCoord + 1, i_GameMapArray, i_shipCoords) == Const.BlockChecks.FREE)
                                {
                                    BlockField(i_GameMapArray[i_shipCoords[i].yCoord, i_shipCoords[i].xCoord + 1], SetterMode);
                                    Coords.CopyCoords(i_List.Last().blockedCoords[i, x], new Coords(i_shipCoords[i].yCoord, i_shipCoords[i].xCoord + 1));
                                }
                            }
                            break;
                        case (int)Const.Nav.SOUTH:
                            if (!Coords.CheckIfCoordsOfThisShip(i_shipCoords, i_shipCoords[i].yCoord + 1, i_shipCoords[i].xCoord))
                            {
                                if (Coords.CheckCoordsForBlock(i_shipCoords[i].yCoord + 1, i_shipCoords[i].xCoord, i_GameMapArray, i_shipCoords) == Const.BlockChecks.FREE)
                                {
                                    BlockField(i_GameMapArray[i_shipCoords[i].yCoord + 1, i_shipCoords[i].xCoord], SetterMode);
                                    Coords.CopyCoords(i_List.Last().blockedCoords[i, x], new Coords(i_shipCoords[i].yCoord + 1, i_shipCoords[i].xCoord));
                                }
                            }
                            break;
                        case (int)Const.Nav.WEST:
                            if (!Coords.CheckIfCoordsOfThisShip(i_shipCoords, i_shipCoords[i].yCoord, i_shipCoords[i].xCoord - 1))
                            {
                                if (Coords.CheckCoordsForBlock(i_shipCoords[i].yCoord, i_shipCoords[i].xCoord - 1, i_GameMapArray, i_shipCoords) == Const.BlockChecks.FREE)
                                {
                                    BlockField(i_GameMapArray[i_shipCoords[i].yCoord, i_shipCoords[i].xCoord - 1], SetterMode);
                                    Coords.CopyCoords(i_List.Last().blockedCoords[i, x], new Coords(i_shipCoords[i].yCoord, i_shipCoords[i].xCoord - 1));
                                }
                            }
                            break;
                    }
                }
            }
        }

        public static void SetBackGameMapFields(PlacedShips i_oldShip, int i_shipTyp, GameBoardField[,] i_GameMapArray)
        {
            for (int i = 0; i < GetShipLength(i_shipTyp); i++)
            {
                i_GameMapArray[i_oldShip.shipCoords[i].yCoord, i_oldShip.shipCoords[i].xCoord].fieldState = Const.FieldState.FREE;
                i_GameMapArray[i_oldShip.shipCoords[i].yCoord, i_oldShip.shipCoords[i].xCoord].ship.shipTyp = 0;
                i_GameMapArray[i_oldShip.shipCoords[i].yCoord, i_oldShip.shipCoords[i].xCoord].ship.shipLength = 0;
                i_GameMapArray[i_oldShip.shipCoords[i].yCoord, i_oldShip.shipCoords[i].xCoord].ship.gotHit = false;
                i_GameMapArray[i_oldShip.shipCoords[i].yCoord, i_oldShip.shipCoords[i].xCoord].fieldButton.Style = (Style)Application.Current.Resources["GB_SetterMode_Mainfield_Default_Button"];
                for(int x = 0; x < 4; x++)
                {
                    if (!Coords.CompareCoords(i_oldShip.blockedCoords[i, x], new Coords(-1, -1)))
                    {
                        if(i_GameMapArray[i_oldShip.blockedCoords[i, x].yCoord, i_oldShip.blockedCoords[i, x].xCoord].fieldState == Const.FieldState.DOUBLE_BLOCKED)
                        {
                            i_GameMapArray[i_oldShip.blockedCoords[i, x].yCoord, i_oldShip.blockedCoords[i, x].xCoord].fieldState = Const.FieldState.BLOCKED;
                            i_GameMapArray[i_oldShip.blockedCoords[i, x].yCoord, i_oldShip.blockedCoords[i, x].xCoord].fieldButton.Style = (Style)(Style)Application.Current.Resources["GB_SetterMode_Mainfield_BlockedArea_Button"];
                        } else
                        {
                            i_GameMapArray[i_oldShip.blockedCoords[i, x].yCoord, i_oldShip.blockedCoords[i, x].xCoord].fieldState = Const.FieldState.FREE;
                            i_GameMapArray[i_oldShip.blockedCoords[i, x].yCoord, i_oldShip.blockedCoords[i, x].xCoord].fieldButton.Style = (Style)(Style)Application.Current.Resources["GB_SetterMode_Mainfield_Default_Button"];
                        }
                        
                    }
                }
            }
        }

        private static void AddShipToPlacedList(List<PlacedShips> i_List, int shipTyp, Coords[] i_shipCoords)
        {
            PlacedShips newShip = new PlacedShips(shipTyp);
            newShip.shipCoords = i_shipCoords;
            i_List.Add(newShip);
        }
    }
}
