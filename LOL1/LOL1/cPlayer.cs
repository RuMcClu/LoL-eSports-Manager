using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LOL1
{
    class cPlayer
    {
        //player class governs the players that get loaded during the champ select screen with names, positions, pictures, and champion
        //stats. Yet to be added is the post champ select stats: Team cohesion, champion effectiveness, average CS per 10 etc.....
        SpriteFont font;
        string Name;
        string Role;
        Texture2D texture;
        Rectangle rectangle;
        Vector2 size;

        Vector2 position;
        //public enum RoleState
       // {
        //    Top,
       //     Jung,
       //     Mid,
        //    Ad,
        //    Sup
       // }
       // RoleState CurrentRoleState;

        public cPlayer(string newName, string newRole, Texture2D newTexture, SpriteFont newfont, GraphicsDevice graphics)
        {
            Name = newName;
            texture = newTexture;
            Role = newRole;
            position = new Vector2(605, 332);
            size = new Vector2(175, 277);
            font = newfont;
        }
        public void Update(MouseState Mouse)
        {
            rectangle = new Rectangle((int)position.X, (int)position.Y, (int)size.X, (int)size.Y);
        }
        //draws the player picture
        public void Draw(SpriteBatch spriteBatch)
        {
            //  switch (CurrentRoleState)
            // {
            //     case RoleState.Role:
            //          spriteBatch.Draw(texture, rectangle, Color.White);
            //        break;
            //}
            // if (CurrentRoleState == "RoleState".Role)
            //{

            //} MOVED THE SWITCH UNDER THE SWITCH IN cDraftTabs
            spriteBatch.Draw(texture, rectangle, Color.White);
            DrawText(spriteBatch);

        }
        //writes the player name
        private void DrawText(SpriteBatch spriteBatch)
        {
                  spriteBatch.DrawString(font,Name, new Vector2(660, 290), Color.White);
        }
    }
}
