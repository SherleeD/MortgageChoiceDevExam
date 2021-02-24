using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ATMWeb.Domain;

namespace ATMWeb.Persistence
{
    public partial class ATMWebContext : DbContext
    {
        public readonly ILogger _logger;

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<AccountTransaction> AccountTransactions { get; set; }

        public ATMWebContext(DbContextOptions<ATMWebContext> options) : base(options) { }

    }
}
