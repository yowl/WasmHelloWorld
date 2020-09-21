using System;
using System.Runtime.InteropServices;
using Console = WasmHelloWorld.Program.Console;

namespace WasmHelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        internal class Console
        {
            private static unsafe void PrintString(string s)
            {
                int length = s.Length;
                fixed (char* curChar = s)
                {
                    for (int i = 0; i < length; i++)
                    {
                        TwoByteStr curCharStr = new TwoByteStr();
                        curCharStr.first = (byte)(*(curChar + i));
                        printf((byte*)&curCharStr, null);
                    }
                }
            }

            internal static void WriteLine(string s)
            {
                PrintString(s);
                PrintString("\n");
            }
        }

        struct TwoByteStr
        {
            public byte first;
            public byte second;
        }

        [DllImport("*")]
        private static unsafe extern int printf(byte* str, byte* unused);
    }
}
