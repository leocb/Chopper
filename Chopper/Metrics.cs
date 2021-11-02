using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chopper
{
    public static class Metrics
    {
        public static long TotalFrames { get; private set; }
        public static float AverageFramesPerSecond { get; private set; }
        public static float CurrentFramesPerSecond { get; private set; }

        private const int MAXIMUM_SAMPLES = 30;

        private static Queue<float> _sampleBuffer = new Queue<float>();

        private static void Update(float deltaTime)
        {
            CurrentFramesPerSecond = 1.0f / deltaTime;

            _sampleBuffer.Enqueue(CurrentFramesPerSecond);

            if (_sampleBuffer.Count > MAXIMUM_SAMPLES)
            {
                _sampleBuffer.Dequeue();
                AverageFramesPerSecond = _sampleBuffer.Average(i => i);
            }
            else
            {
                AverageFramesPerSecond = CurrentFramesPerSecond;
            }

            TotalFrames++;
        }

        public static void Draw(ref GameTime time, ref SpriteFont font, ref SpriteBatch spriteBatch)
        {
            Update((float)time.ElapsedGameTime.TotalSeconds);

            spriteBatch.Begin();
            spriteBatch.DrawString(font, string.Format("{0} FPS", AverageFramesPerSecond.ToString("0")), new Vector2(0, 0), Color.White);
            spriteBatch.End();
        }
    }
}