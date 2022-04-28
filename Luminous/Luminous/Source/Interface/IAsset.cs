using Luminous.Core.IO;

namespace Luminous.Interface
{
    internal interface IAsset
    {
        DataType DataType { get; }
        byte[] Data { get; }
    }
}
