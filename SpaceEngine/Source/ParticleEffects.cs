#region Using Statements
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;
#endregion

namespace SpaceEngine
{
    class Particle
    {
        public Vector2 _position;
        public Vector2 _velocity;
        public Texture2D _texture;
        public float _fade = 1;
        public float _direction;
        public Vector2 _scale;
        public Color _colour = Color.White;

        private Random _rand = new Random();


        public void FadeOut(float delay)
        {
            if (_fade > 0)
                _fade -= delay;
        }

        public void Shrink(float delay)
        {
            _scale.X -= delay; _scale.Y -= delay;
        }

        public void Draw()
        {
            Pencil.drawSprite(_position, _direction, _texture, _scale, _colour * _fade, BlendState.AlphaBlend);
        }
    }

    class ParticleEffects
    {
        public List<Particle> particleList = new List<Particle>();

        public virtual void Update()
        {
            
        }

        public virtual void Draw()
        {
            foreach (Particle p in particleList)
                p.Draw();
        }

    }

    class ParticleEffect_TrailFade : ParticleEffects
    {
        public float direction;
        public Vector2 position;
        public Texture2D texture;

        public override void Update()
        {
            Particle part = new Particle();
            part._position = position;
            part._direction = direction;
            part._texture = texture;
            particleList.Add(part);

            for (int i = 0; i < particleList.Count; i++ )
            {
                particleList[i].FadeOut(0.09f);

                particleList[i].Shrink(2f);

                if (particleList[i]._fade <= 0)
                    particleList.RemoveAt(0);
            }
        }
    }
}
