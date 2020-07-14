using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TerminalMACS.Domain.Entitys
{
    /// <summary>
    /// 实体类基类
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    public abstract class EntityBase<TKey>
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public TKey Id { get; set; }
    }

    public abstract class EntityBase:EntityBase<Guid>, IAggregateRoot
    {

    }
}
