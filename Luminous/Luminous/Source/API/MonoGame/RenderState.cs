using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Luminous.API.MonoGame
{
    public class RenderState
    {

        public  Matrix? transformMatrix;
        public  RasterizerState rasterizerState;
        public  DepthStencilState depthStencilState;
        public  BlendState blendState;
        public  SamplerState samplerState;
        public  SpriteSortMode sortMode;

        public RenderState()
        {
            sortMode = SpriteSortMode.BackToFront;
            rasterizerState = null;
            depthStencilState = null;
            blendState = null;
            samplerState = null;
            transformMatrix = null;
        }

        public RenderState(BlendState State, SamplerState Sampler, DepthStencilState DepthStencil, 
            SpriteSortMode Mode, RasterizerState Rasterizer, Matrix? Matrix)
        {
            rasterizerState = Rasterizer;
            blendState = State;
            samplerState = Sampler;
            depthStencilState = DepthStencil;
            sortMode = Mode;
            transformMatrix = Matrix;
        }
    
    }
}
