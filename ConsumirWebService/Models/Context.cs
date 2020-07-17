using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace ConsumirWebService.Models
{
    public class Context : DbContext
    {
        //Microsoft.EntityFrameworCore.SqlServer
        //Microsoft.EntityFrameworCore.Tools
        //Add-Migration NomeMigração
        //Update-Database -verbose

        public DbSet<Endereco> Enderecos { get; set; }

        public Context(DbContextOptions<Context> options) : base(options)
        {


        }
    }
}
