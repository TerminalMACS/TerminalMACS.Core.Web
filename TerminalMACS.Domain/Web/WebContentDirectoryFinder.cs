using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using TerminalMACS.Util.Extensions;

namespace TerminalMACS.Domain.Web
{
    public class WebContentDirectoryFinder
    {
        public static string CalculateContentRootFolder()
        {
            var coreAssemblyDirectoryPath = Path.GetDirectoryName(typeof(DomainModule).GetAssembly().Location);
            if (coreAssemblyDirectoryPath == null)
            {
                throw new Exception("找不到TerminalMACS.Domain项目集合！");
            }

            var directoryInfo = new DirectoryInfo(coreAssemblyDirectoryPath);
            while(!DirectoryContains(directoryInfo.FullName, "TerminalMACS.Web.sln"))
            {
                if (directoryInfo.Parent == null)
                {
                    throw new Exception("找不到内容根文件夹！");
                }
                directoryInfo = directoryInfo.Parent;
            }

            var webMvcFolder = Path.Combine(directoryInfo.FullName, "TerminalMACS.Web.Mvc");
            if (Directory.Exists(webMvcFolder))
            {
                return webMvcFolder;
            }

            var webHostFolder = Path.Combine(directoryInfo.FullName, "TerminalMACS.Web");
            if (Directory.Exists(webHostFolder))
            {
                return webHostFolder;
            }

            throw new Exception("找不到web项目的根文件夹！");
        }

        private static bool DirectoryContains(string directory, string fileName)
        {
            return Directory.GetFiles(directory).Any(filePath => string.Equals(Path.GetFileName(filePath), fileName));
        }
    }
}
