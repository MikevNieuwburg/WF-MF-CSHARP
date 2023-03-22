using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using iText.Kernel.Pdf;
using Microsoft.Office.Interop.Word;
using WPF_MiniForms_CSharp.Core;
using WPF_MiniForms_CSharp.Models.Functions;
using WPF_MiniForms_CSharp.Models.Interfaces;
using Document = iText.Layout.Document;
using Paragraph = iText.Layout.Element.Paragraph;

namespace WPF_MiniForms_CSharp.TextModule;

public class TextService : IService
{
    private const string FILE_EX_DOCX = "docx";
    private const string FILE_EX_TXT = "txt";
    private const string FILE_EX_PDF = "pdf";

    private readonly TemporaryFolder _folder;
    private readonly FolderFunctions _functions;
    private PDFConversion? _pdfConversion;
    private TextSettings? _textSetting;

    public TextService(TemporaryFolder folder, FolderFunctions folderFunctions)
    {
        _folder = folder;
        _functions = folderFunctions;
    }

    public bool ToPdf { get; set; }
    public object? TaskInput { get; set; }
    public object? TaskResult { get; set; }

    public void Execute()
    {
        if (ToPdf)
        {
            if (TaskInput is PDFConversion conversion)
                _pdfConversion = conversion;
            TextToPdf(_functions.FolderFiles(_folder.GetTemporaryDirectory()).ToList());
            return;
        }

        if (TaskInput is TextSettings settings)
            _textSetting = settings;
        TextReplace(_functions.FolderFiles(_folder.GetTemporaryDirectory()).ToList());
    }

    public void TextToPdf(string filePath)
    {
        if (filePath.Split('.').Last() != _pdfConversion?.ConvertFrom.ToLower())
            return;
        var lines = File.ReadAllLines(filePath);

        switch (_pdfConversion.ConvertTo)
        {
            case FILE_EX_DOCX:
            {
                object oMissing = Missing.Value;
                var application = new Application();
                var wordDoc = application.Documents.Add(ref oMissing, ref oMissing, ref oMissing, ref oMissing);
                foreach (var singleLine in lines) wordDoc.Content.InsertAfter(singleLine);
                wordDoc.SaveAs2(filePath);
                wordDoc.Close();
                return;
            }
            case FILE_EX_TXT:
            {
                using StreamWriter file = new(filePath);
                foreach (var line in lines) file.WriteLine(line);
                return;
            }
        }

        using var pdfDocument =
            new PdfDocument(new PdfWriter(new FileStream(filePath.Replace(FILE_EX_TXT, FILE_EX_PDF), FileMode.Create,
                FileAccess.Write)));
        using var document = new Document(pdfDocument);

        foreach (var line in lines) document.Add(new Paragraph(line));
    }

    public void TextToPdf(List<string> folderContent)
    {
        folderContent.ForEach(item =>
        {
            if (item.EndsWith(_pdfConversion?.ConvertFrom.ToLower() ?? string.Empty))
                TextToPdf(item);
        });
    }

    public void TextReplace(string filePath)
    {
        var lines = File.ReadAllLines(filePath);
        for (var i = 0; i < lines.Length; i++)
        {
            if (lines[i].Contains(_textSetting?.ReplaceFrom ?? string.Empty) && _textSetting?.ReplaceFrom != null)
            {
                lines[i] = lines[i].Replace(_textSetting.ReplaceFrom, _textSetting.ReplaceWith);
            }
        }

        File.WriteAllLines(filePath, lines);
    }

    public void TextReplace(List<string> folderContent)
    {
        folderContent.ForEach(item =>
        {
            if (item.EndsWith("txt"))
                TextReplace(item);
        });
    }
}