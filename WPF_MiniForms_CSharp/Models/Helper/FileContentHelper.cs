﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_MiniForms_CSharp.Models.Helper
{
    internal class FileContentHelper
    {
        internal IEnumerable<string> GetFileContent(string filePath)
        {
            return File.ReadAllLines(filePath);
        }

        internal IEnumerable<string> ReplaceText (string file, string textTarget, string? textReplacement) 
        {
            if(string.IsNullOrEmpty(textTarget))
                throw new InvalidDataException("There is no text to replace.");

            if (File.Exists(file) == false)
                throw new FileNotFoundException(file);
            
            var fileContent = File.ReadAllLines(file);
            if (fileContent.Length == 0)
                throw new InvalidDataException("There is no eligible text within the selected file.");
            
            var fileContentReplaced = new List<string>();
            
            foreach (string line in fileContent)
            {
                if (line.Contains(textTarget))
                    fileContentReplaced.Add(line.Replace(textTarget ?? "", textReplacement));
                else
                    fileContentReplaced.Add(line);
            }
            if (fileContentReplaced.Count <= 0)
                throw new Exception("The replacement process didn't succeed.");

            return fileContentReplaced;
        }
    }
}
