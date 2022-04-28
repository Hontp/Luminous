using Luminous.API.MonoGame;
using Luminous.Interface;

using Microsoft.Xna.Framework;
using System;

namespace Luminous.Core
{
    public class Engine : IEngine
    {
        private GameLoop mainEntryPoint;

        private GraphicsDeviceManager graphicsDevice;
        // Engine instance
        private static readonly Lazy<Engine> instance = new Lazy<Engine>(() => new Engine());

        public static Engine Instance
        {
            get { return instance.Value; }
        }

        private Engine() {}

        public void Intialize(GameLoop entryPoint) 
        {
            mainEntryPoint = entryPoint;
            graphicsDevice = new GraphicsDeviceManager(mainEntryPoint);
        }
 
        public void Run()
        {
            if (mainEntryPoint != null)
            {
                mainEntryPoint.Run();
            }
        }

        ~Engine()
        {
            Shutdown();
        }

        public void Shutdown()
        {

            graphicsDevice.Dispose();
            graphicsDevice = null;

            mainEntryPoint.Exit();
            mainEntryPoint?.Dispose();
            mainEntryPoint = null;
        }
    }
}
