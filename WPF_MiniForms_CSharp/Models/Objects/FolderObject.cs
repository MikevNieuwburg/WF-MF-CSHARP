using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_MiniForms_CSharp.Models.Objects
{
    internal class FolderObject
    {
        private IEnumerable<string> _childDirectories;
        private IEnumerable<string> _childFiles;
        private bool _doesExist;

        public IEnumerable<string> ChildDirectories { get => _childDirectories; internal set => _childDirectories = value; }
        public IEnumerable<string> ChildFiles { get => _childFiles; internal set => _childFiles = value; }
        public bool DoesExist { get => _doesExist; internal set => _doesExist = value; }

        public FolderObject()
        {
        }
    }
}
