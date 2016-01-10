using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LOL1
{

    public class cDraft
    {
        Song sound;
        SoundEffect sound2;
        Texture2D texture1;
        Texture2D texture2;
        Vector2 position1;
        Vector2 position2;
        Rectangle rectangle;
        Rectangle rectangle1;
        Rectangle rectangle2;

        public Vector2 size;
        public Vector2 sizeBtn;

        public MenuState CurrentMenuState = MenuState.Enemy;

        public cDraft(Texture2D newTexture1,Texture2D newTexture2, Song newSound, SoundEffect newSound2, GraphicsDevice graphics)
        {
            sound = newSound;
            sound2 = newSound2;
            texture1 = newTexture1;
            texture2 = newTexture2;
            size= new Vector2(graphics.Viewport.Width/2, graphics.Viewport.Height / 2);
            sizeBtn= new Vector2(130, 55);
            position1 = new Vector2(400, 200);
            position2 = position1 + new Vector2(130, 0);
          

        }
        
        public bool isClicked1;
        public bool isClicked2;
        public bool Enabled2;

        public bool foe;

        public void Update(MouseState mouse)
        {
           
                rectangle = new Rectangle((int)position1.X, (int)position1.Y,
                (int)size.X, (int)size.Y);
                rectangle1 = new Rectangle((int)position1.X, (int)position1.Y,
                    (int)sizeBtn.X, (int)sizeBtn.Y);
                rectangle2 = new Rectangle((int)position2.X, (int)position2.Y,
                     (int)sizeBtn.X, (int)sizeBtn.Y);

                Rectangle mouseRectangle = new Rectangle(mouse.X, mouse.Y, 1, 1);

                if (mouseRectangle.Intersects(rectangle1))
                {

                    if (mouse.LeftButton == ButtonState.Pressed)
                    {
                        isClicked2 = true;
                        isClicked1 = false;

                    }

                }
                else if (mouseRectangle.Intersects(rectangle2))
                {

                    if (mouse.LeftButton == ButtonState.Pressed)
                    {
                        isClicked1 = true;
                        isClicked2 = false;

                    }

                }
                else
                {

                    isClicked1 = false;
                    isClicked2 = false;
                }

                
                switch (CurrentMenuState)
                {
                    case MenuState.Enemy:
                    if (isClicked2 == true)
                    {
                        CurrentMenuState = MenuState.Ally;
                        sound2.Play();
                        foe = false;
                    }
                        break;

                    case MenuState.Ally:
                    if (isClicked1 == true)
                    {
                        CurrentMenuState = MenuState.Enemy;
                        sound2.Play();
                        foe = true;
                    }
                    break;

                }

            }
        

        bool songStarted = false;
        

        public void playMusic()
        {
          
          

            if (!songStarted)
            {
                MediaPlayer.Play(sound);
                songStarted = true;
            }

            // ...
        
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            switch (CurrentMenuState)
            {
                case MenuState.Enemy:
                    spriteBatch.Draw(texture1,rectangle,Color.White);
                    break;
                case MenuState.Ally:
                    spriteBatch.Draw(texture2, rectangle, Color.White);
                    break;
            }
        }
    }
}
