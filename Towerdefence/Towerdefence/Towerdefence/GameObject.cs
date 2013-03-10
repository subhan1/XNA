using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Towerdefence
{
    public class GameObject
    {
        public DrawData Drawable { get; set; }
        public Point Position { get; set; }
    


        public virtual void Initialize(Game game)
        { }

        public virtual void Update(GameTime gameTime)
        {
            if (Drawable != null)
            {
                Drawable.Position = Position;
            }
           
        }
    }
}
