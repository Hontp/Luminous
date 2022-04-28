using Luminous.API.MonoGame;
using Luminous.Core.Components;
using Luminous.Interface;

namespace Luminous.Core.Graphics
{
    public class RenderCommandSprite : RenderCommand
    {
        
        public TransformComponent TransformComponent { get; private set; }
        public SpriteComponent SpriteComponent { get; private set; }
        public MaterialComponent MaterialComponent { get; private set; }

        public RenderCommandSprite(RenderState settings, TransformComponent transformComponent, 
            SpriteComponent spriteComponent, MaterialComponent materialComponent)
        {
            PrimitiveType = IRenderCommand.Primitives.TEXTURE;
            RenderSettings = settings;
            TransformComponent = transformComponent;
            SpriteComponent = spriteComponent;

            MaterialComponent = materialComponent;
            MaterialComponent.Texture = spriteComponent.Texture;
            MaterialComponent.Color = spriteComponent.Color;
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
