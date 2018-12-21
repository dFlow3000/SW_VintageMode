using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ShipWar
{
    public class GameBoardField
    {
        public Button fieldButton;
        public Coords fieldCoords;
        public Ship ship;
        public Const.FieldState fieldState;

        public GameBoardField(Button i_Button)
        {
            fieldButton = i_Button;
            fieldCoords = Coords.GetBtnCoords(i_Button.Uid);
            fieldState = Const.FieldState.FREE;
        }
    }
}
