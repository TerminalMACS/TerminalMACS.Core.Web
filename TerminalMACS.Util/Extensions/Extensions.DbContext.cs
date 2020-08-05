using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TerminalMACS.Util.Extensions
{
    public static partial class Extensions
    {
        public static IQueryable GetIQueryable(this DbContext context,Type entityType)
        {
            var dbSet = context.GetType().GetMethod("Set").MakeGenericMethod(entityType).Invoke(context,null);
            var resQ = typeof(EntityFrameworkQueryableExtensions).GetMethod("AsNoTracking").MakeGenericMethod(entityType).Invoke(null, new object[] { dbSet });
            return resQ as IQueryable;
        }
    }
}
