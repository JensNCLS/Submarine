using System;
using System.Threading.Tasks;

namespace Submarine.Terminal.Helpers
{
    public class TextHelper
    {
        /// <summary>
        /// Displays text in the Terminal
        /// </summary>
        /// <param name="text">Text you want to display</param>
        /// <param name="delay">Delay in milliseconds</param>
        public async void ShowText(string text, int delay = 1000)
        {
            Console.WriteLine(text);
            await Task.Delay(delay);
        }
    }
}
