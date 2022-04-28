using Microsoft.Xna.Framework.Graphics;
using Luminous.Interface;
using Microsoft.Xna.Framework;
using System;

namespace Luminous.API.MonoGame
{
    public class Graphics2D : IGraphics
    {

        private SpriteBatch spriteBatch;
        
        private static readonly Lazy<Graphics2D> instance = new Lazy<Graphics2D>(() => new Graphics2D());

        public static Graphics2D Instance
        {
            get { return instance.Value; }
        }

        public GraphicsDevice GraphicsDevice 
        { 
            get { return spriteBatch.GraphicsDevice; }
        }

        public void Init(GameLoop gameLoop)
        {
            spriteBatch = new SpriteBatch(gameLoop.GraphicsDevice);
        }

        public void Begin(SpriteSortMode sortMode = SpriteSortMode.Deferred, BlendState blendState = null, 
            SamplerState samplerState = null, DepthStencilState depthStencilState = null, 
            RasterizerState rasterizerState = null, Effect effect = null, Matrix? transformMatrix = default)
        {
            spriteBatch.Begin(sortMode, blendState, samplerState, depthStencilState, 
                rasterizerState, effect, transformMatrix);
        }

        public void Clear( Color color)
        {
            spriteBatch.GraphicsDevice.Clear(color);
        }

        public void Draw(Texture2D texture, Rectangle destinationRectangle, Color color)
        {
            spriteBatch.Draw(texture, destinationRectangle, color);
        }

        public Texture2D GenerateTexture( int width, int height, Color color)
        {
            Texture2D texture = new Texture2D(spriteBatch.GraphicsDevice, width, height);

            Color[] data = new Color[width * height];

            for (int i = 0; i < data.Length; i++)
            {
                data[i] = color;
            }

            texture.SetData(data);

            return texture;
        }

        public void Draw(Texture2D texture, Vector2 position, Rectangle? sourceRectangle, Color color, 
            float rotation, Vector2 origin,  float scale, SpriteEffects effects, float layerDepth)
        {
            spriteBatch.Draw(texture, position, sourceRectangle, color, rotation, 
                origin, scale, effects, layerDepth);
        }

        public void Draw(Texture2D texture, Vector2 position, Rectangle? sourceRectangle, Color color, float rotation, 
            Vector2 origin, Vector2 scale, SpriteEffects effects, float layerDepth)
        {
            spriteBatch.Draw(texture, position, sourceRectangle, color, rotation,
                origin, scale, effects, layerDepth);
        }

        public void Draw(Texture2D texture, Vector2 position, Color color)
        {
            spriteBatch.Draw(texture, position, color);
        }

        public void Draw(Texture2D texture, Vector2 position, Rectangle? sourceRectangle, Color color)
        {
            spriteBatch.Draw(texture, position, sourceRectangle, color);
        }

        public void Draw(Texture2D texture, Rectangle destinationRectangle, Rectangle? sourceRectangle, Color color, float rotation, 
            Vector2 origin, SpriteEffects effects, float layerDepth)
        {
            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, color, rotation, origin, effects, layerDepth);
        }

        public void Draw(Texture2D texture, Rectangle destinationRectangle, 
            Rectangle? sourceRectangle, Color color)
        {
            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, color);
        }

        public void End()
        {
           spriteBatch.End();
        }

        public void Dispose()
        {
            spriteBatch?.Dispose();
        }   
    }
}
