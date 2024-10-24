﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BraginSnowflakes_FNA
{
    /// <summary>
    /// Представляет основную логику для игры
    /// </summary>
    public class SnowfallGame : Game
    {
        private readonly GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private Texture2D snowflakeTexture;
        private Texture2D backgroundTexture;
        private Snowflake[] snowflakes;

        /// <summary>
        /// Инициализация объекта SnowfallGame
        /// </summary>
        public SnowfallGame()
        {
            graphics = new GraphicsDeviceManager(this);
            Window.Title = "ТЫЩА СНЕЖИНОК";
            Content.RootDirectory = "Content";
            IsMouseVisible = false;
        }

        /// <summary>
        /// Иницилизация снежинок
        /// </summary>
        protected override void Initialize()
        {
            snowflakes = new Snowflake[1000];
            for (var i = 0; i < snowflakes.Length; i++)
            {
                snowflakes[i] = new Snowflake();
                SnowflakeBehavior.Initialize(snowflakes[i], graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight);
            }

            base.Initialize();
        }

        /// <summary>
        /// Создание текстуры для снежинки и фона
        /// </summary>
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            backgroundTexture = Content.Load<Texture2D>("forest");
            snowflakeTexture = new Texture2D(GraphicsDevice, 1, 1);
            snowflakeTexture.SetData(new[] { Color.White });
        }

        /// <summary>
        /// Обновление снежинок
        /// </summary>
        /// <param name="gameTime">Время, прошедшее с последнего обновления</param>
        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Exit();
            }

            foreach (var snowflake in snowflakes)
            {
                SnowflakeBehavior.Update(
                    snowflake,
                    graphics.PreferredBackBufferWidth,
                    graphics.PreferredBackBufferHeight
                    );
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// Рисование снежинок
        /// </summary>
        /// <param name="gameTime">Время отрисовки</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin();
            spriteBatch.Draw(backgroundTexture, new Rectangle(0, 0, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight), Color.White);
            foreach (var snowflake in snowflakes)
            {
                SnowflakeBehavior.Draw(
                    spriteBatch,
                    snowflake,
                    snowflakeTexture
                    );
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
