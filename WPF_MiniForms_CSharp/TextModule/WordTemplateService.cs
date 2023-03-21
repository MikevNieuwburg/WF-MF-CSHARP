using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using Microsoft.Office.Interop.Word;
using WPF_MiniForms_CSharp.Models.Interfaces;

namespace WPF_MiniForms_CSharp.TextModule;

public class WordTemplateService : IService
{
    public string? Output { get; set; }
    public string? OutputName { get; set; }
    public string? Template { get; set; }
    public object? TaskInput { get; set; }
    public object? TaskResult { get; set; }


    /// <summary>
    ///     https://stackoverflow.com/questions/6294084/change-or-add-template-in-Word-document
    ///     Used this source to apply templates to a Word document.
    /// </summary>
    public void Execute()
    {
        var input = "";
        if (TaskInput is string inputPath)
            input = inputPath;
        if (string.IsNullOrEmpty(input))
            return;

        object missing = Missing.Value;
        Application wordApp = new ApplicationClass();
        object readOnly = false;
        object isVisible = false;

        wordApp.Visible = false;
        var file = input.Split('/').Last();
        if (string.IsNullOrEmpty(OutputName) == false)
            file = OutputName;
        object filename = input;
        object saveAs = Output + file;
        object? oTemplate = Template;

        var aDoc = wordApp.Documents.Add(ref oTemplate, ref missing,
            ref missing, ref missing);

        aDoc = wordApp.Documents.Open(ref filename, ref missing,
            ref readOnly, ref missing, ref missing,
            ref missing, ref missing, ref missing,
            ref missing, ref missing, ref missing,
            ref isVisible, ref missing, ref missing,
            ref missing, ref missing);

        aDoc.Activate();
        aDoc.set_AttachedTemplate(oTemplate);
        aDoc.UpdateStyles();

        aDoc.SaveAs(ref saveAs, ref missing, ref missing,
            ref missing, ref missing, ref missing,
            ref missing, ref missing, ref missing,
            ref missing, ref missing, ref missing, ref missing);

        aDoc.Close(ref missing, ref missing, ref missing);
        Marshal.ReleaseComObject(aDoc);
        Marshal.ReleaseComObject(wordApp);
    }
}