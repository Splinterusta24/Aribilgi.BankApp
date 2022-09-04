using Aribilgi.BankApp.Web.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aribilgi.BankApp.Web.Data.Configuration
{
    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.Property(x=>x.AccountNumber).IsRequired();
            builder.Property(x=>x.Balance).IsRequired();
            builder.Property(x => x.Balance).HasColumnType("decimal(18,4)");
        }
    }
}
