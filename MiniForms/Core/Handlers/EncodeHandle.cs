using System.Collections.Generic;
using System.IO;

namespace MiniForms.Core.Handlers
{
    public class EncodeHandle
    {
        public void EncodeFile(string file)
        {
            FileInfo fileInfo = new FileInfo(file);
            fileInfo.Encrypt();
        }
        public void EncodeFile(List<string> file)
        {
            foreach (var f in file)
            {
                FileInfo info = new FileInfo(f);
                info.Encrypt();
            }
        }
        public void DecodeFile(string file)
        {
            FileInfo fileInfo = new FileInfo(file);
            fileInfo.Decrypt();
        }
        public void DecodeFile(List<string> file)
        {
            foreach (var f in file)
            {
                FileInfo info = new FileInfo(f);
                info.Decrypt();
            }
        }
    }
}
