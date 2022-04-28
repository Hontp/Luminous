using Luminous.Core.ECS.Interface;
using Luminous.Core.IO.ContentProcessor.Data;
using System;

namespace Luminous.Core.ECS.Components
{
    public class AudioComponent : IComponent
    {

        AudioData data;
        private ulong id = 0;

        public ulong Id
        {
            get { return id; }  
            set { id = value; } 
        }

        public AudioData Audio
        {
            get { return data; }
            set { data = value; }
        }

        public Type Type
        {
            get
            {
                return GetType();
            }
        }
    }
}
