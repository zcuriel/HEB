using HEB.NetGiphyA.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace HEB.NetGiphyA
{
    /// <summary>
    /// DesignTimeDbContextFactory  :  Extensiono that allows the Database Tier reside in a different project in VS
    /// </summary>
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<NetGiphyADbContext>
    {
        public NetGiphyADbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<NetGiphyADbContext>();

            var connectionString = configuration.GetConnectionString("NetGiphyADb");

            builder.UseSqlServer(connectionString);

            return new NetGiphyADbContext(builder.Options);
        }
    }
}
