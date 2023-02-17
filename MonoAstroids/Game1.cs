using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MyAstroids;

namespace MonoAstroids;

public class Game1 : Game
{
    GraphicsDeviceManager graphics;
    SpriteBatch spriteBatch;
    WorldMyAstroids world;

    public Game1()
    {
        graphics = new GraphicsDeviceManager(this);
       
        //graphics.IsFullScreen = true;
        //graphics.PreferredBackBufferWidth = 1600;
        //graphics.PreferredBackBufferHeight = 1200;

        graphics.PreferredBackBufferWidth = 1024;
        graphics.PreferredBackBufferHeight = 768;

        Content.RootDirectory = "Content";
    }

    protected override void Initialize()
    {
        spriteBatch = new SpriteBatch(graphics.GraphicsDevice);
        world = new WorldMyAstroids(graphics, spriteBatch,Content,this);
        world.Initialize();
        Window.Title = "MyAstroids in 30 minutes!";

        base.Initialize();
    }

    protected override void LoadContent()
    {
        spriteBatch = new SpriteBatch(GraphicsDevice);

        // TODO: use this.Content to load your game content here
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
            Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        world.Update(gameTime);

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        world.Draw(gameTime);

        base.Draw(gameTime);
    }
}