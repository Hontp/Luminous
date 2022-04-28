using Luminous.Core.ECS.Interface;
using Microsoft.Xna.Framework;

namespace Luminous.Components.Interface
{ 
    public interface ITransformComponent : IComponent
    {
       
        Vector2 Position { get; set; }
        Vector2 Scale { get; set; }
        float Rotation { get; set; }
        Vector2 Origin { get; set; }
    }
}
