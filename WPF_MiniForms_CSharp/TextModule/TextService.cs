using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using System.Collections.Generic;
using System.IO;
using WPF_MiniForms_CSharp.Models.Interfaces;

namespace WPF_MiniForms_CSharp.TextModule;

internal class TextService : IService
{
    private readonly TextSettings _textObject;

    public object TaskInput { get; set; }
    public object? TaskResult { get; set; }

    public TextService(TextSettings textObject)
    {
        _textObject = textObject;
    }

    public void TextToPDF(string filePath)
    {
        if (filePath.Split('.')[^0] != "txt")
            return;

        using PdfDocument pdfDocument = new PdfDocument(new PdfWriter(new FileStream(filePath.Replace("txt", "pdf"), FileMode.Create, FileAccess.Write)));
        using Document document = new Document(pdfDocument);

        var lines = File.ReadAllLines(filePath);

        foreach (var line in lines)
        {
            document.Add(new Paragraph(line));
        }
    }

    public void TextToPDF(List<string> folderContent)
    {
        folderContent.ForEach(TextToPDF);
    }

    public void TextReplace(string filePath)
    {
        var lines = File.ReadAllLines(filePath);
        for (int i = 0; i < lines.Length; i++)
        {
            if (lines[i].Contains(_textObject.ReplaceFrom))
                lines[i] = lines[i].Replace(_textObject.ReplaceFrom, _textObject.ReplaceWith);
        }
        File.WriteAllLines(filePath, lines);
    }

    public void TextReplace(List<string> folderContent)
    {
        folderContent.ForEach(TextReplace);
    }

    public void Execute()
    {
        throw new System.NotImplementedException();
    }
}
