using Luminous.API;
using Luminous.Interface;
using System;

namespace Luminous.Core
{
    public class Engine : IEngine
    {
        // Engine instance
        private static readonly Lazy<Engine> instance = new Lazy<Engine>(() => new Engine());

        public static Engine Instance
        {
            get { return instance.Value; }
        }

        private Engine() 
        {
            LuminousGraphics.Instance.GraphicsMode = GraphicsMode.OpenGL;
        }

        public void Intialize()
        {
            LuminousGraphics.Instance.CreateWindow(800, 600, "Luminous Window");
        }

        public void Run()
        {
            LuminousGraphics.Instance.Run();
        }

        public void Shutdown()
        {
            throw new NotImplementedException();
        }
    }

    //public void Intialize(GameLoop entryPoint) 
    //{
    //    mainEntryPoint = entryPoint;
    //    graphicsDevice = new GraphicsDeviceManager(mainEntryPoint);
    //}

    //public void Run()
    //{
    //    if (mainEntryPoint != null)
    //    {
    //        mainEntryPoint.Run();
    //    }
    //}

    //~Engine()
    //{
    //    Shutdown();
    //}

    //public void Shutdown()
    //{

    //    graphicsDevice.Dispose();
    //    graphicsDevice = null;

    //    mainEntryPoint.Exit();
    //    mainEntryPoint?.Dispose();
    //    mainEntryPoint = null;
    //}
}
