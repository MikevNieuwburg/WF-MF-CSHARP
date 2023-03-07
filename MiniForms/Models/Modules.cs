using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MiniForms.Models
{
    public class Modules
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        
        public List<Modules> GetModules() 
        {
            var modules = new List<Modules>();
            modules.Add(new Modules() { Name = "Folder in", Description = "fi"});
            modules.Add(new Modules() { Name = "Folder out", Description = "fo"});
            modules.Add(new Modules() { Name = "Converter", Description = "co"});
            modules.Add(new Modules() { Name = "Decoder", Description = "de"});
            modules.Add(new Modules() { Name = "Mail Out", Description = "mo"});
            modules.Add(new Modules() { Name = "Text Replace", Description = "tr"});
            modules.Add(new Modules() { Name = "Word Template", Description = "wt"});
            modules.Add(new Modules() { Name = "Text to PDF", Description = "tp"});
            return modules.OrderBy(a => a.Name).ToList();
        }
    }
}
