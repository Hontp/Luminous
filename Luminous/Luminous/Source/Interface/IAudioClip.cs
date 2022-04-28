using Luminous.Interface;

namespace Luminous.Source.Interface
{
    public interface IAudioClip 
    {
        AudioType AudioType { get; set; }
        string Name { get; set; }
    }
}
