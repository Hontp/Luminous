using Silk.NET.Windowing;
using Silk.NET.Maths;
using System;

namespace Luminous.API
{

    public enum GraphicsMode
    {
        OpenGL,
        Vulkan
    };

    public class LuminousGraphics
    {
        private static Lazy<LuminousGraphics> instance = 
            new Lazy<LuminousGraphics>(() => new LuminousGraphics());

        private IWindow window;

        private WindowOptions options;

        public static LuminousGraphics Instance
        {
            get { return instance.Value; }
        }

        private LuminousGraphics()
        {
            GenerateWindowTemplate();
        }
        
        public  GraphicsMode GraphicsMode {  get; set; } = GraphicsMode.OpenGL;


        public void GenerateWindowTemplate()
        {
            options = new WindowOptions
            {
                IsVisible = true,
                Size = new Vector2D<int>(800, 600),
                FramesPerSecond = 0.0,
                UpdatesPerSecond = 0.0,
                API = GraphicsAPI.None,
                Title = "Lumninous_Window",
                WindowState = WindowState.Normal,
                WindowBorder = WindowBorder.Resizable,
                ShouldSwapAutomatically = true,
                IsEventDriven = true,
                VSync = false,
                SharedContext = null,
                PreferredStencilBufferBits = null,
                PreferredBitDepth = null,
                WindowClass = "Luminous_App_Window",
                VideoMode = VideoMode.Default,
                IsContextControlDisabled = false,
            };
        }

        public void CreateWindow(int width, int height, string caption, bool enableVysnc = false)
        {
            if (GraphicsMode == GraphicsMode.OpenGL)
            {
                options.API = GraphicsAPI.Default;
                options.WindowClass = "Luminous_GL_App";
            }
            else if (GraphicsMode == GraphicsMode.Vulkan)
            {
                options.API = GraphicsAPI.DefaultVulkan;
                options.WindowClass = "Luminous_Vulkan_App";
            }
            else
                Console.WriteLine("FATAL ERROR: No Valid Graphics API\n");

            options.Size = new Vector2D<int>(width, height);
            options.VSync = enableVysnc;
            options.Title = caption;

            window = Window.Create(options);
        }

        public void Run()
        {
            if (window != null)
                window.Run();
        }

        public IWindow WindowHandle
        {
            get { return window; }
        }


    }
}
