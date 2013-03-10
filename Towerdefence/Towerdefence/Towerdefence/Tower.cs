using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Towerdefence
{
    class Tower : GameObject
    
    {
        
        
        private MouseState _currentState;
        private MouseState _previousState;
        private Rectangle mouseRec;
       


        public override void Initialize(Game game)
        {
            _currentState = Mouse.GetState();
            Position = new Point(100, 100);
        }



        public override void Update(GameTime gameTime)
        {
            _previousState = _currentState;
            _currentState = Mouse.GetState();

            mouseRec = new Rectangle(_currentState.X,_currentState.Y,20,20);
            
            if (_currentState.LeftButton == ButtonState.Pressed )
            {
               
                    Position = new Point
                        (_currentState.X, _currentState.Y);

                    if (_previousState.LeftButton == ButtonState.Released)
                    {
                        Position = new Point
                        (_currentState.X, _currentState.Y);
                    }
                
                
            }
            base.Update(gameTime);
        }

           public bool IsButtonPressed()
        {
            if (_currentState.LeftButton == ButtonState.Pressed && _previousState.LeftButton == ButtonState.Released)
                return true;
            return false;
        }

           public bool IsButtonReleased()
           {
               if (_currentState.LeftButton == ButtonState.Pressed && _previousState.LeftButton == ButtonState.Pressed)
                   return true;
               return false;
           }
        
      
        

    }
}