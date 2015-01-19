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
        public static Vector2 _ScreenSize = new Vector2(800, 600);

        public static List<Entity> Entities = new List<Entity>();

        Player _player;

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
            Storage.Loader(Content);
            Pencil.giveBatch(spriteBatch);

            Entity mars = new Planet(new Vector2(200), Storage.D_Planet,0.1f);
     

            Entities.Add(mars);

            _player = new Player();
        }

        protected override void UnloadContent()
        {

        }

        protected override void Update(GameTime gameTime)
        {
            if (Input.KeyboardPressed(Keys.Escape))
                Exit();

            _player.Update();
            Input.Update();
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            Pencil.drawFont(new Vector2(400, 100), Storage.Font_Basic, "This is Text", 1, Color.White);

            foreach (Entity e in Entities)
            {
                e.Draw();
            }

            _player.Draw();

            base.Draw(gameTime);
        }
    }
}
