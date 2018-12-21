using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipWar
{
    public class PlacedShips
    {
        public Coords[] shipCoords;
        public Coords[,] blockedCoords;
        public int shipTyp;
        public bool isSet;
        public PlacedShips(int i_ShipTyp)
        {
            shipTyp = i_ShipTyp;
            shipCoords = new Coords[Ship.GetShipLength(shipTyp)];
            blockedCoords = new Coords[Ship.GetShipLength(shipTyp), 4];
            for (int i = 0; i < Ship.GetShipLength(shipTyp); i++)
            {
                shipCoords[i] = new Coords();
                for (int x = 0; x < 4; x++)
                {
                    blockedCoords[i,x] = new Coords(-1, -1);
                }
            }

            isSet = false;
        }

    }
}
