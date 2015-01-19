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
    public class Entity
    {
        public Vector2 position;
        public Vector2 velocity;
        public Texture2D texture;
        public float mass = 1;

        public virtual void Update()
        {
            position += velocity;
        }

        public virtual void Draw()
        {
            Pencil.drawSprite(position, 0, texture, Vector2.Zero, Color.White, BlendState.NonPremultiplied);
        }
    }

    public class Planet : Entity
    {
        public Planet(Vector2 pos, Texture2D tex, float fatness)
        {
            position = pos;
            texture = tex;
            mass = fatness;
        }

        public override void Update()
        {
            velocity = Vector2.Zero;
            base.Update();
        }

        public override void Draw()
        {
            base.Draw();
        }
    }

    public class Object : Entity
    {
        public Object(Vector2 pos, Texture2D tex)
        {
            position = pos;
            texture = tex;
        }

        public override void Update()
        {
           
            base.Update();
        }

        public override void Draw()
        {
            base.Draw();
        }
    }
}
