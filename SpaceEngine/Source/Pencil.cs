﻿#region Using Statements
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
    public static class Pencil
    {
       public static SpriteBatch sB;

        public static void giveBatch(SpriteBatch spritebatch)
        {
            sB = spritebatch;
        }

        public static void drawSprite(Vector2 position, float direction, Texture2D texture, Vector2 scale, Color colour, BlendState blendstate)
        {
            sB.Begin(SpriteSortMode.Deferred, blendstate);
            float xfactor = Game1._ScreenSize.X / 800;
            float yfactor = Game1._ScreenSize.Y / 600;
            sB.Draw(texture, new Rectangle((int)(position.X * xfactor), (int)(position.Y * yfactor), (int)(texture.Width * xfactor) + (int)scale.X, (int)(texture.Height * yfactor) + (int)scale.Y), new Rectangle(0, 0, texture.Width, texture.Height), colour, direction, new Vector2(texture.Width, texture.Height) / 2, SpriteEffects.None, 0);
            sB.End();
        }

        public static void drawFont(Vector2 position, SpriteFont font, string text, float scale, Color colour)
        {
            sB.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend);
            sB.DrawString(font, text, position, colour, 0, font.MeasureString(text) / 2, scale, SpriteEffects.None, 0);
            sB.End();
        }
    }
}
