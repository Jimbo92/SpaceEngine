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
    static class Storage
    {
        //Textures
        public static Texture2D D_Planet;
        public static Texture2D D_Object;

        //Fonts
        public static SpriteFont Font_Basic;

        public static void Loader(ContentManager Content)
        {
            //Textures
            D_Planet = Content.Load<Texture2D>("planet.png");
            D_Object = Content.Load<Texture2D>("object.png");

            //Fonts
            Font_Basic = Content.Load<SpriteFont>("font");
        }


    }
}
