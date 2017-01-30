using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections;

namespace Game1
{

    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        ArrayList controllerList;
        KeyboardController keyboard;
        GamePadController gamepad;
        public ISprite TidusSprite;
        public Texture2D Texture;
        public Texture2D Background;
        public Vector2 location;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }


        protected override void Initialize()
        {
            keyboard = new KeyboardController();
            gamepad = new GamePadController();
            controllerList = new ArrayList();
            location.X = 200;
            location.Y = 200;
            controllerList.Add(gamepad);
            controllerList.Add(keyboard);
            this.RegisterCommands();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            //I got wrecked on Overwatch earlier today -Chris
            //Hey what's up, this is Oliver(yeah actually songnan wu if you guys don't now who Oliver is)
            //Yo it's Nate, copying Oliver's idea to comment right here. Practicing committing code :-)
            //What? It's George, LLLLLLLLLLLLLLLLLLLLLLOL
            
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Texture = Content.Load<Texture2D>("TidusSheet");
            Background = Content.Load<Texture2D>("bg");
            TidusSprite = new StandingInPlaceTidusSprite(Texture);

        }
        protected override void Update(GameTime gameTime)
        {
            foreach(IController controller in controllerList)
            {
                controller.Update();
            }
            TidusSprite.Update();
        }

        protected void RegisterCommands()
        {
            keyboard.RegisterCommand(Keys.Q, new EndGameCommand(this));
            keyboard.RegisterCommand(Keys.W, new StandingInPlaceTidusCommand(this));
            keyboard.RegisterCommand(Keys.E, new FixedAnimatedTidusCommand(this));
            keyboard.RegisterCommand(Keys.R, new KillTidusCommand(this));
            keyboard.RegisterCommand(Keys.T, new MovingAnimatedTidusCommand(this));

            gamepad.RegisterCommand(Buttons.Start, new EndGameCommand(this));
            gamepad.RegisterCommand(Buttons.A, new StandingInPlaceTidusCommand(this));
            gamepad.RegisterCommand(Buttons.B, new FixedAnimatedTidusCommand(this));
            gamepad.RegisterCommand(Buttons.X, new KillTidusCommand(this));
            gamepad.RegisterCommand(Buttons.Y, new MovingAnimatedTidusCommand(this));
        }

       protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);
            int spriteID = TidusSprite.SpriteID();
            //Add a back ground
            spriteBatch.Begin();
            spriteBatch.Draw(Background, new Rectangle(0, 0, 800, 480), Color.White);
            spriteBatch.End();
            //---------------------------
            if (spriteID == 2)
            {
                if (location.X <= 0)
                {
                    location.X = graphics.PreferredBackBufferWidth;
                }
                else
                {
                    location.X -= 5;
                }
            } else if (spriteID == 3)
            {
                if (location.Y >= graphics.PreferredBackBufferHeight)
                {
                    location.Y = 0 - graphics.PreferredBackBufferHeight / 10;
                }
                else
                {
                    location.Y += 5;
                }
            }


            TidusSprite.Draw(spriteBatch, location);
            
            base.Draw(gameTime);
        }
    }
}
