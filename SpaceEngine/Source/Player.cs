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
                    if (distance < e.range * e.range)
                    {
                        moveState = move.ATTRACT;
                        diff.Normalize();

                        diff *= e.mass;

                        Vector2 mag = diff - velocity;

                        mag /= 120;
                        velocity += (diff + mag);

                        
                    }
                }
            }

            position += velocity;

            //Controls
            if (moveState == move.FREE)
            {
                if (Input.KeyboardPress(Keys.Right))
                    rotation += 0.095f;

                if (Input.KeyboardPress(Keys.Left))
                    rotation -= 0.095f;

                if (Input.KeyboardPress(Keys.Down))
                    if (speed > -5)
                        speed -= 0.75f;
                    else
                        speed = -5;

                if (Input.KeyboardPress(Keys.Up))
                    if (speed < 5)
                        speed += 0.75f;
                    else
                        speed = 5;

                if (Input.KeyboardRelease(Keys.Up) && Input.KeyboardRelease(Keys.Down))
                {
                    if (Math.Abs(speed) > 1)
                    {

                        speed *= 0.95f;
                    }
                    else
                    {
                        speed = 0;
                    }

                    if (Math.Abs(velocity.X) > 1)
                    {

                        velocity.X *= 0.95f;
                    }
                    else
                    {
                        velocity.X = 0;
                    }

                    if (Math.Abs(velocity.Y) > 1)
                    {

                        velocity.Y *= 0.95f;
                    }
                    else
                    {
                        velocity.Y = 0;
                    }
                }
                if (velocity.X > 8)
                {
                    velocity.X = 8;
                }

                if (velocity.X < -8)
                {
                    velocity.X = -8;
                }

                if (velocity.Y > 8)
                {
                    velocity.Y = 8;
                }

                if (velocity.Y < -8)
                {
                    velocity.Y = -8;
                }

                velocity.X += (speed / 20f) * (float)Math.Cos(rotation);
                velocity.Y += (speed / 20f) * (float)Math.Sin(rotation);
            }

            foreach (Entity e in Game1.Entities)
            {
                if (e is Planet)
                {
                    if (circletocicle(e.position, 50, position, 20))
                    {
                        position -= velocity;

                        velocity = Vector2.Zero;
                    }


                }

            }
            if (moveState == move.ATTRACT)
            {
                if (Input.KeyboardPress(Keys.Left))
                {

                    if (speed > -2)
                        speed -= 0.25f;
                    else
                        speed = -2;

        
                }

                if (Input.KeyboardPress(Keys.Right))
                {

                    if (speed < 2)
                        speed += 0.25f;
                    else
                        speed = 2;

            
                }

               


                if (Input.KeyboardRelease(Keys.Left) && Input.KeyboardRelease(Keys.Right))
                    if (Math.Abs(speed) > 1)
                        speed *= 0.92f;
                    else
                        speed = 0;

                planet.Normalize();

                if (Input.KeyboardPress(Keys.Up))
                {
                    position += planet;


                    foreach (Entity e in Game1.Entities)
                    {
                        if (e is Planet)
                        {
                            if (circletocicle(e.position, 50, position, 20))
                            {
                                velocity -= planet * 5;
                            }


                        }

                    }

                    position -= planet;

                }
                planet *= speed;
               
                position += new Vector2(planet.Y, -planet.X);

                

                
            }

            //Effects
            TrailEff.Update();
            TrailEff.position = position;
            TrailEff.direction = rotation;

           

            

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
