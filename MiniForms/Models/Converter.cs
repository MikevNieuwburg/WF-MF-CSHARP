using MiniForms.Core.Constants;
using MiniForms.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MiniForms.Models
{
    public class Converter : ITask
    {
        public Type TaskType => typeof(Converter);

        public string Name => nameof(Converter);

        public string Description => LanguageFile.DESC_CONVERTER;

        public object? TaskData { get; set; }

        public void Execute()
        {
            MessageBox.Show("Placeholder");
        }
    }
}
