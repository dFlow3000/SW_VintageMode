using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipWar
{
    public class ComputerCoordsIntelligence
    {
        public CCI_Coords[] cciCoords = new CCI_Coords[4];
        public ComputerCoordsIntelligence(Coords i_Coords, GameBoardField[,] UserGameMap)
        {
            for (int i = 0; i < 4; i++)
            {
                cciCoords[i] = new CCI_Coords(i_Coords, i, UserGameMap);
            }
        }

        public void SetCCI_CoordsFieldState(ComputerCoordsIntelligence cciCoords, Coords i_Coords, Const.FieldState i_State)
        {
            for(int i= 0; i < 4; i++) 
            {
                if(Coords.CompareCoords(cciCoords.cciCoords[i].cciCoords, i_Coords))
                {
                    cciCoords.cciCoords[i].CoordIs = i_State;
                }
            }
        }
    }

    public class CCI_Coords
    {
        public Coords cciCoords;
        public Const.FieldState CoordIs;
        public CCI_Coords(Coords i_Coords, int nav, GameBoardField[,] UserGameMap)
        {
            switch (nav)
            {
                case (int)Const.Nav.NORTH:
                    cciCoords = new Coords(i_Coords.yCoord - 1, i_Coords.xCoord);
                    CoordIs = CheckCoordsFieldState(cciCoords, UserGameMap);
                    break;
                case (int)Const.Nav.EAST:
                    cciCoords = new Coords(i_Coords.yCoord, i_Coords.xCoord + 1);
                    CoordIs = CheckCoordsFieldState(cciCoords, UserGameMap);
                    break;
                case (int)Const.Nav.SOUTH:
                    cciCoords = new Coords(i_Coords.yCoord + 1, i_Coords.xCoord);
                    CoordIs = CheckCoordsFieldState(cciCoords, UserGameMap);
                    break;
                case (int)Const.Nav.WEST:
                    cciCoords = new Coords(i_Coords.yCoord, i_Coords.xCoord - 1);
                    CoordIs = CheckCoordsFieldState(cciCoords, UserGameMap);
                    break;
            }
        }

        private Const.FieldState CheckCoordsFieldState(Coords i_Coords, GameBoardField[,] UserGameMap)
        {
            if (i_Coords.yCoord > 11 || i_Coords.yCoord < 0)
            {
                return Const.FieldState.MISS;
            }
            if (i_Coords.xCoord > 11 || i_Coords.xCoord < 0)
            {
                return Const.FieldState.MISS;
            }

            if (UserGameMap[i_Coords.yCoord, i_Coords.xCoord].fieldState == Const.FieldState.MISS)
            {
                return Const.FieldState.MISS;
            }

            if(UserGameMap[i_Coords.yCoord, i_Coords.xCoord].fieldState == Const.FieldState.HIT)
            {
                return Const.FieldState.HIT;
            }

            return Const.FieldState.FREE;
        }
    }
}


