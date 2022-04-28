using Luminous.Core.Graphics;

namespace Luminous.Core.ECS.Interface
{
    public interface ISpriteRendererComponent : IComponent
    {
        public MaterialComponent Material { get; set; }
    }
}
