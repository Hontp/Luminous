using Luminous.Interface;
using System.IO;

namespace Luminous.Core.IO.ContentProcessor
{
    public class AudioProcessor : IContentProcessor
    {
        public byte[] ProcessData(string filename)
        {
            byte[] result = null;
            using (FileStream fs = File.OpenRead(filename))
            {
                result = new byte[fs.Length];

                fs.Read(result, 0, result.Length);
            }
   
            return result;
        }
    }
}
