namespace Luminous.Interface
{
    public interface IRenderCommand
    {
        float Layer { get; set; }

        enum Primitives
        {
            LINES,
            BOX,
            TEXTURE
        };

        Primitives PrimitiveType { get; set; }

    }
}
