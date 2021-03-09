using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Data.Common;
using TerminalMACS.Domain;
using TerminalMACS.Domain.Configuration;
using TerminalMACS.Domain.Web;
using TerminalMACS.Util.Model;

namespace TerminalMACS.Infrastructure.EntityFrameworkCore
{
    public class BaseDbContext : DbContext
    {
        //public DbSet<testA> ModelAs { get; set; }
        //public DbSet<testB> ModelBs { get; set; }
        ////var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

        ////MyProjectDbContextConfigurer.Configure(builder, configuration.GetConnectionString(MyProjectConsts.ConnectionStringName));

        ////AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());
        //protected override void OnConfiguring(DbContextOptionsBuilder options)
        //    => options.UseMySql(AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder()).GetConnectionString(DomainConsts.ConnectionStringName));

        private DatabaseType _dbType { get; }

        private DbConnection _dbConnection { get; }

        private IModel _mode { get; }

        private static ILoggerFactory _loggerFactory = new LoggerFactory(new ILoggerProvider[] { new EFCoreSqlLogeerProvider() });

        public BaseDbContext(DatabaseType dbType, DbConnection existingConnection, IModel model)
        {
            _dbType = dbType;
            _dbConnection = existingConnection;
            _mode = model;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string ConnectionString = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder()).GetConnectionString(DomainConsts.ConnectionStringName);
            switch (_dbType)
            {
                case DatabaseType.SqlServer:
                    optionsBuilder.UseSqlServer(ConnectionString); break;
                case DatabaseType.MySql:
                    optionsBuilder.UseMySql(ConnectionString); break;
                default: throw new Exception("暂不支持该数据库！");
            }

            optionsBuilder.EnableSensitiveDataLogging();
            optionsBuilder.UseModel(_mode);
            optionsBuilder.UseLoggerFactory(_loggerFactory);
        }
    }
}
