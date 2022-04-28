using Luminous.Interface;
using System.Diagnostics;

namespace Luminous.Core.IO.ContentProcessor.Data
{
    public struct CustomData : IAsset
    {
        private DataType dataType;
        private byte[] data;


        public CustomData(IContentProcessor contentProcessor, string filePath)
        {
            if (contentProcessor != null)
            {
                dataType = DataType.CUSTOM;
                data = contentProcessor.ProcessData(filePath);
            }
            else
            {
                dataType = DataType.CUSTOM;
                data = null;

                Debug.WriteLine("No Content Processor Present :: Data Is Null");
            }
        }

        public DataType DataType
        {
            get { return dataType; }
        }

        public byte[] Data
        {
            get { return data; }
        }
    }
}
