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
     



        public override void Initialize(Game game)
        {
            _currentState = Mouse.GetState();
        }



        public override void Update(GameTime gameTime)
        {
            _previousState = _currentState;
            _currentState = Mouse.GetState();
            
                   
            
            if (_currentState.LeftButton == ButtonState.Pressed && _previousState.LeftButton == ButtonState.Released )
            {
                
          
                    Position = new Point
                        (_currentState.X, _currentState.Y);
                    
                
                
                
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