using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LOL1
{
    class cDraftTabs
    
        
    {
        //This class is for the Drafting menu and loads background textures and so on for that.
        //inset are the players, player names and champ buttons
        SpriteFont font;
        
        Texture2D texture1;
        Texture2D texture1e;
        Texture2D texture2;
        Texture2D texture2e;
        Texture2D texture3;
        Texture2D texture3e;
        Texture2D texture4;
        Texture2D texture4e;
        Texture2D texture5;
        Texture2D texture5e;

        Vector2 position;
        Vector2 position1;
        Vector2 position2;
        Vector2 position3;
        Vector2 position4;
        Vector2 position5;
        Vector2 poswords;


        Rectangle rectangle;
        Rectangle rectangle1;
        Rectangle rectangle2;
        Rectangle rectangle3;
        Rectangle rectangle4;
        Rectangle rectangle5;

        public Vector2 size;
        public Vector2 sizeBtn;
        public MenuState CurrentMenuState = MenuState.Enemy;
        MenuState LastMenuState = MenuState.Enemy;

        public enum TabState
        {
            //enum switch controls which player you look at based on the role. w/ e is red side, w/o is blue side
            Top,
            Tope,
            Jung,
            Junge,
            Mid,
            Mide,
            Ad,
            Ade,
            Sup,
            Supe
           
        }

        public TabState CurrentTabState = TabState.Tope;
        TabState LastTabState;

        public cDraftTabs(SpriteFont newfont, Texture2D newTexture1, Texture2D newTexture2, Texture2D newTexture3, Texture2D newTexture4, Texture2D newTexture5, Texture2D newTexture6, Texture2D newTexture7, Texture2D newTexture8, Texture2D newTexture9, Texture2D newTexture0, GraphicsDevice graphics)
        {
            texture1 = newTexture1;
            texture1e = newTexture2;
            texture2 = newTexture3;
            texture2e = newTexture4;
            texture3 = newTexture5;
            texture3e = newTexture6;
            texture4 = newTexture7;
            texture4e = newTexture8;
            texture5 = newTexture9;
            texture5e = newTexture0;

            size = new Vector2(graphics.Viewport.Width / 2-10, graphics.Viewport.Height / 2-100);
            sizeBtn = new Vector2(167, 65);
            position = new Vector2(405, 270);
            position1 = position + new Vector2(5, 5);
            position2 = position + new Vector2(5, 74);
            position3 = position + new Vector2(5, 143);
            position4 = position + new Vector2(5, 212);
            position5 = position + new Vector2(5, 281);
            poswords = new Vector2(5, 10);
            font = newfont;
        }

        public bool isClicked1;
        public bool isClicked2;
        public bool isClicked3;
        public bool isClicked4;
        public bool isClicked5;
        public bool Enabled;

        public void Update(MouseState mouse)
        {
            rectangle = new Rectangle((int)position.X, (int)position.Y,
            (int)size.X, (int)size.Y);
            rectangle1 = new Rectangle((int)position1.X, (int)position1.Y,
                (int)sizeBtn.X, (int)sizeBtn.Y);
            rectangle2 = new Rectangle((int)position2.X, (int)position2.Y,
                 (int)sizeBtn.X, (int)sizeBtn.Y);
            rectangle3 = new Rectangle((int)position3.X, (int)position3.Y,
                 (int)sizeBtn.X, (int)sizeBtn.Y);
            rectangle4 = new Rectangle((int)position4.X, (int)position4.Y,
                 (int)sizeBtn.X, (int)sizeBtn.Y);
            rectangle5 = new Rectangle((int)position5.X, (int)position5.Y,
                 (int)sizeBtn.X, (int)sizeBtn.Y);

            Rectangle mouseRectangle = new Rectangle(mouse.X, mouse.Y, 1, 1);

          
            if (mouseRectangle.Intersects(rectangle1))
            {
                    //switch controls going between menu states in the tab
                if (mouse.LeftButton == ButtonState.Pressed)
                {
                    isClicked1 = true;
                    isClicked2 = false;
                    isClicked3 = false;
                    isClicked4 = false;
                    isClicked5 = false;

                }

            }
            else if (mouseRectangle.Intersects(rectangle2))
            {

                if (mouse.LeftButton == ButtonState.Pressed)
                {
                    
                    isClicked1 = false;
                    isClicked2 = true;
                    isClicked3 = false;
                    isClicked4 = false;
                    isClicked5 = false;

                }

            }
            else if (mouseRectangle.Intersects(rectangle3))
            {

                if (mouse.LeftButton == ButtonState.Pressed)
                {

                    isClicked1 = false;
                    isClicked2 = false;
                    isClicked3 = true;
                    isClicked4 = false;
                    isClicked5 = false;

                }

            }
            else if (mouseRectangle.Intersects(rectangle4))
            {

                if (mouse.LeftButton == ButtonState.Pressed)
                {

                    isClicked1 = false;
                    isClicked2 = false;
                    isClicked3 = false;
                    isClicked4 = true;
                    isClicked5 = false;

                }

            }
            else if (mouseRectangle.Intersects(rectangle5))
            {

                if (mouse.LeftButton == ButtonState.Pressed)
                {

                    isClicked1 = false;
                    isClicked2 = false;
                    isClicked3 = false;
                    isClicked4 = false;
                    isClicked5 = true;

                }

            }
            else
            {

                isClicked1 = false;
                isClicked2 = false;
                isClicked3 = false;
                isClicked4 = false;
                isClicked5 = false;
            }




            switch (CurrentMenuState)
            {
                case MenuState.Enemy:
                    if (isClicked1 == true)
                    {
                        LastTabState = CurrentTabState;
                        CurrentTabState = TabState.Tope;
                    }
                    if (isClicked2 == true)
                    {
                        LastTabState = CurrentTabState;
                        CurrentTabState = TabState.Junge;
                    }
                    if (isClicked3 == true)
                    {
                        LastTabState = CurrentTabState;
                        CurrentTabState = TabState.Mide;
                    }
                    if (isClicked4 == true)
                    {
                        LastTabState = CurrentTabState;
                        CurrentTabState = TabState.Ade;
                    }
                    if (isClicked5 == true)
                    {
                        LastTabState = CurrentTabState;
                        CurrentTabState = TabState.Supe;
                    }
                    else 
                    {
                        if (CurrentTabState == TabState.Top) { CurrentTabState = TabState.Tope; }
                        if (CurrentTabState == TabState.Jung) { CurrentTabState = TabState.Junge; }
                        if (CurrentTabState == TabState.Mid) { CurrentTabState = TabState.Mide; }
                        if (CurrentTabState == TabState.Ad) { CurrentTabState = TabState.Ade; }
                        if (CurrentTabState == TabState.Sup) { CurrentTabState = TabState.Supe; }
                    }
                    break;

                case MenuState.Ally:
                    if (isClicked1 == true)
                    {
                        LastTabState = CurrentTabState;
                        CurrentTabState = TabState.Top;
                    }
                    if (isClicked2 == true)
                    {
                        LastTabState = CurrentTabState;
                        CurrentTabState = TabState.Jung;
                    }
                    if (isClicked3 == true)
                    {
                        LastTabState = CurrentTabState;
                        CurrentTabState = TabState.Mid;
                    }
                    if (isClicked4 == true)
                    {
                        LastTabState = CurrentTabState;
                        CurrentTabState = TabState.Ad;
                    }
                    if (isClicked5 == true)
                    {
                        LastTabState = CurrentTabState;
                        CurrentTabState = TabState.Sup;
                    }
                    else 
                    {
                        if (CurrentTabState == TabState.Tope) { CurrentTabState = TabState.Top; }
                        if (CurrentTabState == TabState.Junge) { CurrentTabState = TabState.Jung; }
                        if (CurrentTabState == TabState.Mide) { CurrentTabState = TabState.Mid; }
                        if (CurrentTabState == TabState.Ade) { CurrentTabState = TabState.Ad; }
                        if (CurrentTabState == TabState.Supe) { CurrentTabState = TabState.Sup; }
                    }
                    break;
                    
            }
            LastMenuState = CurrentMenuState;

        }


   
        public void Draw(SpriteBatch spriteBatch)
        {
            switch (CurrentMenuState)
            {
                case MenuState.Enemy:
                    switch (CurrentTabState)
                    {
                        case TabState.Tope:
                            spriteBatch.Draw(texture1e, rectangle, Color.White);
                            break;
                        case TabState.Junge:
                            spriteBatch.Draw(texture2e, rectangle, Color.White);
                            break;
                        case TabState.Mide:
                            spriteBatch.Draw(texture3e, rectangle, Color.White);
                            break;
                        case TabState.Ade:
                            spriteBatch.Draw(texture4e, rectangle, Color.White);
                            break;
                        case TabState.Supe:
                            spriteBatch.Draw(texture5e, rectangle, Color.White);
                            break;
                    }
                    break;
                case MenuState.Ally:
                    switch (CurrentTabState)
                    {
                        case TabState.Top:
                            spriteBatch.Draw(texture1, rectangle, Color.White);
                            break;
                        case TabState.Jung:
                            spriteBatch.Draw(texture2, rectangle, Color.White);
                            break;
                        case TabState.Mid:
                            spriteBatch.Draw(texture3, rectangle, Color.White);
                            break;
                        case TabState.Ad:
                            spriteBatch.Draw(texture4, rectangle, Color.White);
                            break;
                        case TabState.Sup:
                            spriteBatch.Draw(texture5, rectangle, Color.White);
                            break;
                    }
                    break;
                    
            }
            DrawText(spriteBatch);
        }
        private void DrawText(SpriteBatch spriteBatch)
        {

            
            
                    spriteBatch.DrawString(font, "Top",position1+ poswords, Color.White);
                    
                    spriteBatch.DrawString(font, "Jung", position2 + poswords, Color.White);
               
                    spriteBatch.DrawString(font, "Mid", position3 + poswords, Color.White);
             
                    spriteBatch.DrawString(font, "AD", position4 + poswords, Color.White);
               
                    spriteBatch.DrawString(font, "Sup", position5 + poswords, Color.White);
            spriteBatch.DrawString(font, "Tier 1", new Vector2(800, 340), Color.White);
            spriteBatch.DrawString(font, "Tier 2", new Vector2(800, 480), Color.White);
            spriteBatch.DrawString(font, "Known Champions", position1 + new Vector2(400,15), Color.White);
                    spriteBatch.DrawString(font, "Secret Champions", position1 + new Vector2(600,15), Color.White);
        }
    }
}

