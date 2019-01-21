using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

using CodeAssignProcess;

namespace ProcessFile
{
    class Program
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

     
        static int Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("No arguments passed. Usage: ProcessFile.exe fileName fileFormat sortOption ");
                log.Error("No arguments passed");
                return -1;
            }

            try
            {
                string filePath = ConfigurationManager.AppSettings["FileDirectory"];
                string fileName = filePath + args[0];
                Console.WriteLine(fileName);

                int fileType = 0;
                if (!int.TryParse(args[1], out fileType))
                {
                    Console.WriteLine("Invalid fileType. Must be 1 (pipe), 2 (space), or 3 (csv). ");
                    log.Error("Invalid fileType");
                    return -1;
                }
                else
                {
                    if (fileType != 1 && 
                        fileType != 2 && 
                        fileType != 3)
                    {
                        Console.WriteLine("Invalid fileType. Must be 1 (pipe), 2 (space), or 3 (csv). ");
                        log.Error("Invalid fileType");
                        return -1;
                    }
                }

                InputFileProcessor fileInputProcess = new InputFileProcessor();
                List<InputData> inputList = fileInputProcess.ReadFile(fileName, fileType)
                    .ToList();

                int sortOrder = 0;
                if (!int.TryParse(args[2], out sortOrder))
                {
                    Console.WriteLine("Invalid sort order. Must be 1, 2 or 3 ");
                    log.Error("Invalid fileType");
                    return -1;
                }

                fileInputProcess.DisplayFile(inputList, sortOrder);
               
            }
            catch (FileNotFoundException fileEx)
            {
                log.Error("File not found. Please check input. Exception: " + fileEx.Message + " FileName: " + fileEx.FileName);
            }
            catch (Exception ex)
            {
                log.Error("ProcessFile program exception occurred: " + ex.Message);
            }

            return 0;
        }
      
    }
}
