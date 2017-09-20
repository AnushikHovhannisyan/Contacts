using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockNot.Models
{
    public class ContactContext : DbContext
    {
        public DbSet<Contact>Contacts { get; set; }
        public ContactContext(DbContextOptions<ContactContext>options) : base(options)
        {
        }
    }
}
