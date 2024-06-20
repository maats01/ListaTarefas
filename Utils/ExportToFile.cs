using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace ListaTarefas.Utils
{
    public class ExportToFile
    {
        private const string dir = @"C:\Users\Matheus\Desktop\UNOESC\ListaTarefas\TarefasSalvas";
        public static bool SaveToDelimitedTxt(string fileName, string fileContent)
        {
            string filePath = @$"{dir}\{fileName}";

            try
            {
                if(!Directory.Exists(dir))
                    Directory.CreateDirectory(dir);
                
                using(StreamWriter sw = File.CreateText(filePath))
                {
                    sw.Write(fileContent);
                }
            }
            catch
            {
                return false;
            }

            return true;
        }
    }
}