
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniForms.Models
{
    public class MailProperties
    {
        public List<string>? Receiver { get; set; }
        public List<string>? CC { get; set; }
        public List<string>? BCC { get; set; }
        public string? Header { get; set; }
        public string? Body { get; set; }
        
    }
}
