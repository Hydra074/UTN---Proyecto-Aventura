using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace PlaySound
{
    internal class PlaySound
    {
        public static void ErrorSound()
        {
            Console.Beep(1500, 100);
            Thread.Sleep(25);
            Console.Beep(1500, 100);
            Thread.Sleep(15);
            Console.Beep(1500, 100);
            Thread.Sleep(10);
            Console.Beep(1500, 100);
        }

        public static void SuccessfulSound()
        {
            Console.Beep(1350, 100);
            Thread.Sleep(35);
            Console.Beep(1500, 350);
        }
    }
}
