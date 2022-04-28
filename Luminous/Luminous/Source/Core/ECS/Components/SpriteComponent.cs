using Luminous.Core.ECS.Interface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Luminous.Core.Components
{
    public class SpriteComponent : IComponent
    {
        public Color Color { get; private set; }
        public Texture2D Texture { get; private set; }
        public SpriteEffects SpriteEffects { get; set; } = SpriteEffects.None;
        public ulong Id { get; set; } = 0;

        public SpriteComponent(Texture2D texture, Color color)
        {
            Texture = texture;
            Color = color;
        }

        public Type Type 
        { 
            get { return GetType(); } 
        }
 
    }
}
