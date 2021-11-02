using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Chopper.Particles
{
    public interface IParticleSystem
    {
        public void Emmit(Vector2 position, Vector2? force);
        public void Update();
        public void Draw(ref SpriteBatch spriteBatch);

    }
}