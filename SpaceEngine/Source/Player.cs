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
        Vector2 planet;

        enum move
        {
            ATTRACT,
            FREE,
        }

        move moveState = move.FREE;

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

            moveState = move.FREE;
            //Apply attraction to planets
            foreach (Entity e in Game1.Entities)
            {
                if (e is Planet)
                {
                    
                    Vector2 diff = e.position - position;
                    planet = diff;

                    float distance = diff.LengthSquared();
                    if (distance < 50000 * mass)
                    {
                        moveState = move.ATTRACT;
                        diff.Normalize();

                        diff *= e.mass;

                        Vector2 mag = diff - velocity;

                        mag /= 120;
                        velocity += (diff + mag);

                        position += velocity;
                    }
                }
            }

            //Controls
            if (moveState == move.FREE)
            {
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
            }
            if (moveState == move.ATTRACT)
            {
                if (Input.KeyboardPress(Keys.Left))
                {

                    if (speed > -1)
                        speed -= 0.25f;
                    else
                        speed = -1;

        
                }

                if (Input.KeyboardPress(Keys.Right))
                {

                    if (speed < -1)
                        speed += 0.25f;
                    else
                        speed = 1;

            
                }

                if (Input.KeyboardRelease(Keys.Left) && Input.KeyboardRelease(Keys.Right))
                    if (Math.Abs(speed) > 1)
                        speed *= 0.92f;
                    else
                        speed = 0;

                planet.Normalize();
                planet *= speed;
                position += new Vector2(-planet.Y, planet.X);

                
            }

            //Effects
            TrailEff.Update();
            TrailEff.position = position;
            TrailEff.direction = rotation;

            foreach (Entity e in Game1.Entities)
            {
                if (e is Planet)
                {
                    if (circletocicle(e.position, 50, position, 20))
                        position -= velocity;
                }

            }

            

        }

        public bool circletocicle(Vector2 ap, float ar, Vector2 bp, float br)
        {
            ar *= ar;
            br *= br;

            Vector2 d = bp - ap;
            float df = d.LengthSquared();

            return !(df > ar + br);

        }

        public override void Draw()
        {
            if (speed != 0)
                TrailEff.Draw();

            Pencil.drawSprite(position, rotation, texture, Vector2.Zero, Color.White, BlendState.NonPremultiplied);
        }
    }
}
