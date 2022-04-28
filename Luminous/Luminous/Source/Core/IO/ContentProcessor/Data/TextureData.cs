using Luminous.API.MonoGame;
using Luminous.Interface;
using Microsoft.Xna.Framework.Graphics;
using System.Diagnostics;
using System.IO;

namespace Luminous.Core.IO.ContentProcessor.Data
{
    public struct TextureData : IAsset
    {
        private string name;
        private DataType dataType;
        private byte[] data;

        public TextureData(IContentProcessor ContentProcessor, DataType Type, string FilePath)
        {
            if (ContentProcessor != null)
            {
                name = Path.GetFileNameWithoutExtension(FilePath);
                dataType = Type;
                data = ContentProcessor.ProcessData(FilePath);
            }
            else
            {
                name = string.Empty;
                dataType = Type;
                data = null;

                Debug.WriteLine("No Content Processor Present :: Texture Data Is Null");
            }

        }

        public Texture2D Unpack()
        {
            Texture2D texture2D = null;
            using (MemoryStream stream = new MemoryStream(data))
            {
                texture2D = Texture2D.FromStream(Graphics2D.Instance.GraphicsDevice, stream);
            }

            return texture2D;
        }

        public DataType DataType 
        { 
            get { return dataType; }  
        }

        public string Name
        {
            get { return name; }
        }

        public byte[] Data 
        { 
            get {  return data; } 
        }
    }
}
