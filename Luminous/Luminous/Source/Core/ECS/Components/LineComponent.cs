using Luminous.API.MonoGame;
using Luminous.Core.ECS.Interface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Luminous.Core.Components
{
    public class LineComponent : IComponent
    { 
        public Texture2D Texture {  get; private set; }
        public Color Color { get; private set; }
        public int Thickness {  get; private set; }
        public int Length {  get; private set; }


        public ulong Id { get; set; }

        public LineComponent ( Color color,int length, int thickness )
        {
            Length = length;
            Color = color;
            Thickness = thickness;
            Texture = Graphics2D.Instance.GenerateTexture(length, thickness, color);
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
