using Microsoft.Xna.Framework;

namespace Luminous.API.MonoGame
{
    /*
     * Internal class that inherits with MonoGame Game Class,
     * this allows the underlying Game Class to be extended as needed
     */
    public class GameLoop : Game, IMainLoop
    {
        protected sealed override void Initialize()
        {
            Graphics2D.Instance.Init(this);

            Start();

            base.Initialize();
        }

        protected sealed override void LoadContent()   
        {
            Load();
        }

        protected override void Update(GameTime gameTime)
        {
            Update(gameTime.ElapsedGameTime.TotalMilliseconds);

            base.Update(gameTime);
        }

        protected sealed override void Draw(GameTime gameTime)
        {
            Graphics2D.Instance.Clear(Color.CornflowerBlue);

            Draw(gameTime.ElapsedGameTime.TotalMilliseconds);

            base.Draw(gameTime);
        }

        public virtual void Start() { }
        public virtual void Load() { }
        public virtual void Update(double dt) { }
        public virtual void Draw(double dt) { }
    }
}
