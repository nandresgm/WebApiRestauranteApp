using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApiRestauranteApp.Models;

namespace WebApiRestauranteApp.Data
{
    public class WebApiRestauranteAppContext : DbContext
    {
        public WebApiRestauranteAppContext (DbContextOptions<WebApiRestauranteAppContext> options)
            : base(options)
        {
        }

        public DbSet<WebApiRestauranteApp.Models.Detalle> Detalle { get; set; } = default!;
    }
}
