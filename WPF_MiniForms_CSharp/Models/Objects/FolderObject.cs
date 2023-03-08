using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_MiniForms_CSharp.Models.Objects
{
    internal class FolderObject
    {
        internal string? Path { get; set; }
        internal IEnumerable<string>? Files { get; set; }
        internal IEnumerable<string>? SubFolders { get; set; }
        internal Dictionary<string, IEnumerable<string>>? SubFolderContent{ get;}
    }
}
