using Luminous.API.MonoGame;
using Luminous.Core.ECS.Interface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Luminous.Core.Components
{
    public class BoxComponent : IComponent
    {
        public Rectangle Bounds { get; private set; }
        public Vector2 Pivot { get; private set; }
        public float Rotation { get; private set; }
        public Texture2D Texture { get; private set; }

        public int Thickness { get; private set; }
        public Color Color { get; private set; }

        public ulong Id { get; set; }

       public BoxComponent(Rectangle bounds, float rotation, Vector2 pivot, Color color, int thickness)
        {
            Texture = Graphics2D.Instance.GenerateTexture(1, 1, color);
            Bounds = bounds;
            Thickness = thickness;
            Rotation = rotation;
            Pivot = pivot;

            Color = color;
        }

        public Type Type
        {
            get
            {
                return GetType();
            }
        }
    }
}
