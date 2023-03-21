using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using WPF_MiniForms_CSharp.Core;
using WPF_MiniForms_CSharp.Models.Functions;
using WPF_MiniForms_CSharp.Models.Interfaces;
using Word = Microsoft.Office.Interop.Word;

namespace WPF_MiniForms_CSharp.TextModule;

public class TextService : IService
{
    private TextSettings _textSetting;
    private PDFConversion _pdfConversion;
    private readonly TemporaryFolder _folder;
    private readonly FolderFunctions _functions;

    public bool ToPDF { get; set; }
    public object TaskInput { get; set; }
    public object? TaskResult { get; set; }

    public TextService(TemporaryFolder folder, FolderFunctions folderFunctions)
    {
        _folder = folder;
        _functions = folderFunctions;
    }

    public void TextToPDF(string filePath)
    {
        if (filePath.Split('.').Last() != _pdfConversion.ConvertFrom.ToLower())
            return;
        var lines = File.ReadAllLines(filePath);

        if (_pdfConversion.ConvertTo == "docx")
        {
            object oMissing = System.Reflection.Missing.Value;
            Word.Application application = new Word.Application();
            Word.Document wordDoc = application.Documents.Add(ref oMissing, ref oMissing, ref oMissing, ref oMissing);
            foreach (var singleLine in lines)
            {
                wordDoc.Content.InsertAfter(singleLine);
            }
            wordDoc.SaveAs2(filePath);
            wordDoc.Close();
            return;
        }
        if (_pdfConversion.ConvertTo == "txt")
        {
            using StreamWriter file = new(filePath);
            foreach (var line in lines)
            {
                file.WriteLine(line);
            }
            return;
        }

        using PdfDocument pdfDocument = new PdfDocument(new PdfWriter(new FileStream(filePath.Replace("txt", "pdf"), FileMode.Create, FileAccess.Write)));
        using Document document = new Document(pdfDocument);


        foreach (var line in lines)
        {
            document.Add(new Paragraph(line));
        }
    }

    public void TextToPDF(List<string> folderContent)
    {
        folderContent.ForEach((item) =>
        {
            if (item.EndsWith(_pdfConversion.ConvertFrom.ToLower()))
                TextToPDF(item);
        });
    }

    public void TextReplace(string filePath)
    {
        var lines = File.ReadAllLines(filePath);
        for (int i = 0; i < lines.Length; i++)
        {
            if (lines[i].Contains(_textSetting.ReplaceFrom))
                lines[i] = lines[i].Replace(_textSetting.ReplaceFrom, _textSetting.ReplaceWith);
        }
        File.WriteAllLines(filePath, lines);
    }

    public void TextReplace(List<string> folderContent)
    {
        folderContent.ForEach((item) =>
        {
            if (item.EndsWith("txt"))
                TextReplace(item);
        });
    }

    public void Execute()
    {
        if (ToPDF)
        {
            if (TaskInput is PDFConversion conversion)
                _pdfConversion = conversion;
            TextToPDF(_functions.FolderFiles(_folder.GetTemporaryDirectory()).ToList());
            return;
        }
        if (TaskInput is TextSettings settings)
            _textSetting = settings;
        TextReplace(_functions.FolderFiles(_folder.GetTemporaryDirectory()).ToList());
        return;

        throw new ArgumentNullException(nameof(TaskInput));

    }
}
