using System.Collections.Generic;

namespace MiniForms.Core.Objects
{
    internal class EncodeObject
    {
        private IEnumerable<string>? _files;
        private string? _name;
        public string? Name { get => _name; set => _name = value; }
        public IEnumerable<string>? Files { get => _files; set => _files = value; }
    }
}
