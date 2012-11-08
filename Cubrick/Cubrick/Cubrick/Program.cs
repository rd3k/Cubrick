using System;

namespace Cubrick
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (CubrickGame game = new CubrickGame())
            {
                game.Run();
            }
        }
    }
#endif
}

