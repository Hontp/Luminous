using System;

namespace Luminous.Core.ECS.Interface
{
    public interface IComponent
    {
        ulong Id { get; set; }
        Type Type { get; }
    }
}
