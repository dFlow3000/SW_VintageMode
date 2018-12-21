using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ShipWar
{
    public class Coords
    {
        public int yCoord;
        public int xCoord;
        public Coords(int y, int x)
        {
            yCoord = y;
            xCoord = x;
        }
        public Coords()
        {
            yCoord = 0;
            xCoord = 0;
        }

        /// <summary>
        /// Converts button-UId into Coords
        /// </summary>
        /// <param name="inputString">Button Uid</param>
        /// <returns>the Coords of the selected button</returns>
        public static Coords GetBtnCoords(string inputString)
        {
            Coords retVal;

            retVal = new Coords(Convert.ToInt32(inputString.Substring(0, inputString.IndexOf("/"))), Convert.ToInt32(inputString.Substring(inputString.IndexOf("/") + 1)));

            return retVal;
        }

        /// <summary>
        /// Compares A_Coords with B_Coords
        /// </summary>
        /// <param name="a_Coords"></param>
        /// <param name="b_Coords"></param>
        /// <returns>returns true if a_Coords and b_Coords are equal</returns>
        public static bool CompareCoords(Coords a_Coords, Coords b_Coords)
        {
            if (a_Coords.yCoord == b_Coords.yCoord && a_Coords.xCoord == b_Coords.xCoord)
            {
                return true;
            } else
            {
                return false;
            }
        }

        public static void CopyCoords(Coords dest, Coords source)
        {
            dest.yCoord = source.yCoord;
            dest.xCoord = source.xCoord;
        }

        /// <summary>
        /// Set the Style of the next Coords by direction depending to the selected Ship 
        /// </summary>
        /// <param name="i_nav">actNav</param>
        /// <param name="i_btnCoords">Coords of selected button</param>
        /// <param name="nextCoordExt">Iterator</param>
        /// <param name="i_placedCoords">all needed Coords</param>
        /// <param name="i_ship">selected Ship</param>
        /// <param name="i_GameMapArray">GameMapArray</param>
        public static void SetNextCoordsByDirection(Const.Nav i_nav, Coords i_btnCoords, int nextCoordExt, Coords[] i_placedCoords, Ship i_ship, GameBoardField[,] i_GameMapArray, bool SetterMode = true)
        {
            Coords nextCoords = i_btnCoords;
            string styleHeader = "GB_Button_Ship" + Convert.ToString(i_ship.shipTyp) + "_" + Convert.ToString(nextCoordExt + 1);
            string styleDirection = "";

            Coords.GetNextCoordsByDirection(i_nav, nextCoords, nextCoordExt, ref styleDirection);

            if (SetterMode)
            {
                i_GameMapArray[nextCoords.yCoord, nextCoords.xCoord].fieldButton.Style = (Style)Application.Current.Resources[styleHeader + styleDirection];
            } else
            {
                i_GameMapArray[nextCoords.yCoord, nextCoords.xCoord].fieldButton.Style = (Style)Application.Current.Resources["GB_Button_ComputerShip"];
            }
            i_GameMapArray[nextCoords.yCoord, nextCoords.xCoord].ship = i_ship;
            i_GameMapArray[nextCoords.yCoord, nextCoords.xCoord].fieldState = Const.FieldState.SHIP;
            i_placedCoords[nextCoordExt].yCoord = nextCoords.yCoord;
            i_placedCoords[nextCoordExt].xCoord = nextCoords.xCoord;
        }

        public static bool ConfirmBlocks(Const.Nav i_nav, int i_selectedShip, Coords i_btnCoords, GameBoardField[,] i_GameMapArray)
        {
            Coords[] shipCoords = new Coords[Ship.GetShipLength(i_selectedShip)];
            for(int i = 0; i < Ship.GetShipLength(i_selectedShip); i++)
            {
                GetNextCoordsByDirection(i_nav, i_btnCoords, i);
                shipCoords[i] = new Coords(i_btnCoords.yCoord, i_btnCoords.xCoord);
            }

            for(int i = 0; i < Ship.GetShipLength(i_selectedShip); i++)
            {
                for(int x = 0; x < 4; x++)
                {
                    switch(x)
                    {
                        case (int)Const.Nav.NORTH:
                            if(CheckCoordsForBlock(shipCoords[i].yCoord - 1, shipCoords[i].xCoord, i_GameMapArray, shipCoords) == Const.BlockChecks.SHIP)
                            {
                                return false;
                            }
                            break;
                        case (int)Const.Nav.EAST:
                            if (CheckCoordsForBlock(shipCoords[i].yCoord, shipCoords[i].xCoord + 1, i_GameMapArray, shipCoords) == Const.BlockChecks.SHIP)
                            {
                                return false;
                            }
                            break;
                        case (int)Const.Nav.SOUTH:
                            if (CheckCoordsForBlock(shipCoords[i].yCoord - 1, shipCoords[i].xCoord, i_GameMapArray, shipCoords) == Const.BlockChecks.SHIP)
                            {
                                return false;
                            }
                            break;
                        case (int)Const.Nav.WEST:
                            if (CheckCoordsForBlock(shipCoords[i].yCoord, shipCoords[i].xCoord - 1, i_GameMapArray, shipCoords) == Const.BlockChecks.SHIP)
                            {
                                return false;
                            }
                            break;
                    }
                } 
            }

            return true;
        }

        /// <summary>
        /// Confirms if all the needed Coords for the selected Ships are availible
        /// </summary>
        /// <param name="i_nav">actNav</param>
        /// <param name="i_selectedShip">selectedShip(Typ)</param>
        /// <param name="i_btnCoords">the Coords of the selected button</param>
        /// <param name="i_GameMapArray">GameMapArray</param>
        /// <returns>retruns true if all needed Coords are availible</returns>
        public static bool ConfirmCoords(Const.Nav i_nav, int i_selectedShip, Coords i_btnCoords, GameBoardField[,] i_GameMapArray)
        {
            bool retVal = true;
            for (int i = 0; i < Ship.GetShipLength(i_selectedShip); i++)
            {
                switch (i_nav)
                {
                    case Const.Nav.NORTH:
                        if (!CheckCoords(i_btnCoords.yCoord + i, i_btnCoords.xCoord, i_GameMapArray))
                        {
                            retVal = false;
                            break;
                        }
                        break;
                    case Const.Nav.EAST:
                        if (!CheckCoords(i_btnCoords.yCoord, i_btnCoords.xCoord - i, i_GameMapArray))
                        {
                            retVal = false;
                            break;
                        }
                        break;
                    case Const.Nav.SOUTH:
                        if (!CheckCoords(i_btnCoords.yCoord - i, i_btnCoords.xCoord, i_GameMapArray))
                        {
                            retVal = false;
                            break;
                        }
                        break;
                    case Const.Nav.WEST:
                        if (!CheckCoords(i_btnCoords.yCoord, i_btnCoords.xCoord + i, i_GameMapArray))
                        {
                            retVal = false;
                            break;
                        }
                        break;
                }
            }
            return retVal;
        }

        /// <summary>
        /// Confirms if all the needed Coords for the selected Ships are availible and fills the i_placeCoords with default values
        /// </summary>
        /// <param name="i_nav">actNav</param>
        /// <param name="i_selectedShip">selectedShip(Typ)</param>
        /// <param name="i_btnCoords">the Coords of the selected button</param>
        /// <param name="i_placeCoords">array of all the needed Coords</param>
        /// <param name="i_GameMapArray">GameMapArray</param>
        /// <returns>retruns true if all needed Coords are availible</returns>
        public static bool ConfirmCoords(Const.Nav i_nav, int i_selectedShip, Coords i_btnCoords, GameBoardField[,] i_GameMapArray, Coords[] i_placeCoords)
        {
            bool retVal = true;
            for (int i = 0; i < Ship.GetShipLength(i_selectedShip); i++)
            {
                switch (i_nav)
                {
                    case Const.Nav.NORTH:
                        if (!CheckCoords(i_btnCoords.yCoord + i, i_btnCoords.xCoord, i_GameMapArray))
                        {
                            retVal = false;
                            break;
                        }
                        break;
                    case Const.Nav.EAST:
                        if (!CheckCoords(i_btnCoords.yCoord, i_btnCoords.xCoord - i, i_GameMapArray))
                        {
                            retVal = false;
                            break;
                        }
                        break;
                    case Const.Nav.SOUTH:
                        if (!CheckCoords(i_btnCoords.yCoord - i, i_btnCoords.xCoord, i_GameMapArray))
                        {
                            retVal = false;
                            break;
                        }
                        break;
                    case Const.Nav.WEST:
                        if (!CheckCoords(i_btnCoords.yCoord, i_btnCoords.xCoord + i, i_GameMapArray))
                        {
                            retVal = false;
                            break;
                        }
                        break;
                }
                i_placeCoords[i] = new Coords(0, 0);
            }

            return retVal;
        }


        /// <summary>
        /// Checks if Coords are in the array range (0-11) and if the Fieldstate of the given Coords is FREE
        /// </summary>
        /// <param name="yCoord">Coords.yCoord</param>
        /// <param name="xCoord">Coords.xCoords</param>
        /// <param name="i_GameMapArray">GameMapArray</param>
        /// <returns>true if the given Coords are FREE and between 0-11</returns>
        public static bool CheckCoords(int yCoord, int xCoord, GameBoardField[,] i_GameMapArray)
        {
            bool retVal = true;

            if (yCoord > 11 || yCoord < 0)
            {
                retVal = false;
            }
            if (xCoord > 11 || xCoord < 0)
            {
                retVal = false;
            }

            if (retVal)
            {
                if (i_GameMapArray[yCoord, xCoord].fieldState != Const.FieldState.FREE)
                {
                    retVal = false;
                }
            }

            return retVal;
        }

        public static Const.BlockChecks CheckCoordsForBlock(int yCoord, int xCoord, GameBoardField[,] i_GameMapArray, Coords[] thisShip)
        {
            Const.BlockChecks retVal = Const.BlockChecks.FREE;
           
            if (yCoord > 11 ||yCoord < 0)
            {
                retVal = Const.BlockChecks.NOT_IN_RANGE;
            }
            if (xCoord > 11 || xCoord < 0)
            {
                retVal = Const.BlockChecks.NOT_IN_RANGE;
            }
            if (retVal == Const.BlockChecks.FREE)
            {
                if (i_GameMapArray[yCoord, xCoord].fieldState == Const.FieldState.SHIP)
                {
                    if (!CheckIfCoordsOfThisShip(thisShip, yCoord, xCoord))
                    {
                        retVal = Const.BlockChecks.SHIP;
                    }
                }
            }


            return retVal;
        }

        public static bool CheckIfCoordsOfThisShip(Coords[] thisShip, int yCoord, int xCoord)
        {
            Coords i_Coords = new Coords(yCoord, xCoord);
            foreach(Coords thisShipCoords in thisShip)
            {
                if(CompareCoords(thisShipCoords, i_Coords))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Get the next Coords depending on the actual Navigation-Direction and a string by reference with the actual direction
        /// </summary>
        /// <param name="i_nav">actNav</param>
        /// <param name="i_nextCoords">the Coords from the selected button</param>
        /// <param name="nextCoordExt">the iterator</param>
        /// <param name="i_styleDirection">string by reference to get the direction postfix for the right button style</param>
        public static void GetNextCoordsByDirection(Const.Nav i_nav, Coords i_nextCoords, int nextCoordExt, ref string i_styleDirection)
        {
            switch (i_nav)
            {
                case Const.Nav.NORTH:
                    i_nextCoords.yCoord += nextCoordExt == 0 ? 0 : 1;
                    i_styleDirection = "_NORTH";
                    break;
                case Const.Nav.EAST:
                    i_nextCoords.xCoord -= nextCoordExt == 0 ? 0 : 1;
                    i_styleDirection = "_EAST";
                    break;
                case Const.Nav.SOUTH:
                    i_nextCoords.yCoord -= nextCoordExt == 0 ? 0 : 1;
                    i_styleDirection = "_SOUTH";
                    break;
                case Const.Nav.WEST:
                    i_nextCoords.xCoord += nextCoordExt == 0 ? 0 : 1;
                    i_styleDirection = "_WEST";
                    break;
            }
        }

        /// <summary>
        /// Get the next Coords depending on the actual Navigation-Direction
        /// </summary>
        /// <param name="i_nav">actNav</param>
        /// <param name="i_nextCoords">the Coords from the selected button</param>
        /// <param name="nextCoordExt">the iterator</param>
        public static void GetNextCoordsByDirection(Const.Nav i_nav, Coords i_nextCoords, int nextCoordExt)
        {
            switch (i_nav)
            {
                case Const.Nav.NORTH:
                    i_nextCoords.yCoord += nextCoordExt == 0 ? 0 : 1;
                    break;
                case Const.Nav.EAST:
                    i_nextCoords.xCoord -= nextCoordExt == 0 ? 0 : 1;
                    break;
                case Const.Nav.SOUTH:
                    i_nextCoords.yCoord -= nextCoordExt == 0 ? 0 : 1;
                    break;
                case Const.Nav.WEST:
                    i_nextCoords.xCoord += nextCoordExt == 0 ? 0 : 1;
                    break;
            }
        }
    }
}
