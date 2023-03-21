using System.Linq;
using System.Runtime.InteropServices;
using WPF_MiniForms_CSharp.Models.Interfaces;

namespace WPF_MiniForms_CSharp.TextModule
{
    public class WordTemplateService : IService
    {
        public object TaskInput { get; set; }
        public object? TaskResult { get; set; }

        public string Output { get; set; }
        public string OutputName { get; set; }
        public string Template { get; set; }



        /// <summary>
        /// https://stackoverflow.com/questions/6294084/change-or-add-template-in-Word-document
        /// Used this source to apply templates to a Word document.
        /// </summary>
        public void Execute()
        {
            if (TaskInput is string inputPath)
            {
                object missing = System.Reflection.Missing.Value;
                Microsoft.Office.Interop.Word.Application wordApp = new Microsoft.Office.Interop.Word.ApplicationClass();
                Microsoft.Office.Interop.Word.Document aDoc = null;
                object readOnly = false;
                object isVisible = false;

                wordApp.Visible = false;
                string file = inputPath.Split('/').Last();
                if (string.IsNullOrEmpty(OutputName) == false)
                    file = OutputName;
                object filename = inputPath;
                object saveAs = Output + file;
                object oTemplate = Template;

                aDoc = wordApp.Documents.Add(ref oTemplate, ref missing,
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
    }
}
