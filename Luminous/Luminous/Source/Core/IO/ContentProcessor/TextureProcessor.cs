using Luminous.Interface;
using System.Diagnostics;
using System.IO;

namespace Luminous.Core.IO.ContentProcessor
{
    public class TextureProcessor : IContentProcessor
    {

        private const int MaxTexSize = 16384 * 16384;

        public byte[] ProcessData(string filename)
        {
            byte[] result = null;

            using (FileStream fs = File.OpenRead(filename))
            {
                if (fs.Length > MaxTexSize)
                {
                    Debug.WriteLine($"{filename} Exceeds Max Texture Size Supported");
                    return null;
                }

                result = new byte[fs.Length];
                fs.Read(result, 0, result.Length);                
            }

            return result;
        }
   
    }
}
