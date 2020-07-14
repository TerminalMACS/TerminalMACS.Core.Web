using System;
using System.Collections.Generic;
using System.Text;

namespace TerminalMACS.Domain.Entitys
{
    /// <summary>
    /// 聚合根
    /// </summary>
    public interface IAggregateRoot
    {
        /// <summary>
        //  每个聚合根必须拥有一个全局的唯一标识，往往是GUID。
        /// </summary>
        Guid Id { get; set; }
    }
}
