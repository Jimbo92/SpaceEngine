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


        float mass = 1;
        Vector2 planetPos;
        Vector2 objectPos;
        Vector2 objectVel;

        public Game1()
            : base()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            IsMouseVisible = true;

            planetPos = new Vector2(200);
            objectPos = new Vector2(500, 300);
            objectVel.Y = -1;

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
            Storage.Loader(Content);
            Pencil.giveBatch(spriteBatch);

            Storage.D_Planet = Content.Load<Texture2D>("planet.png");
            Storage.D_Object = Content.Load<Texture2D>("object.png");

        }

        protected override void UnloadContent()
        {

        }

        protected override void Update(GameTime gameTime)
        {
            if (Input.KeyboardPressed(Keys.Escape))
                Exit();


            if (Input.ClickPressed(Input.EClicks.LEFT))
            {
                Vector2 mouse = new Vector2(Mouse.GetState().X, Mouse.GetState().Y);
                planetPos = mouse;
            }

            Vector2 diff = planetPos - objectPos;

            float distance = diff.LengthSquared();

            diff.Normalize();

            diff *= mass;

            Vector2 mag = diff - objectVel;

            mag /= 120;
            objectVel += (diff + mag);

            objectPos += objectVel;

            Input.Update();
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            Pencil.drawFont(new Vector2(400, 100), Storage._Font_Basic, "This is Text", 1, Color.White);

            Pencil.drawSprite(planetPos, 0, Storage.D_Planet, Color.White, BlendState.AlphaBlend);
            Pencil.drawSprite(objectPos, 0, Storage.D_Object, Color.White, BlendState.AlphaBlend);

            Pencil.drawSprite(new Vector2(250, 125), 90, tex, Color.White, BlendState.Additive);

            base.Draw(gameTime);
        }
    }
}
