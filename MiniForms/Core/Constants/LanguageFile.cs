using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniForms.Core.Constants
{
    internal class LanguageFile
    {
        public const string DESC_CONVERTER = "The encode module makes it possible to encode a file.";
        public const string DESC_DECODE = "The decode module makes it possible to decode a file.";
        public const string DESC_FOLDERIN = "The folder-in module makes it possible to get all the files from the set folder.";
        public const string DESC_FOLDEROUT = "The folder-out module will set the output folder where all your documents will end.";
        public const string DESC_MAILOUT = "The mail-out module will send a mail using the content you're inserting from the desired module.";
        public const string DESC_TEXTREPLACE = "The text-replace module will replace text in a file you're utilizing.";
        public const string DESC_TEXTTOPDF = "The text-to-pdf will append all text to a pdf file.";
        public const string DESC_WORDTEMPLATE = "The word-template module will create a word template if left empty or will append given file content to a word file.";
    }
}
