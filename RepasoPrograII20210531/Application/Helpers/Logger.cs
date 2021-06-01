using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Files;
using Application.Files.Text;
using static System.Net.Mime.MediaTypeNames;

namespace Application.Helpers
{
    public static class Logger
    {
        public static void LogException(string log)
        {
            DateTime tiempoActual = DateTime.Now;
            IFile<string> fileService = new Text<string>();
            string path = $"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\\log.txt";
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Hora: {0}, Mensaje excepcion: {1}\n", log, tiempoActual);

            fileService.Save(path,sb.ToString());


        }
    }
}
