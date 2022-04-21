using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ClassLibrary
{
    public class Contact
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public Account GetAccount { get; set; }
    }
    public class Incident
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Description { get; set; }
        public ICollection<Account> GetAccount { get; set; }

        public Incident()
        {
            GetAccount = new List<Account>();
        }
    }
    public class Account
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }

        public Incident GetIncindent { get; set; }
        public ICollection<Contact> GetContact { get; set; }

        public Account()
        {
            GetContact = new List<Contact>();
        }

    }
    public class Account_Context : DbContext
    {
        public Account_Context(string conStr) : base(conStr) { }

        public DbSet<Account> GetAccount { get; set; }
        public DbSet<Contact> GetContact { get; set; }
        public DbSet<Incident> GetIncident { get; set; }

        static Account_Context()
        {
            Database.SetInitializer<Account_Context>(new Initializer());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Incident>().HasMany(x => x.GetAccount).WithRequired(x => x.GetIncindent).WillCascadeOnDelete();
            modelBuilder.Entity<Account>().HasMany(x => x.GetContact).WithRequired(x => x.GetAccount).WillCascadeOnDelete();
            base.OnModelCreating(modelBuilder);
        }
    }
    public class Initializer : CreateDatabaseIfNotExists<Account_Context>
    {
        protected override void Seed(Account_Context context)
        {
            Incident incident = new Incident { Description = "TestDesc" };
            Incident incident2 = new Incident { Description = "Testasdaghdgfgsersdfs2" };

            context.GetIncident.AddRange(new List<Incident> { incident, incident2 });

            Account account = new Account { Name = "Bohdan", GetIncindent = incident };
            Account account1 = new Account { Name = "Denys", GetIncindent = incident2 };
            Account account2 = new Account { Name = "Andrey", GetIncindent = incident };

            context.GetAccount.AddRange(new List<Account> { account1, account2, account });

            Contact contact = new Contact { FirstName = "Bohdan", LastName = "Fesak", Email = "fesakbo@gmail.com", GetAccount = account2};

            context.GetContact.Add(contact); 

            context.SaveChanges();
        }
    }
}