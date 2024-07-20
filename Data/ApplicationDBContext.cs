using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions dbContextOptions)
        : base(dbContextOptions)
        {

        }

        public DbSet<Team> Team { get; set; } // ein Team kann n Videos haben
        public DbSet<Video> Video { get; set; } // ein Video kann ein Team haben
        public DbSet<Comments> Comments { get; set; } // ein Comment kann ein Video haben
        public DbSet<VideoDirectory> Directories { get; set; }

        
    }
}