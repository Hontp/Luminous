using Luminous.API.MonoGame;
using Luminous.Interface;
using System;

namespace Luminous.Core.Graphics
{
    public abstract class RenderCommand : IRenderCommand, IComparable<RenderCommand>
    {
        public float Layer {  get; set; }
        public IRenderCommand.Primitives PrimitiveType { get; set; }
        public RenderState RenderSettings { get; set; }

        public virtual int CompareTo(RenderCommand other)
        {
            return 0;
        }
    }
}
