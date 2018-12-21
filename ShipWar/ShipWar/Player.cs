using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nocksoft.IO.ConfigFiles;
using System.IO;

namespace ShipWar
{
    public class Player
    {
        #region Player Const +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        #region ini-File
        // .ini-File - Config
        public static string iniPath = Path.Combine(Const.iniFolderPath, "PlayerData.ini");
        // .ini-File - Section - Extras for File Section
        public const string fsX_playerCnt = "Player-Count";
        public const string fsX_playerCnt_def = "0";
        // .ini-File - Section - player Section
        public const string playerSec = "player";
        public const string pS_playerId = "Id";
        public const string pS_name = "Name";
        public const string pS_points = "Punkte";
        public const string pS_points_def = "0";
        #endregion
        #endregion

        public int playerId;
        public string playerName;
        public int playerPoints;

        public Player(bool addNewOne = false)
        {
            if (addNewOne)
            {
                INIFile pIni = new INIFile(iniPath);
                playerId = Convert.ToInt32(pIni.GetValue(Const.fileSec, fsX_playerCnt)) + 1;
                playerPoints = 0;
                playerName = String.Empty;
            }
        }

        #region Setter
        public void Setter()
        {
            INIFile playerData = new INIFile(iniPath);
            playerData.SetValue(Player.playerSec + Convert.ToString(this.playerId), Player.pS_name, this.playerName);
            playerData.SetValue(Player.playerSec + Convert.ToString(this.playerId), Player.pS_points, Convert.ToString(this.playerPoints));

            if (playerId > Convert.ToInt32(playerData.GetValue(Const.fileSec, fsX_playerCnt)))
            {
                playerData.SetValue(Const.fileSec, Player.fsX_playerCnt, Convert.ToString(this.playerId));
            }
        }
        #endregion

        #region Getter
        public void Getter(int i_Id)
        {
            INIFile playerData = new INIFile(iniPath);
            if (Const.CheckIdInRange(playerData, Const.fileSec, fsX_playerCnt, i_Id))
            {
                playerId = i_Id;
                playerName = playerData.GetValue(playerSec + Convert.ToString(i_Id), pS_name);
                playerPoints = Convert.ToInt32(playerData.GetValue(playerSec + Convert.ToString(i_Id), pS_points));
            }
        }
        #endregion

        #region Checks

        public static bool CheckIfPlayerExists(string i_name)
        {
            INIFile playerData = new INIFile(iniPath);
            for (int i = 1; i <= Convert.ToInt32(playerData.GetValue(Const.fileSec, fsX_playerCnt)); i++)
            {
                if (playerData.GetValue(Player.playerSec + Convert.ToString(i), Player.pS_name) == i_name)
                {
                    return true;
                }
            }

            return false;
        }

        #endregion

    }
}
