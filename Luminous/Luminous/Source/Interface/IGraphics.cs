﻿using Luminous.API.MonoGame;
using Luminous.Core.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Luminous.Interface
{
    internal interface IGraphics
    {
        void Init(GameLoop gameLoop);
        void Begin(SpriteSortMode sortMode = SpriteSortMode.Deferred, BlendState blendState = null,
            SamplerState samplerState = null, DepthStencilState depthStencilState = null,
            RasterizerState rasterizerState = null, Effect effect = null, Matrix? transformMatrix = default(Matrix?));


        void Draw(Texture2D texture, Vector2 position, Color color);

        void Draw(Texture2D texture, Vector2 position, Rectangle? sourceRectangle, Color color);

        void Draw(Texture2D texture, Vector2 position, Rectangle? sourceRectangle, Color color,
            float rotation, Vector2 origin, float scale, SpriteEffects effects, float layerDepth);

        void Draw(Texture2D texture, Vector2 position, Rectangle? sourceRectangle, Color color, float rotation,
           Vector2 origin, Vector2 scale, SpriteEffects effects, float layerDepth);

        void Draw(Texture2D texture, Rectangle destinationRectangle,
            Rectangle? sourceRectangle, Color color);

        void Clear(Color color);

        void Dispose();

        void End();
    }
}
