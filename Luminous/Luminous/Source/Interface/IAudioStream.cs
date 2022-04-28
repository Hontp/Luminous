using Luminous.Source.Interface;

namespace Luminous.Interface
{
    public enum AudioType
    {
        MUSIC,
        SFX
    };

    public interface IAudioStream
    {
        IAudioClip GetAudioClip { get; }
    }
}
