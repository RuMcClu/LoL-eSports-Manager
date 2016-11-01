using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace LOL1
{
    //This class is a button selector for the chbtn class which stops the sound from coming out multiple times
    //bugfixclass
    class cSelected
    {
       
        Texture2D texture;
        Vector2 position;
        Rectangle rectangle;
        public Vector2 size = new Vector2(50, 50);
        Color colour = new Color(200, 200, 200, 200);

        public cSelected(Texture2D newTexture, GraphicsDevice graphics)
        {
            texture = newTexture;
            
        }
       
        public void Update(MouseState mouse)
        {
                rectangle = new Rectangle((int)position.X, (int)position.Y,
                    (int)size.X, (int)size.Y);
        }

        public void setPosition(Vector2 newPosition)
        {
            position = newPosition;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, rectangle, colour);

        }
    }

}
