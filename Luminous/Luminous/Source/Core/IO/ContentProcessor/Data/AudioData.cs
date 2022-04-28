using Luminous.Interface;
using System.Diagnostics;
using System.IO;

namespace Luminous.Core.IO.ContentProcessor.Data
{
    public struct AudioData : IAsset
    {
        private IContentProcessor contentProcessor;
        private DataType dataType;
        private string name;
        private string dataPath;
        private byte[] data;

        public AudioData(IContentProcessor ContentProcessor, DataType Type, string FilePath)
        {
            if (ContentProcessor != null)
            {
                dataType = Type;
                dataPath = FilePath;
                contentProcessor = ContentProcessor;
                data = new byte[1];
                name = string.Empty;
            }
            else
            {
                dataType = Type;
                dataPath = string.Empty;
                contentProcessor = null;
                data = null;
                name =  Path.GetFileNameWithoutExtension(FilePath);

                Debug.WriteLine("No Content Processor Present :: Audio Data Is Null");
            }
        }

        public string Name
        {
            get { return name; }
        }

        public DataType DataType 
        {  
            get {  return dataType; } 
        }

        public byte[] Data
        {
            get
            {
                return contentProcessor.ProcessData(dataPath);
                
            }
        }
    
    }
}
