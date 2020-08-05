using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace TerminalMACS.Util.Extensions
{
    /// <summary>
    /// 获取给定程序集的目录路径，如果找不到，则返回null
    /// </summary>
    public static partial class Extention
    {
        public static string GetDirectoryPathOrNull(this Assembly assembly)
        {
            var location = assembly.Location;
            if (location == null)
            {
                return null;
            }
            var directory = new FileInfo(location).Directory;
            if (directory == null)
            {
                return null;
            }
            return directory.FullName;
        }
    }
}
