using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chopper
{
    class Player
    {
        private const float maxVelUp = 100f;
        private const float forceUp = 10f;
        private const float gravity = 9.8f;

        private float _yVel = 0f;
        Vector2 _pos = new Vector2(0f);
        public Vector2 Pos => _pos;

        void GoUp()
        {
            _yVel += forceUp;
        }

        void Update()
        {
            _yVel -= gravity;
            _yVel = Math.Min(_yVel, maxVelUp);

            _pos.Y += _yVel;
        }

        bool IsColliding()
        {
            return false;
        }

        void Draw()
        {

        }

    }
}