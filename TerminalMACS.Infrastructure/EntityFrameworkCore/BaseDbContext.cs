using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using TerminalMACS.Domain;
using TerminalMACS.Domain.Configuration;
using TerminalMACS.Domain.Entitys;
using TerminalMACS.Domain.Web;

namespace TerminalMACS.Infrastructure.EntityFrameworkCore
{
    public class BaseDbContext : DbContext
    {
        public DbSet<testA> ModelAs { get; set; }
        public DbSet<testB> ModelBs { get; set; }
        //var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

        //MyProjectDbContextConfigurer.Configure(builder, configuration.GetConnectionString(MyProjectConsts.ConnectionStringName));

        //AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseMySql(AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder()).GetConnectionString(DomainConsts.ConnectionStringName));
    }
}
