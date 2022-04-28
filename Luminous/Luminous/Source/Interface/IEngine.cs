using Luminous.API.MonoGame;

namespace Luminous.Interface
{
    public interface IEngine
    {
        void Intialize(GameLoop entryPoint);
        void Run();
        void Shutdown();
    }
}
