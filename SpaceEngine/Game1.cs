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

    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        //Global Varibles
        Texture2D tex;
        public static Vector2 _ScreenSize = new Vector2(800, 600);

        public Game1()
            : base()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            IsMouseVisible = true;

            #if WINDOWS
            graphics.PreferredBackBufferWidth = (int)_ScreenSize.X;
            graphics.PreferredBackBufferHeight = (int)_ScreenSize.Y;
            graphics.ApplyChanges();
            #endif

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            Pencil.giveBatch(spriteBatch);
            tex = Content.Load<Texture2D>("GloveCursor.png");

        }

        protected override void UnloadContent()
        {

        }

        protected override void Update(GameTime gameTime)
        {
            if (Input.KeyboardPressed(Keys.Escape))
                Exit();
            

            Input.Update();
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);


            Pencil.drawSprite(new Vector2(400, 300), 45, tex, Color.White, BlendState.NonPremultiplied);

            Pencil.drawSprite(new Vector2(250, 125), 45, tex, Color.White, BlendState.Additive);

            base.Draw(gameTime);
        }
    }
}
