using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Nocksoft.IO.ConfigFiles;

namespace ShipWar
{
    public class Const
    {
        #region 1 - .ini-File - Folder ----------------------------------------------------------------------------------------------------------------------------------------------------------
        
        /// <summary>
        /// Name of the folder which containts all .ini-Files
        /// </summary>
        public static string iniFileFolder = "iniFiles";
        
        /// <summary>
        /// Holds current directory 
        /// </summary>
        public static string CurDirPath = Directory.GetCurrentDirectory();
        
        /// <summary>
        /// Holds path to the actual .ini-File-Folder
        /// </summary>
        public static string iniFolderPath = Path.Combine(CurDirPath, iniFileFolder);
        
        #endregion
        #region 2 - .ini-File - Section - standard file section ---------------------------------------------------------------------------------------------------------------------------------
        
        /// <summary>
        /// main section in every .ini-File
        /// <para>holds all counter and global states</para>
        /// </summary>
        public const string fileSec = "file-section";
        
        /// <summary>
        /// initialization State
        /// <para>0 -> no virgin anymore</para>
        /// </summary>
        public const string fs_InitState = "Initialition-State";

        public const string fs_InitState_def = "1";
        public const string fs_TimeStamp = "Time-Stamp";

        #endregion
        #region 3 - Const Functions -------------------------------------------------------------------------------------------------------------------------------------------------------------

        //   -> 3.1 SetIniTimeStamp
        /// <summary>
        /// Sets actual date and time in .ini-File
        /// </summary>
        /// <param name="i_ini">.ini-File Path which has been changed</param>
        public static void SetIniTimeStamp(INIFile i_ini)
        {
            i_ini.SetValue(fileSec, fs_TimeStamp, Convert.ToString(DateTime.Now));
        }
        
        //   -> 3.2 CheckIdInRange
        /// <summary>
        /// Checks if requested Id is in the range of .ini-File
        /// </summary>
        /// <param name="i_ini">.ini-File which contains requested data</param>
        /// <param name="i_section">name of the section which contains the entry-count-key</param>
        /// <param name="i_key">name of the key which containts the entry-count-value</param>
        /// <param name="i_id">Id which should be checked</param>
        /// <returns>true if Id is in Range</returns>
        public static bool CheckIdInRange(INIFile i_ini, string i_section, string i_key, int i_id)
        {
            bool ret = false;
            string maxId = i_ini.GetValue(i_section, i_key);
            if (i_id > 0 && i_id <= Convert.ToInt32(maxId))
            {
                ret = true;
            }
            return ret;
        }
        #endregion
        #region 4 - Const Values ----------------------------------------------------------------------------------------------------------------------------------------------------------------

        public enum FieldState
        {
            FREE,
            SHIP,
            MISS,
            HIT,
            CCI_OLD_HIT,
            SUNKENSHIP,
            BLOCKED,
            DOUBLE_BLOCKED
        }

        public enum Nav
        {
            NORTH,
            EAST,
            SOUTH,
            WEST
        }

        public enum BlockChecks
        {
            FREE,
            THIS_SHIP,
            NOT_IN_RANGE,
            SHIP
        }
        #endregion
    }
}
