using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Towerdefence
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        private GameObject _tower;
        List<GameObject> _gameObjects = new List<GameObject>();
        Level level = new Level();
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);

            graphics.PreferredBackBufferWidth = level.Width * 100;
            graphics.PreferredBackBufferHeight = level.Height * 100;
            graphics.ApplyChanges();
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            IsMouseVisible = true;
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            _tower = new Tower();
            _tower.Drawable = new DrawData(
                Content.Load<Texture2D>("arrowtower"));
            _gameObjects.Add(_tower);

            foreach (GameObject toInitialize in _gameObjects)
            {
                toInitialize.Initialize(this);
            }
            Texture2D grass = Content.Load<Texture2D>("Grass Block");
            Texture2D path = Content.Load<Texture2D>("Dirt Block");
            Texture2D tree= Content.Load<Texture2D>("Tree Tall");
            level.AddTexture(grass);
            level.AddTexture(path);
            level.AddTexture(tree);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // TODO: Add your update logic here
            foreach (GameObject toUpdate in _gameObjects)
            {
                toUpdate.Update(gameTime);
            }
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            foreach (GameObject toDraw in _gameObjects)
            {
                if (toDraw.Drawable != null)
                    drawElement(toDraw.Drawable);
            }
            
            level.Draw(spriteBatch);
            
            spriteBatch.End();

            base.Draw(gameTime);
        }
        private void drawElement(DrawData toDraw)
        {
            spriteBatch.Draw(
                toDraw.Art, toDraw.Destination,
                toDraw.Source, toDraw.BlendColor);
        }
    }
}
