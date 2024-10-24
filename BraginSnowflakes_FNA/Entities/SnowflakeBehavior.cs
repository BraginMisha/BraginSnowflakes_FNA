using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BraginSnowflakes_FNA
{
    /// <summary>
    /// Поведение снежинки (перемещение, отрисовка).
    /// </summary>
    public static class SnowflakeBehavior
    {
        /// <summary>
        /// Инициализация снежинки с случайной позицией и скоростью
        /// </summary>
        /// <param name="snowflake">Объект снежинки для инициализации</param>
        /// <param name="screenWidth">Ширина экрана</param>
        /// <param name="screenHeight">Высота экрана</param>
        public static void Initialize(Snowflake snowflake, int screenWidth, int screenHeight)
        {
            snowflake.SflakePos = new Vector2(Snowflake.Rand.Next(screenWidth), Snowflake.Rand.Next(screenHeight));
            snowflake.SflakeSpd = (float)Snowflake.Rand.NextDouble() * 3 + 1;
            snowflake.SflakeSize = (float)Snowflake.Rand.NextDouble() * 3 + 2;
        }

        /// <summary>
        /// Обновление позиции снежинки, двигая её вниз
        /// </summary>
        /// <param name="snowflake">Объект снежинки</param>
        /// <param name="screenWidth">Ширина экрана</param>
        /// <param name="screenHeight">Высота экрана</param>
        public static void Update(Snowflake snowflake, int screenWidth, int screenHeight)
        {
            snowflake.SflakePos = new Vector2(snowflake.SflakePos.X - snowflake.SflakeSpd, snowflake.SflakePos.Y + snowflake.SflakeSpd);

            if (snowflake.SflakePos.Y > screenHeight)
            {
                int buf = Snowflake.Rand.Next(0, screenWidth + screenHeight);
                if (buf <= screenWidth)
                {
                    snowflake.SflakePos = new Vector2(buf, -(snowflake.SflakeSize + 5));
                }
                else
                {
                    snowflake.SflakePos = new Vector2(screenWidth + snowflake.SflakeSize, buf - screenWidth);
                }
            }
        }

        /// <summary>
        /// Рисование снежики
        /// </summary>
        /// <param name="spriteBatch">Контекст для отрисовки</param>
        /// <param name="snowflake">Объект снежинки</param>
        /// <param name="texture">Текстура снежинки</param>
        public static void Draw(SpriteBatch spriteBatch, Snowflake snowflake, Texture2D texture) =>
            spriteBatch.Draw(
                texture,
                snowflake.SflakePos,
                null,
                Color.White,
                0f,
                Vector2.Zero,
                snowflake.SflakeSize / texture.Width,
                SpriteEffects.None,
                0f);
    }
}
