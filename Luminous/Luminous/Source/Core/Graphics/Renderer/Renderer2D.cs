using Luminous.API.MonoGame;
using Luminous.Interface;
using Luminous.Core.Memory;
using Microsoft.Xna.Framework;
using System;
using Luminous.Core.Components;
using Microsoft.Xna.Framework.Graphics;

namespace Luminous.Core.Graphics.Renderer
{

    //TODO: Implement Shader System
    public class Renderer2D : IRenderer
    {
        private static readonly Lazy<Renderer2D> renderer2D = 
            new Lazy<Renderer2D>(() => new Renderer2D());

        private PriorityQueue<RenderCommand> renderQueue = new PriorityQueue<RenderCommand>();
        public static Renderer2D Instance 
        {
            get { return renderer2D.Value; }
        }

        //public RenderState RenderSettings { get; set; } = new RenderState();

        public void Submit(RenderCommand renderCommand)
        {
            if (renderCommand != null)
                renderQueue.Enqueue(renderCommand);
        }

        private void DrawSprite(SpriteComponent spriteComponent, TransformComponent transformComponent)
        {

            Graphics2D.Instance.Draw(spriteComponent.Texture, transformComponent.Position, 
                null, spriteComponent.Color, transformComponent.Rotation, transformComponent.Origin, 
                transformComponent.Scale, spriteComponent.SpriteEffects, 0);
        }

        private void DrawLine(LineComponent lineComponent, TransformComponent transformComponent)
        {
            Graphics2D.Instance.Draw(lineComponent.Texture, new Rectangle((int)transformComponent.Position.X, (int)transformComponent.Position.Y,
                (int)Math.Round(lineComponent.Texture.Width * transformComponent.Scale.X), (int)Math.Round(lineComponent.Texture.Height * transformComponent.Scale.Y)), null,
                lineComponent.Color, transformComponent.Rotation, transformComponent.Origin, SpriteEffects.None, 0);

            
        }

        private void DrawBox(BoxComponent boxComponent)
        {
            Graphics2D.Instance.Draw(boxComponent.Texture, new Rectangle(boxComponent.Bounds.X, boxComponent.Bounds.Y,
                boxComponent.Thickness, boxComponent.Bounds.Height + boxComponent.Thickness), boxComponent.Color);
            Graphics2D.Instance.Draw(boxComponent.Texture, new Rectangle(boxComponent.Bounds.X, boxComponent.Bounds.Y,
                boxComponent.Bounds.Width + boxComponent.Thickness, boxComponent.Thickness), boxComponent.Color);
            Graphics2D.Instance.Draw(boxComponent.Texture, new Rectangle(boxComponent.Bounds.X + boxComponent.Bounds.Width, 
                boxComponent.Bounds.Y, boxComponent.Thickness, boxComponent.Bounds.Height + boxComponent.Thickness), boxComponent.Color);
            Graphics2D.Instance.Draw(boxComponent.Texture, new Rectangle(boxComponent.Bounds.X, boxComponent.Bounds.Y + boxComponent.Bounds.Height, 
                boxComponent.Bounds.Width + boxComponent.Thickness, boxComponent.Thickness), boxComponent.Color);

        }

        public void Begin(RenderState state, MaterialComponent materialComponent)
        {
            materialComponent.Effect.CurrentTechnique.Passes[0].Apply();

            Graphics2D.Instance.Begin(state.sortMode, state.blendState, state.samplerState,
                        state.depthStencilState, state.rasterizerState,materialComponent.Effect, state.transformMatrix);
        }

        public void End()
        {
            Graphics2D.Instance.End();
        }

        //TODO: fix box and line material
        public void Render()
        {
            while (renderQueue.Count > 0)
            {
                if (renderQueue.Peek() != null)
                {
                    RenderCommand renderCommand = renderQueue.Dequeue();

                    if (renderCommand.PrimitiveType == IRenderCommand.Primitives.TEXTURE)
                    {
                        RenderCommandSprite sprite = (RenderCommandSprite)renderCommand;

                        Begin(sprite.RenderSettings, sprite.MaterialComponent);
                        DrawSprite(sprite.SpriteComponent, sprite.TransformComponent);
                        End();
                    }

                    if (renderCommand.PrimitiveType == IRenderCommand.Primitives.LINES)
                    {
                        RenderCommandLine line = (RenderCommandLine)renderCommand;

                        Begin(line.RenderSettings, line.MaterialComponent);
                        DrawLine(line.LineComponent, line.TransformComponent);
                        End();
                    }

                    if (renderCommand.PrimitiveType == IRenderCommand.Primitives.BOX)
                    {
                        RenderCommandBox box = (RenderCommandBox)renderCommand;
                        Begin(box.RenderSettings, null);
                        DrawBox(box.BoxComponent);
                        End();
                    }
                }
            }
        }

    }
}
