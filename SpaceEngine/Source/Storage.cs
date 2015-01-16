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
        #region Font Varibles
        public static SpriteFont _Font_Basic;

        #endregion
        #region Texture Varibles

        #endregion

        public static void Loader(ContentManager Content)
        {
            #region Font Loads
            _Font_Basic = Content.Load<SpriteFont>("Font");

            #endregion
            #region Texture Loads

            #endregion
        }

    }
}
