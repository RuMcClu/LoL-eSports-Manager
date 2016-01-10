using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace LOL1
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        SpriteFont font;
        enum GameState
        {
            MainMenu,
            PlayMenu,
            Draft
        }
        GameState CurrentGameState = GameState.MainMenu;

        //Screen Adjustments
        int screenWidth = 1600, screenHeight = 900;

        cButton btnPlay;
        cButton btnPlay2;
        cButton lockIn;
        cDraft draftMenu;
        cChampBtn VolibearBtn;
        cChampBtn RumbleBtn;
        cDraftTabs draftTab;
        cSelected selected;
        cPlayer marin;
        cPlayer faker;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }
        
        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

           
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            font = Content.Load<SpriteFont>("myFont");
            // Screen stuff
            graphics.PreferredBackBufferWidth = screenWidth;
            graphics.PreferredBackBufferHeight = screenHeight;
            //graphics.IsFullScreen=true;
            graphics.ApplyChanges();
            IsMouseVisible = true;
            btnPlay = new cButton(Content.Load<Texture2D>("playbutton"), Content.Load<SoundEffect>("sounds/login"), graphics.GraphicsDevice);
            btnPlay.setPosition(new Vector2(702, 15));
            btnPlay2 = new cButton(Content.Load<Texture2D>("playbutton"), Content.Load<SoundEffect>("sounds/playbutton"), graphics.GraphicsDevice);
            btnPlay2.setPosition(new Vector2(702, 15));
            lockIn = new cButton(Content.Load<Texture2D>("lockin"), Content.Load<SoundEffect>("sounds/air_box_chalkcheck_1"), graphics.GraphicsDevice);
            lockIn.setPosition(new Vector2(1000, 660));
            draftMenu = new cDraft(Content.Load<Texture2D>("DraftMenu2"), Content.Load<Texture2D>("DraftMenu"), Content.Load<Song>("sounds/champselect"), Content.Load<SoundEffect>("sounds/draftmenu"), graphics.GraphicsDevice);
            VolibearBtn = new cChampBtn(Content.Load<Texture2D>("champicon/Volibear_Square_0"), Content.Load<SoundEffect>("sounds/champs/Volibear"), graphics.GraphicsDevice);
            VolibearBtn.setPosition(new Vector2(800, 360));
            RumbleBtn = new cChampBtn(Content.Load<Texture2D>("champicon/Rumble_Square_0"), Content.Load<SoundEffect>("sounds/champs/Rumble"), graphics.GraphicsDevice);
            RumbleBtn.setPosition(new Vector2(855, 360));

            draftTab = new cDraftTabs(Content.Load<SpriteFont>("myFont"),Content.Load<Texture2D>("leagueassets/draftmenus/draftmenu31"),Content.Load<Texture2D>("leagueassets/draftmenus/draftmenu31e"),Content.Load<Texture2D>("leagueassets/draftmenus/draftmenu32"),Content.Load<Texture2D>("leagueassets/draftmenus/draftmenu32e"),Content.Load<Texture2D>("leagueassets/draftmenus/draftmenu33"),Content.Load<Texture2D>("leagueassets/draftmenus/draftmenu33e"),Content.Load<Texture2D>("leagueassets/draftmenus/draftmenu34"),Content.Load<Texture2D>("leagueassets/draftmenus/draftmenu34e"),Content.Load<Texture2D>("leagueassets/draftmenus/draftmenu35"),Content.Load<Texture2D>("leagueassets/draftmenus/draftmenu35e"),graphics.GraphicsDevice);
            selected = new cSelected(Content.Load<Texture2D>("1selected"), graphics.GraphicsDevice);
           
            marin =new cPlayer("Marin","Top", Content.Load<Texture2D>("players/marinprof"), Content.Load<SpriteFont>("myFont"), graphics.GraphicsDevice);
            faker = new cPlayer("Faker", "Mid", Content.Load<Texture2D>("players/fakerprof"), Content.Load<SpriteFont>("myFont"), graphics.GraphicsDevice);
            
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();
            MouseState mouse = Mouse.GetState();
            switch (CurrentGameState)
            {
                case GameState.MainMenu:
                    btnPlay.Enabled = true;
                    btnPlay2.Enabled = false;
                    draftMenu.Enabled2 = false;
                    VolibearBtn.Enabled = false;
                    if (btnPlay.isClicked == true)
                    {
                        CurrentGameState = GameState.PlayMenu;
                    }
                        btnPlay.Update(mouse);
                    
                    break;

                case GameState.PlayMenu:
                    btnPlay.Enabled = false;
                    btnPlay2.Enabled = true;
                    draftMenu.Enabled2 = false;
                    VolibearBtn.Enabled = false;
                    if (btnPlay2.isClicked == true)
                    {
                        CurrentGameState = GameState.Draft;
                    }
                    btnPlay2.Update(mouse);
                   
                    break;
                case GameState.Draft:
                    draftMenu.Enabled2 = true;
                    btnPlay.Enabled = false;
                    btnPlay2.Enabled = false;
                    VolibearBtn.Enabled = true;
                    RumbleBtn.Enabled = true;

                    draftMenu.Update(mouse);
                    draftTab.Update(mouse);
                    VolibearBtn.Update(mouse);
                    RumbleBtn.Update(mouse);
                    
                    draftMenu.playMusic();
                    draftTab.CurrentMenuState=draftMenu.CurrentMenuState;
                    marin.Update(mouse);
                    faker.Update(mouse);
                    if (VolibearBtn.isSelected == true|RumbleBtn.isSelected==true)
                    {
                        lockIn.Enabled = true;
                        
                    }

                    lockIn.Update(mouse);
                    if (VolibearBtn.isClicked == true)
                    {
                        RumbleBtn.Deselect();
                        selected.setPosition(VolibearBtn.position);
                        selected.Update(mouse);
                    }
                    if (RumbleBtn.isClicked== true)
                    {
                        VolibearBtn.Deselect();
                        selected.setPosition(RumbleBtn.position);
                        selected.Update(mouse);
                    }
                    
                    
                    break;

            }
            
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {

            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            switch (CurrentGameState)
            {
                case GameState.MainMenu:
                    spriteBatch.Draw(Content.Load<Texture2D>("Leaguescreen"), new Rectangle(0, 0, screenWidth, screenHeight), Color.White);
                    btnPlay.Draw(spriteBatch);
                    DrawText();
                    break;

                case GameState.PlayMenu:
                    spriteBatch.Draw(Content.Load<Texture2D>("LeaguePlay"), new Rectangle(0, 0, screenWidth, screenHeight), Color.White);
                    btnPlay2.Draw(spriteBatch);
                    break;

                case GameState.Draft:
                    spriteBatch.Draw(Content.Load<Texture2D>("DraftScreen"), new Rectangle(0, 0, screenWidth, screenHeight), Color.White);
                    draftMenu.Draw(spriteBatch);
                    draftTab.Draw(spriteBatch);
                    VolibearBtn.Draw(spriteBatch);
                    RumbleBtn.Draw(spriteBatch);
                    switch (draftTab.CurrentTabState)
                    {
                        case cDraftTabs.TabState.Tope:
                            marin.Draw(spriteBatch);
                            break;
                        case cDraftTabs.TabState.Mide:
                            faker.Draw(spriteBatch);
                            break;
                            
                    }
             
                        selected.Draw(spriteBatch);
                       
                    
                    lockIn.Draw(spriteBatch);
                    break;

            }
            spriteBatch.End();
            
            base.Draw(gameTime);
        }
        private void DrawText()
        {
            spriteBatch.DrawString(font, "this thing", new Vector2(20, 45), Color.White);
        }
    }
}
