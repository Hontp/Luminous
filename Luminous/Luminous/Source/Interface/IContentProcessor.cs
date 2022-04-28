namespace Luminous.Interface
{
    public enum DataType
    {
        NONE,
        CUSTOM,
        TEXTURE2D,
        SHADER,
        AUDIO,
    };

    public interface IContentProcessor
    {
       byte[] ProcessData(string filename);
    }
}
