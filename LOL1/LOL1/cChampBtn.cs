using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LOL1
{
    class cChampBtn
    {
        Texture2D texture;
        SoundEffect sound;
        public Vector2 position;
        Rectangle rectangle;
        public Vector2 size=new Vector2(50,50);
        Color colour = new Color(200, 200, 200, 200);

        public cChampBtn(Texture2D newTexture, SoundEffect newSound, GraphicsDevice graphics)
        {
            texture = newTexture;
            sound = newSound;


       }
        public bool isClicked;
        public bool Enabled;
        public bool isSelected=false;
        public bool wasSelected;
        int count=301;
        public void Update(MouseState mouse)
        {
            if (Enabled == true)
            {
                rectangle = new Rectangle((int)position.X, (int)position.Y,
                    (int)size.X, (int)size.Y);

                Rectangle mouseRectangle = new Rectangle(mouse.X, mouse.Y, 1, 1);

                if (mouseRectangle.Intersects(rectangle))
                {
                   
                    if (mouse.LeftButton == ButtonState.Pressed)
                    {
                        isClicked = true;
                        isSelected = true;
                        
                        
                    }

                }
                else 
                {
                    isClicked = false;
                }
                if (isSelected==true & isClicked==true)
                {
                   
                    Count();
                }
            }
            wasSelected = isSelected;

            count++;
        }
        public void Count()
        {
            
            if (count>300)
            {
                sound.Play();
                count = 0;
            }
        }
        public void Deselect()
        {
            isSelected = false;
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
