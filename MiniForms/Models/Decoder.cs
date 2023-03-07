using MiniForms.Core;
using MiniForms.Core.Handlers;
using MiniForms.Core.Helper;
using MiniForms.Core.Objects;
using MiniForms.Interfaces;
using System;
using System.Linq;
using System.Windows;

namespace MiniForms.Models
{
    public class Decoder : EncodeHandle, ITask
    {
        public Type TaskType => typeof(Decoder);

        public string Name => nameof(Decoder);

        public string Description => "placeholder";

        public object TaskData => null;

        public void Execute()
        {
            if (TaskData == null)
                return;
            if(TaskData.GetType() == typeof(EncodeObject))
            {
                if (TaskData is EncodeObject encodeObject)
                    if (encodeObject.Files?.Count() > 0)
                        encodeObject.Files.ForEach(file => EncodeFile(file));
                MessageBox.Show("Task executed succesfully");
            }

        }
    }
}
