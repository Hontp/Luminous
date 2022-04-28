using Luminous.Components.Interface;
using Microsoft.Xna.Framework;
using System;

namespace Luminous.Core.Components
{
    public class TransformComponent : ITransformComponent
    {
        private Vector2 position = new Vector2(0, 0);
        private Vector2 scale = new Vector2(1, 1);
        private Vector2 origin = Vector2.Zero;
        private float rotation = 0;
        private ulong id = 0;

        public ulong Id
        {
            get { return id; }
            set {  id = value; }
        }

        public Type Type
        {
            get { return GetType(); }
        }

        public Vector2 Scale
        {
            get { return scale; }
            set { scale = value; }
        }

        public float Rotation
        {
            get { return rotation; }
            set { rotation = value; }
        }

        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }

        public Vector2 Origin
        {
            get { return origin; }
            set { origin = value; }
        }

    }
}
