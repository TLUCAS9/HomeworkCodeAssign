using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using CodeAssignProcess;
using System.Collections;

namespace CodeAssignProcess
{
    interface IFileProcessor
    {
        IEnumerable<InputData> ReadFile(string fullFilePath, int fileType);
        void DisplayFile(IEnumerable<InputData> inputList, int sortOrder);
     }
}
