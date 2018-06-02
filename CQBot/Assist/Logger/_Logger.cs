﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Reflection;

namespace CQBot.Assist.Logger
{
    public static class _Logger
    {
        /// <summary>
        /// 记录日志至控制台
        /// </summary>
        /// <param name="msg">消息</param>
        public static void WriteLine(string msg)
        {
            Console.ResetColor();
            WriteSource();
            WriteMessage(msg);
        }
        public static void DefaultLine(string msg)
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            WriteSource();

            WriteMessage(msg);
        }
        public static void DebugLine(string msg)
        {
#if DEBUG
            Console.BackgroundColor = ConsoleColor.Cyan;
            Console.ForegroundColor = ConsoleColor.Black;
            WriteSource();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.BackgroundColor = ConsoleColor.Black;
            WriteMessage(msg);
#endif
        }
        public static void PrimaryLine(string msg)
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.Gray;
            WriteSource();

            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.BackgroundColor = ConsoleColor.Black;
            WriteMessage(msg);
        }
        public static void SuccessLine(string msg)
        {
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.ForegroundColor = ConsoleColor.Gray;
            WriteSource();

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.BackgroundColor = ConsoleColor.Black;
            WriteMessage(msg);
        }
        public static void InfoLine(string msg)
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.White;
            WriteSource();

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.BackgroundColor = ConsoleColor.Black;
            WriteMessage(msg);
        }
        public static void WarningLine(string msg)
        {
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.Black;
            WriteSource();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.BackgroundColor = ConsoleColor.Black;
            WriteMessage(msg);
            Console.ResetColor();
        }
        public static void DangerLine(string msg)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.Gray;
            WriteSource();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.BackgroundColor = ConsoleColor.Black;
            WriteMessage(msg);
        }
        private static void WriteSource()
        {
            StackTrace st = new StackTrace(true);
            MethodBase mb = st.GetFrame(2).GetMethod();
            string methodName = $"{mb.DeclaringType.Namespace}.{mb.DeclaringType.Name}.{mb.Name}";
            var n = DateTime.Now;
            Console.Write($"[{n.Hour}:{n.Minute}:{n.Second}][{methodName}]");
            Console.ResetColor();
        }
        private static void WriteMessage(string msg)
        {
            Console.WriteLine(" " + msg);
            Console.ResetColor();
        }
    }
}
