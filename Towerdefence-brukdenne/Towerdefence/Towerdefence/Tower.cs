using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Towerdefence
{
    public class Tower : DrawableGameComponent, IDrawSprites
    {
        private SpriteBatch _drawer;
        protected List<DrawData> _toDraw = new List<DrawData>();

        private Rectangle Position;
        private Rectangle mouse;
      
        public Tower(Game game)
            : base(game)
        {
            // TODO: Construct any child components here
        }

        protected override void LoadContent()
        {
            base.LoadContent();

            _drawer = new SpriteBatch(this.Game.GraphicsDevice);
            
        }

        /// <summary>
        /// Allows the game component to perform any initialization it needs to before starting
        /// to run.  This is where it can query for any required services and load content.
        /// </summary>
        public override void Initialize()
        {

           Position = new Rectangle(5, 700, 100, 100);
            base.Initialize();
        }
        public void AddDrawable(DrawData drawable)
        {
            if (drawable == null || _toDraw.Contains(drawable))
            {
                Console.WriteLine("Unable to add drawable!");
                return;
            }
            _toDraw.Add(drawable);
        }

        public void RemoveDrawable(DrawData toRemove)
        {
            _toDraw.Remove(toRemove);
        }

        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            
            MouseState _currentState = Mouse.GetState();

            mouse = new Rectangle(_currentState.X, _currentState.Y, mouse.Width+20, mouse.Height+20);

            if (_currentState.LeftButton == ButtonState.Pressed &&mouse.Intersects(Position))
            {

                Position = new Rectangle(_currentState.X,_currentState.Y, 50, 50);

               


            }
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
            _drawer.Begin();
            foreach (DrawData drawData in _toDraw)
            {
                drawElement(drawData);
            }
            _drawer.End();
        }

        protected virtual void drawElement(DrawData drawable)
        {

          
                _drawer.Draw(drawable.Art, Position,
                    drawable.Source, Color.White);
            
        }
    }
}
