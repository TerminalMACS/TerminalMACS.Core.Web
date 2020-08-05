﻿using System;
using System.Collections.Generic;
using System.Text;
using TerminalMACS.Util.Helper;

namespace TerminalMACS.Util.Extensions
{
    public static partial class Extention
    {
        /// <summary>
        /// 异步，按顺序执行第一个方法和第二个方法
        /// </summary>
        /// <param name="firstFunc">第一个方法</param>
        /// <param name="next">下一个方法</param>
        public static void Done(this Action firstFunc, Action next)
        {
            DelegateHelper.RunAsync(firstFunc, next);
        }

        /// <summary>
        /// 异步，按顺序执行第一个方法和下一个方法
        /// </summary>
        /// <param name="firstFunc">第一个方法</param>
        /// <param name="next">下一个方法</param>
        public static void Done(this Func<object> firstFunc, Action<object> next)
        {
            DelegateHelper.RunAsync(firstFunc, next);
        }
    }
}
