#region Using Statements
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;
#endregion

namespace SpaceEngine
{
    class Player
    {
        private Texture2D _texture;

        public Vector2 _position;
        public Rectangle _bounds;
        public Vector2 _speed;

        public Player()
        {
            _texture = Storage.D_Object;

            _position = new Vector2(400, 300);
        }

        public void Update()
        {
            _bounds = new Rectangle((int)_position.X - _texture.Width / 2, (int)_position.Y - _texture.Height / 2, _texture.Width, _texture.Height);

            //Controls
            if (Input.KeyboardPress(Keys.Up))
                if (_speed.Y > -5)
                    _speed.Y -= 0.25f;
                else
                    _speed.Y = -5;
            if (Input.KeyboardPress(Keys.Down))
                if (_speed.Y < 5)
                    _speed.Y += 0.25f;
                else
                    _speed.Y = 5;
            if (Input.KeyboardPress(Keys.Right))
                if (_speed.X < 5)
                    _speed.X += 0.25f;
                else
                    _speed.X = 5;
            if (Input.KeyboardPress(Keys.Left))
                if (_speed.X > -5)
                    _speed.X -= 0.25f;
                else
                    _speed.X = -5;

            if (Input.KeyboardRelease(Keys.Right) && Input.KeyboardRelease(Keys.Left))
                if (Math.Abs(_speed.X) > 1)
                    _speed.X *= 0.97f;
                else
                    _speed.X = 0;
            if (Input.KeyboardRelease(Keys.Up) && Input.KeyboardRelease(Keys.Down))
                if (Math.Abs(_speed.Y) > 1)
                    _speed.Y *= 0.97f;
                else
                    _speed.Y = 0;

            _position += _speed;

        }

        public void Draw()
        {
            Pencil.drawSprite(_position, 0, _texture, Color.White, BlendState.NonPremultiplied);
        }
    }
}
