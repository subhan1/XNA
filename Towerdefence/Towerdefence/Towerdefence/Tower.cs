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
        Texture2D texture;
        public Vector2 position;
        private MouseState _currentState;
        private MouseState _previousState;
        public Rectangle rectangle;
        
      

       



        public void Update(GameTime gameTime)
        {
            _previousState = _currentState;
            _currentState = Mouse.GetState();
            
                   
            
            if (_currentState.LeftButton == ButtonState.Pressed && _previousState.LeftButton == ButtonState.Released )
            {
                // Check if the mouse is clicked over the sprite 
                if ((_currentState.X > position.X) && (_currentState.X < (position.X + texture.Width)) &&
                    (_currentState.Y > position.Y) && (_currentState.Y < (position.Y + texture.Height)))
                {
                    position = new Vector2(50, 50);
                    
                }
                
                
            }
          
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