﻿/**
 * Copyright by Nocksoft
 * https://www.nocksoft.de
 * https://nocksoft.de/tutorials/visual-c-sharp-arbeiten-mit-ini-dateien/
 * -----------------------------------
 * Erstellt von:	Rafael Nockmann
 * Letzte Änderung:	23.08.2017
 * Version:         1.0.3
 *
 * Sprache: Visual C#
 *
 * Lizenz: https://nocksoft.de/downloads/_lizenzen/nocksoft-lizenz-quellcode.txt
 * 
 * Beschreibung:
 * Stellt grundlegende Funktionen bereit, um mit INI-Dateien zu arbeiten.
 *
 * ##############################################################################################
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using ShipWar;

namespace Nocksoft.IO.ConfigFiles
{
    public class INIFile
    {
        private string _File;

        /// <summary>
        /// Aufruf des Konstruktors initialisiert ein Objekt der Klasse INIFile.
        /// </summary>
        /// <param name="file">INI-Datei, auf der zugegriffen werden soll.</param>
        /// <param name="createFile">Gibt an, ob die Datei erstellt werden soll, wenn diese nicht vorhanden ist.</param>
        public INIFile(string file, bool createFile = false)
        {
            if(createFile == true && File.Exists(file) == false)
            {
                FileInfo fileInfo = new FileInfo(file);
                FileStream fileStream = fileInfo.Create();
                fileStream.Close();
            }
            _File = file;
        }

        #region Öffentliche Methoden

        public static INIFile CreateIniFile(string i_iniPath)
        {
            INIFile newIniFile = new INIFile(i_iniPath, true);
            newIniFile.SetValue(Const.fileSec, Const.fs_InitState, Const.fs_InitState_def);
            Const.SetIniTimeStamp(newIniFile);

            if (i_iniPath == Player.iniPath)
            {
                newIniFile.SetValue(Const.fileSec, Player.fsX_playerCnt, Player.fsX_playerCnt_def);
            }

            return newIniFile;
        }

        public static INIFile CheckIfIniExists(string i_iniPath)
        {
            INIFile i_File;
            if (!File.Exists(i_iniPath))
            {
                i_File = CreateIniFile(i_iniPath);
            }
            else
            {
                i_File = new INIFile(i_iniPath);
            }

            return i_File;
        }

        /// <summary>
        /// Entfernt alle Kommentare und leeren Zeilen aus einer kompletten Section und gibt diese zurück.
        /// Die Methode ist nicht Case-sensitivity und ignoriert daher Groß- und Kleinschreibung.
        /// Der Rückgabewert enthält keine Leerzeichen.
        /// </summary>
        /// <param name="section">Name der angeforderten Section.</param>
        /// <param name="getComments">Gibt an, ob Kommentare berücksichtigt werden sollen.</param>
        /// <returns>Gibt die komplette Section zurück.</returns>
        public List<string> GetSection(string section, bool getComments = false)
        {
            // Stellt sicher, dass eine Section immer im folgenden Format vorliegt: [section]
            section = CheckSection(section);

            List<string> completeSection = new List<string>();
            bool sectionStart = false;

            // Liest die Zieldatei ein
            string[] fileArray = File.ReadAllLines(_File);

            foreach (var item in fileArray)
            {
                if (item.Length <= 0) continue;

                // Wenn die gewünschte Section erreicht ist
                if (item.Replace(" ", "").ToLower() == section)
                {
                    sectionStart = true;
                }
                // Wenn auf eine neue Section getroffen wird, wird die Schleife beendet
                if (sectionStart == true && item.Replace(" ", "").ToLower() != section && item.Replace(" ", "").Substring(0, 1) == "[" && item.Replace(" ", "").Substring(item.Length - 1, 1) == "]")
                {
                    break;
                }
                if (sectionStart == true)
                {
                    // Wenn der Eintrag kein Kommentar und kein leerer Eintrag ist, wird er der List<string> completeSection hinzugefügt
                    if (getComments == false
                        && item.Replace(" ", "").Substring(0, 1) != ";" && !string.IsNullOrWhiteSpace(item))
                    {
                        completeSection.Add(ReplaceScpacesAtStartAndEnd(item));
                    }
                    if (getComments == true && !string.IsNullOrWhiteSpace(item))
                    {
                        completeSection.Add(ReplaceScpacesAtStartAndEnd(item));
                    }
                }
            }
            return completeSection;
        }

        /// <summary>
        /// Die Methode gibt einen Wert zum dazugehörigen Key zurück.
        /// Die Methode ist nicht Case-sensitivity und ignoriert daher Groß- und Kleinschreibung.
        /// </summary>
        /// <param name="section">Name der angeforderten Section.</param>
        /// <param name="key">Name des angeforderten Keys.</param>
        /// <param name="convertKeyToLower">Wenn "true" übergeben wird, wird der Rückgabewert in Kleinbuchstaben zurückgegeben.</param>
        /// <returns>Gibt, wenn vorhanden, den Wert zu dem angegebenen Key in der angegeben Section zurück.</returns>
        public string GetValue(string section, string key, bool convertValueToLower = false)
        {
            // Stellt sicher, dass eine Section immer im folgenden Format vorliegt: [section]
            section = CheckSection(section);
            key = key.ToLower();

            List<string> completeSection = GetSection(section);

            foreach (var item in completeSection)
            {
                // In Schleife fortfahren, wenn kein Key
                if (!item.Contains("=") && item.Contains("[") && item.Contains("]")) continue;

                string[] keyAndValue = item.Split(new string[] { "=" }, StringSplitOptions.RemoveEmptyEntries);
                if (keyAndValue[0].ToLower() == key && keyAndValue.Count() > 1)
                {
                    if (convertValueToLower == true)
                    {
                        keyAndValue[1] = keyAndValue[1].ToLower();
                    }
                    return keyAndValue[1];
                }
            }
            return null;
        }

        /// <summary>
        /// Ändert einen Wert des dazugehörigen Schlüssels in der angegebenen Section.
        /// </summary>
        /// <param name="section">Name der Section, in dem sich der Schlüssel befindet.</param>
        /// <param name="key">Name des Schlüssels, dessen Wert geändert werden soll.</param>
        /// <param name="value">Neuer Wert.</param>
        /// <param name="convertValueToLower">Wenn "true" übergeben wird, wird der Wert in Kleinbuchstaben gespeichert.</param>
        public void SetValue(string section, string key, string value, bool convertValueToLower = false)
        {
            // Stellt sicher, dass eine Section immer im folgenden Format vorliegt: [section]
            section = CheckSection(section);
            string keyToLower = key.ToLower();

            // Prüft, ob die gesuchte Section gefunden wurde
            bool sectionFound = false;

            List<string> newFileContent = new List<string>();

            // Liest die Zieldatei ein
            string[] fileLines = File.ReadAllLines(_File);

            // Wenn die Zieldatei leer ist...
            if (fileLines.Length <= 0)
            {
                newFileContent = CreateSection(newFileContent, section, value, key, convertValueToLower);
                WriteFile(newFileContent);
                return;
            }

            // ...sonst wird jede Zeile durchsucht
            for (int i = 0; i < fileLines.Length; i++)
            {
                // Option 1 -> Gewünschte Section wurde (noch) nicht gefunden
                if (fileLines[i].Replace(" ", "").ToLower() != section)
                {
                    newFileContent.Add(fileLines[i]);
                    // Wenn Section nicht vorhanden ist, wird diese erzeugt
                    if (i == fileLines.Length - 1 && fileLines[i].Replace(" ", "").ToLower() != section && sectionFound == false)
                    {
                        newFileContent.Add(null);
                        newFileContent = CreateSection(newFileContent, section, value, key, convertValueToLower);
                        break;
                    }
                    continue;
                }


                // Option 2 -> Gewünschte Section wurde gefunden
                sectionFound = true;

                // Enthält die komplette Section, in der sich der Zielschlüssel befindet
                List<string> targetSection = GetSection(section, true);

                // Jeden Eintrag in der Section, in der sich der Zielschlüssel befindet, durchgehen
                for (int x = 0; x < targetSection.Count; x++)
                {
                    string[] targetKey = targetSection[x].Split(new string[] { "=" }, StringSplitOptions.None);
                    // Wenn der Zielschlüssel gefunden ist
                    if (targetKey[0].ToLower() == keyToLower)
                    {
                        // Prüft, in welcher Schreibweise die Werte abgespeichert werden sollen
                        if (convertValueToLower == true)
                        {
                            newFileContent.Add(keyToLower + "=" + value.ToLower());
                        }
                        else
                        {
                            newFileContent.Add(key + "=" + value);
                        }
                        i = i + x;
                        break;
                    }
                    else
                    {
                        newFileContent.Add(targetSection[x]);
                        // Wenn Key nicht vorhanden ist, wird dieser erzeugt
                        if (x == targetSection.Count - 1 && targetKey[0].ToLower() != keyToLower)
                        {
                            // Prüft, in welcher Schreibweise die Werte abgespeichert werden sollen
                            if (convertValueToLower == true)
                            {
                                newFileContent.Add(keyToLower + "=" + value.ToLower());
                            }
                            else
                            {
                                newFileContent.Add(key + "=" + value);
                            }
                            i = i + x;
                            break;
                        }
                    }
                }
            }

            WriteFile(newFileContent);
        }

        // Löschen aus dem .ini-File
        public void DeleteFromIni(string i_filepath, string i_deletestring, int i_linesToDelete, bool i_specialTrim = false)
        {
            // Löschvorgang

            // Das File wird Zeile für Zeile in das Array actfile geladen
            string[] actfile = File.ReadAllLines(i_filepath);
            int cnt = 0;

            // deletestring enthält den String nachdem im File gesucht werden soll

            // das Array actfile Zeile für Zeile nach dem deletestring durchsuchen
            foreach (string s in actfile)
            {
                if (i_specialTrim)
                {
                    if (string.Compare(s, 0, i_deletestring, 0, i_deletestring.Length) == 0)
                    {
                        //deletestring wurde gefunden, jetzt ab der aktuellen Zeile bis zur Zeile "aktuelle Zeile + sektionLength" auf null setzen
                        Array.Clear(actfile, cnt, i_linesToDelete);
                        break;
                    }
                }
                else
                {

                    if (s == i_deletestring)
                    {
                        //deletestring wurde gefunden, jetzt ab der aktuellen Zeile bis zur Zeile "aktuelle Zeile + sektionLength" auf null setzen
                        Array.Clear(actfile, cnt, i_linesToDelete);
                        break;
                    }
                }
                cnt++;
            }

            bool writeFirstLine = true;

            // das Array bis auf die Zeilen mit Wert null ins File zurückschreiben
            foreach (string s in actfile)
            {
                if (s != null)
                {
                    if (writeFirstLine)
                    {
                        // Das Schreiben der ersten Zeile löscht den Inhalt des Files 
                        File.WriteAllText(i_filepath, s + Environment.NewLine);
                        writeFirstLine = false;
                    }
                    else
                    {
                        // Restliche Zeilen an die erste Zeile im File anhängen
                        string addstring = s + Environment.NewLine;
                        File.AppendAllText(i_filepath, addstring);
                    }
                }
            }
        }

        #endregion

        #region Private Methoden

        /// <summary>
        /// Stellt sicher, dass eine Section immer im folgenden Format vorliegt: [section]
        /// </summary>
        /// <param name="section">Section, die auf korrektes Format geprüft werden soll.</param>
        /// <returns>Gibt Section in dieser Form zurück: [section]</returns>
        private string CheckSection(string section)
        {
            section = section.ToLower();
            if (section.Substring(0, 1) != "[" && section.Substring(section.Length - 1, 1) != "]")
            {
                section = "[" + section + "]";
            }
            return section;
        }

        /// <summary>
        /// Entfernt voranstehende und hintenstehende Leerzeichen bei Sections, Keys und Values.
        /// </summary>
        /// <param name="item">String, der gekürzt werden soll.</param>
        /// <returns>Gibt einen gekürzten String zurück.</returns>
        private string ReplaceScpacesAtStartAndEnd(string item)
        {
            // Wenn der Eintrag einen Schlüssel und einen Wert hat
            if (item.Contains("=") && !item.Contains("[") && !item.Contains("]"))
            {
                string[] keyAndValue = item.Split(new string[] { "=" }, StringSplitOptions.None);
                return keyAndValue[0].Trim() + "=" + keyAndValue[1].Trim();
            }

            return item.Trim();
        }

        /// <summary>
        /// Legt eine neue Section an.
        /// </summary>
        /// <param name="newSettings">Liste newSettings aus SetValue.</param>
        /// <param name="section">section die angelegt werden soll.</param>
        /// <param name="value">Wert der hinzugefügt werden soll.</param>
        /// <param name="key">Schlüssel der hinzugefügt werden soll.</param>
        /// <param name="convertValueToLower">Gibt an, ob Schlüssel und Wert in Kleinbuchstaben abgespeichert werden sollen.</param>
        /// <returns></returns>
        private List<string> CreateSection(List<string> newSettings, string section, string value, string key, bool convertValueToLower)
        {
            string keyToLower = key.ToLower();

            newSettings.Add(section);
            // Prüft, in welcher Schreibweise die Werte abgespeichert werden sollen
            if (convertValueToLower == true)
            {
                newSettings.Add(keyToLower + "=" + value.ToLower());
            }
            else
            {
                newSettings.Add(key + "=" + value);
            }
            return newSettings;
        }

        private void WriteFile(List<string> content)
        {
            StreamWriter writer = new StreamWriter(_File);
            foreach (var item in content)
            {
                writer.WriteLine(item);
            }
            writer.Close();
        }

        #endregion
    }
}
