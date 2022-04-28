using Luminous.Core.Components;
using Luminous.Interface;

namespace Luminous.Core.Graphics
{
    public class RenderCommandBox : RenderCommand
    {
        public BoxComponent BoxComponent { get; private set; }
        public RenderCommandBox(BoxComponent boxComponent)
        {
            PrimitiveType = IRenderCommand.Primitives.BOX;
            BoxComponent = boxComponent;
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
