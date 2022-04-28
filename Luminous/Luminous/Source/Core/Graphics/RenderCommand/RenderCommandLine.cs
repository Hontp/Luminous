using Luminous.API.MonoGame;
using Luminous.Core.Components;
using Microsoft.Xna.Framework;

namespace Luminous.Core.Graphics
{
    public class RenderCommandLine : RenderCommand
    {
        public TransformComponent TransformComponent { get; private set; }
        public LineComponent  LineComponent { get; private set; }
        public MaterialComponent MaterialComponent { get; private set; }

        public RenderCommandLine(RenderState settings ,TransformComponent transformComponent, 
            LineComponent lineComponent, MaterialComponent materialComponent)
        {
            PrimitiveType = Interface.IRenderCommand.Primitives.LINES;
            RenderSettings = settings;
            TransformComponent = transformComponent;
            MaterialComponent = materialComponent;
            LineComponent = lineComponent;

            MaterialComponent.Texture = lineComponent.Texture;
            MaterialComponent.Color = lineComponent.Color;
        }

        public override int CompareTo(RenderCommand other)
        {
            if (Layer > other.Layer)
                return -1;
            if (Layer < other.Layer)
                return 1;

            return 0;

        }
    }
}
