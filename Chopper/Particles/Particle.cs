using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Chopper.Particles
{
    public class Particle
    {
        private Vector2 origin;
        private Rectangle sourceRectangle;
        public Texture2D Texture
        {
            get => texture;
            set
            {
                texture = value;
                origin = new Vector2(Texture.Width / 2, Texture.Height / 2);
                sourceRectangle = new Rectangle(0, 0, Texture.Width, Texture.Height);
            }
        }
        public Vector2 Position { get; set; }
        public Vector2 Velocity { get; set; }
        public float Angle { get; set; }
        public float AngularVelocity { get; set; }
        public Color Color { get; set; }
        public float Size { get; set; }
        public bool FadeOut { get; set; }
        public int TimeToLive
        {
            get => _remainingTtl;
            set
            {
                _initialTtl = value;
                _remainingTtl = value;
            }
        }
        private int _initialTtl;
        private int _remainingTtl;
        private Texture2D texture;

        public void TickTimeToLive()
        {
            _remainingTtl--;
        }

        public void Draw(ref SpriteBatch spriteBatch)
        {
            if (_remainingTtl <= 0) return;
            spriteBatch.Draw(
                Texture,
                Position,
                sourceRectangle,
                FadeOut ? new Color(Color.R, Color.G, Color.B, (byte)((float)_remainingTtl / _initialTtl * 255f)) : Color,
                Angle,
                origin,
                Size,
                SpriteEffects.None,
                0f);
        }
    }
}