using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;

namespace LOL1
{
    class cButton
    {
        Texture2D texture;
        SoundEffect sound;
        Vector2 position;
        Rectangle rectangle;

        Color colour = new Color(255, 255, 255, 255);

        public Vector2 size;

        public cButton(Texture2D newTexture, SoundEffect newSound, GraphicsDevice graphics)
        {
            texture = newTexture;
            sound = newSound;
            //ScreenW = 1600, Screenh = 1200
            //ImgW    = 100, ImgH    = 100
            size = new Vector2(graphics.Viewport.Width *2 / 17, graphics.Viewport.Height / 15);
        }
        bool down;
        public bool isClicked;
        public bool Enabled;
        int count=0;
        public void Update(MouseState mouse)
        {
            rectangle = new Rectangle((int)position.X, (int)position.Y,
                    (int)size.X, (int)size.Y);
            if (Enabled == true)
            {


                Rectangle mouseRectangle = new Rectangle(mouse.X, mouse.Y, 1, 1);

                if (mouseRectangle.Intersects(rectangle))
                {
                    if (colour.A == 255) down = false;
                    if (colour.A == 0) down = true;
                    if (down) colour.A += 3; else colour.A -= 3;
                    if (mouse.LeftButton == ButtonState.Pressed)
                    {
                        
                        Count();
                    }

                }
                else if (colour.A < 255)
                {
                    colour.A += 3;
                    isClicked = false;
                }
                count++;
            }
        }

        
         public void Count()
        {

            if (count > 60)
            {
                isClicked = true;
                sound.Play();
                count = 0;
            }
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
