using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace Chopper.Particles
{
    public class StarBurstParticles : IParticleSystem
    {
        private Random _random;
        private List<Particle> particles = new List<Particle>();
        private List<Texture2D> textures = new List<Texture2D>();

        public StarBurstParticles(ContentManager Content)
        {
            textures.Add(Content.Load<Texture2D>("Particles/circle"));
            textures.Add(Content.Load<Texture2D>("Particles/star"));
            textures.Add(Content.Load<Texture2D>("Particles/diamond"));

            _random = new Random();
        }

        public void Emmit(Vector2 position, Vector2? force)
        {
            const int total = 20;

            for (int i = 0; i < total; i++)
            {
                particles.Add(new Particle()
                {
                    Position = position,
                    Texture = textures[_random.Next(textures.Count)],
                    Velocity = new Vector2(2f * (float)(_random.NextDouble() * 2 - 1),
                                       2f * (float)(_random.NextDouble() * 2 - 1)),
                    Angle = 0f,
                    AngularVelocity = 0.1f * (float)(_random.NextDouble() * 2 - 1),
                    Color = new Color((float)_random.NextDouble(),
                                  (float)_random.NextDouble(),
                                  (float)_random.NextDouble()),
                    Size = (float)_random.NextDouble() * 2 + 1,
                    TimeToLive = 30 + _random.Next(40),
                    FadeOut = true
                });
            }
        }

        public void Update()
        {
            for (int i = 0; i < particles.Count; i++)
            {
                var particle = particles[i];

                particle.TickTimeToLive();

                if (particle.TimeToLive <= 0)
                {
                    particles.RemoveAt(i--);
                    continue;
                }

                particle.Position += particle.Velocity;
                particle.Angle += particle.AngularVelocity;
            }
        }

        public void Draw(ref SpriteBatch spriteBatch)
        {
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.Additive);
            for (int index = 0; index < particles.Count; index++)
            {
                particles[index].Draw(ref spriteBatch);
            }
            spriteBatch.End();
        }
    }
}