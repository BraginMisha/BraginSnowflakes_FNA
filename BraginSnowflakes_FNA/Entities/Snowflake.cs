using Microsoft.Xna.Framework;
using System;

namespace BraginSnowflakes_FNA
{
    /// <summary>
    /// Класс, представляющий данные о снежинке.
    /// </summary>
    public class Snowflake
    {
        /// <summary>
        /// Позиция снежинки на экране.
        /// </summary>
        public Vector2 SflakePos { get; set; }

        /// <summary>
        /// Скорость падения снежинки.
        /// </summary>
        public float SflakeSpd { get; set; }

        /// <summary>
        /// Радиус снежинки.
        /// </summary>
        public float SflakeSize { get; set; }

        /// <summary>
        /// Статический генератор случайных чисел для снежинок.
        /// </summary>
        public readonly static Random Rand = new Random();
    }
}
