using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace TerminalMACS.Web.Extensions
{
    /// <summary>
    /// Api接口版本 每次新版本增加一个
    /// </summary>
    public enum ApiVersions
    {
        [Description("1.0")]
        v1=1,
    }
}
