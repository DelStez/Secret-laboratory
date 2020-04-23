using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.MSBuild;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace MutatorProject
{
    public enum StatusOfMutationResult
    {
        Killed,
        Alive,
        SomethingWrong
    }
    internal class StartMutatorCore : Form1
    {
        public static string SolutionPath;
        public static string ProjecrPath;
        public static string Logger;
        public static Project currentProject;
        public static List<CodeFile> codes;

        public StartMutatorCore(string path)
        {
            ProjecrPath = path;
        }
        public static string GetProjectsFiles()
        {
            MSBuildWorkspace workspace = MSBuildWorkspace.Create();
            currentProject = workspace.OpenProjectAsync(ProjecrPath).Result;
            Logger = $" ";
            return Logger;
        }
        public static void ProjectAnalysis()
        {
            codes = new List<CodeFile>();
            var dirName = Path.GetDirectoryName(currentProject.FilePath);
            var dir = new DirectoryInfo(dirName);
            using (var fs = new FileStream(currentProject.FilePath, FileMode.Open, FileAccess.Read))
            {
                using (var reader = XmlReader.Create(fs))
                {
                    while (reader.Read())
                    {
                        if (reader.Name.Equals("Compile", StringComparison.OrdinalIgnoreCase))
                        {
                            var fn = reader["Include"];
                            var filePath = Path.Combine(dirName, fn);
                            var text = File.ReadAllText(filePath);
                            codes.Add(new CodeFile(fn, text));
                        }
                    }
                }
            }
            


        }
    }
}
