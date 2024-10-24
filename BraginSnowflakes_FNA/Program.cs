using System;

namespace BraginSnowflakes_FNA
{
    static internal class Program
    {
        /// <summary>
        /// Точка входа в программу.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            using (var game = new SnowfallGame())
            {
                game.Run();
            }
        }
    }
}
