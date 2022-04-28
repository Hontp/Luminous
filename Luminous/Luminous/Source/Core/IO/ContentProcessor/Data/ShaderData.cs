using Luminous.API.MonoGame;
using Luminous.Interface;
using Microsoft.Xna.Framework.Graphics;
using System.Text;

namespace Luminous.Core.IO.ContentProcessor.Data
{
    public struct ShaderData : IAsset
    {
        private DataType dataType;
        private byte[] data;

        public ShaderData (IContentProcessor ContentProcessor, DataType Type, string FilePath)
        {
            dataType = Type;
            data = ContentProcessor.ProcessData(FilePath);
        }

        public DataType DataType
        {
            get { return dataType; }
        }

        public string Unpack()
        {
           string shader = Encoding.UTF8.GetString(data);

           return shader;
        }

        public byte[] Data
        {
            get { return data; }
        }
    }
}
