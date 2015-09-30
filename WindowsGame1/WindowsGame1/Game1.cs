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

namespace WindowsGame1
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>

    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        SpriteFont spriteFont;
        List<ControlPoint> controlList;
        List<ControlPoint> dotList;
        bool drag = false;
        Texture2D texture, dotTex;
        Rectangle mouseRect;
        MouseState ms;
        ControlPoint q;
        ControlPoint p1;
        ControlPoint p2;
        ControlPoint p3;
        ControlPoint p4;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.IsFullScreen = false;

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
            spriteFont = Content.Load<SpriteFont>("Font");
            texture = Content.Load<Texture2D>("square");
            dotTex = Content.Load<Texture2D>("dot");

            mouseRect = new Rectangle(0, 0, 0, 0);
            controlList = new List<ControlPoint>();
            p1 = new ControlPoint (texture, new Vector2(40,400));
            p2 = new ControlPoint (texture, new Vector2(200,100));
            p3 = new ControlPoint (texture, new Vector2(400,400));
            p4 = new ControlPoint (texture, new Vector2(572,60));
            //Made these points start in the same spot as the screen cap in the assignment so that I 
            //could make sure that it looked the same as what you had
            p1.isCP = true;
            p2.isCP = true;
            p3.isCP = true;
            p4.isCP = true;
            
            controlList.Add(p1);
            controlList.Add(p2);
            controlList.Add(p3);
            controlList.Add(p4);
            dotList = new List<ControlPoint>();
            this.IsMouseVisible = true;
            graphics.IsFullScreen = true;



            // TODO: use this.Content to load your game content here
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
            DotPopList();
            mouseRect.X = ms.X;
            mouseRect.Y = ms.Y;
            if (ms.LeftButton == ButtonState.Released)
            {
                drag = false;
            }
            foreach (ControlPoint p in controlList)
            {
                if (mouseRect.Intersects(p.rect))
                {
                    if (ms.LeftButton == ButtonState.Pressed)
                    {
                        q = p;
                        drag = true;
                    }
                                          
                    
                }
            }

            
            // Allows the game to exit
            if ((GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed) || (Keyboard.GetState().IsKeyDown(Keys.Escape)))
                this.Exit();
            foreach (ControlPoint p in controlList)
            {
                p.update();
            }
            foreach (ControlPoint p in dotList)
            {
                p.update();
            }
            ms = Mouse.GetState();



            if (drag)
            {
                foreach (ControlPoint p in controlList)
                {                 
                   
                        q.pos = new Vector2(ms.X,ms.Y);                    
                    // TODO: Add your update logic here

                }

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

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            foreach (ControlPoint p in dotList)
            {
                p.Draw(spriteBatch, spriteFont);
            }
            foreach (ControlPoint p in controlList)
            {
                p.Draw(spriteBatch, spriteFont);
            }

            spriteBatch.End();
            base.Draw(gameTime);
        }
       
        public void DotPopList()
        {
            dotList.Clear();
            for (float i = 0; i < 1.0f; i += .0025f)
            {
                
                Vector2 temp = new Vector2();
                float a = (float)Math.Pow((1-i),3);
                float b = (float)Math.Pow((1-i),2);;
                float c = (float)((1-i)*(Math.Pow(i,2)));
                temp.X = ((a * p1.rect.X) + (3 * b * i * p2.rect.X) + (3 * c * p3.rect.X ) + (float)(Math.Pow(i, 3) * p4.rect.X));
                temp.Y = ((a * p1.rect.Y) + (3 * b * i * p2.rect.Y) + (3 * c * p3.rect.Y) + (float)(Math.Pow(i, 3) * p4.rect.Y));
                ControlPoint d = new ControlPoint(dotTex, temp);
                dotList.Add(d);
            }
        }
       
    }
}
