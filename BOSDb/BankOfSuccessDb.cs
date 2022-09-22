using BankOfSuccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BankOfSuccess.BOSDb
{
    public class BankOfSuccessDb : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;Initial Catalog=BankOfSuccessDB;Integrated Security=True;Pooling=False");
        }
        public DbSet<Account> account { get; set; }
       // public DbSet<Transaction> transaction { get; set; }

    }
}
