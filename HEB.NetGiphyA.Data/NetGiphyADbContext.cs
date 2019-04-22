using HEB.NetGiphyA.Data.Objects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HEB.NetGiphyA.Data
{
    public class NetGiphyADbContext : DbContext
    {
        public NetGiphyADbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Picture> Pictures { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
