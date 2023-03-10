using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using System;
using System.Collections.Generic;
using System.IO;
using WPF_MiniForms_CSharp.Models.Functions;

namespace WPF_MiniForms_CSharp.Models.Helper
{
    public class FileContentHelper
    {
        public void ConvertFileToPDF(string filePath)
        {
            FolderFunctions folderFunctions = new FolderFunctions();
            var tempFolder = folderFunctions.GetTemporaryDirectory();
            PdfWriter writer = new PdfWriter(tempFolder + "demo.pdf");
            PdfDocument pdf = new PdfDocument(writer);
            Document document = new Document(pdf);
            var fileContent = GetFileContent(filePath);
            foreach (string line in fileContent)
            {
                document.Add(new Paragraph(line)
                    .SetTextAlignment(iText.Layout.Properties.TextAlignment.LEFT)
                    .SetFontSize(11));
            }
            writer.Close();
            pdf.Close();
            document.Close();
        }

        public IEnumerable<string> GetFileContent(string filePath)
        {
            return File.ReadAllLines(filePath);
        }

        public IEnumerable<string> ReplaceText(string file, string textTarget, string? textReplacement) 
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
