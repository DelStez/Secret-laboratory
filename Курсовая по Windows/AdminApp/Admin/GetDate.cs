using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin
{
    public class GetDate
    {
        public string ParseCommand(string command)
        {
            string result = "<GetDateResult>";
            if (command.Contains("-D"))
            {
                result += GetDisk().ToString()+"\n";
            }
            if (command.Contains("-I"))
            {
                result += GetInformation();
            }
            if (command.Contains("-R"))
            {

            }
            return result;

        }
        public StringBuilder GetDisk()
        {
            StringBuilder driveList = new StringBuilder();
            foreach (DriveInfo d in DriveInfo.GetDrives())
            {
                if (d.IsReady) driveList.AppendLine(String.Format("Диск: {0}; метка тома: {1}; файловая система: {2}; тип: {3}; объем: {4} байт; свободно: {5} байт", d.Name, d.VolumeLabel, d.DriveFormat, d.DriveType, d.TotalSize, d.AvailableFreeSpace));
            }
            return driveList;
        }
        public string GetInformation()
        {
            string PatchProfile = Environment.GetEnvironmentVariable("C:/");
            string[] S = SearchDirectory(PatchProfile);
            string ListPatch = "Файлы";
            foreach (string folderPatch in S)
            {
                //добавляем новую строку в список
                // ListPatch += folderPatch + "\n";
                try
                {
                    //пытаемся найти данные в папке 
                    string[] F = SearchFile(folderPatch);
                    foreach (string FF in F)
                    {
                        //добавляем файл в список 
                        ListPatch += FF + "\n";
                    }
                }
                catch
                {
                }
            }
            return ListPatch;

        }
        static string[] SearchFile(string patch)
        {
            /*флаг SearchOption.AllDirectories означает искать во всех вложенных папках*/
            string[] ReultSearch = Directory.GetFiles(patch, "*", SearchOption.AllDirectories);
            //возвращаем список найденных файлов соответствующих условию поиска 
            return ReultSearch;
        }
        static string[] SearchDirectory(string patch)
        {
            //находим все папки в по указанному пути
            string[] ReultSearch = Directory.GetDirectories(patch);
            //возвращаем список директорий
            return ReultSearch;
        }
    }
}
