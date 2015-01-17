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
    class Player : Entity
    {
        public Rectangle bounds;
        public float speed;
        public float rotation;

        public ParticleEffect_TrailFade TrailEff = new ParticleEffect_TrailFade();

        public Player()
        {
            texture = Storage.D_Object;

            position = new Vector2(400, 300);

            TrailEff.texture = Storage.D_Object;
        }

        public override void Update()
        {
            bounds = new Rectangle((int)position.X - texture.Width / 2, (int)position.Y - texture.Height / 2, texture.Width, texture.Height);

            //Controls
            if (Input.KeyboardPress(Keys.Right))
                rotation += 0.095f;

            if (Input.KeyboardPress(Keys.Left))
                rotation -= 0.095f;

            if (Input.KeyboardPress(Keys.Down))
                if (speed > -5)
                    speed -= 0.25f;
                else
                    speed = -5;

            if (Input.KeyboardPress(Keys.Up))
                if (speed < 5)
                    speed += 0.25f;
                else
                    speed = 5;

            if (Input.KeyboardRelease(Keys.Up) && Input.KeyboardRelease(Keys.Down))
                if (Math.Abs(speed) > 1)
                    speed *= 0.97f;
                else
                    speed = 0;

            position.X += speed * (float)Math.Cos(rotation);
            position.Y += speed * (float)Math.Sin(rotation);

            //Effects
            TrailEff.Update();
            TrailEff.position = position;
            TrailEff.direction = rotation;

        }

        public override void Draw()
        {
            if (speed != 0)
                TrailEff.Draw();

            Pencil.drawSprite(position, rotation, texture, Vector2.Zero, Color.White, BlendState.NonPremultiplied);
        }
    }
}
