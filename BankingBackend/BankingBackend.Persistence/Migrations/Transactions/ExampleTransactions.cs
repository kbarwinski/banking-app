using BankingBackend.Domain.Entities;
using BankingBackend.Persistence.Migrations.TransactionsCategories;

namespace BankingBackend.Persistence.Migrations.Transactions
{
    public static class ExampleTransactions
    {
        public static Transaction ExampleSalary { get; } = new Transaction
        {
            Amount = 5000,
            Name = "Wypłata",
            Description = "Wynagrodzenie za pracę",
            Category = DefaultTransactionCategories.Salary,
            Id = Guid.NewGuid(),
            OccuredAt = new DateTimeOffset(2023, 12, 10, 12, 0, 0, TimeSpan.Zero),
        };

        public static Transaction ExampleOtherIncome { get; } = new Transaction
        {
            Amount = 350,
            Name = "Przelew przychodzący",
            Description = "Przelew przychodzący",
            Category = DefaultTransactionCategories.OtherIncome,
            Id = Guid.NewGuid(),
            OccuredAt = new DateTimeOffset(2023, 12, 14, 12, 0, 0, TimeSpan.Zero),
        };

        public static Transaction ExampleBill { get; } = new Transaction
        {
            Amount = -750,
            Name = "Czynsz",
            Description = "",
            Category = DefaultTransactionCategories.Bills,
            Id = Guid.NewGuid(),
            OccuredAt = new DateTimeOffset(2023, 12, 12, 12, 0, 0, TimeSpan.Zero),
        };

        public static Transaction ExampleCommodity { get; } = new Transaction
        {
            Amount = -350,
            Name = "Zakupy",
            Description = "",
            Category = DefaultTransactionCategories.Commodities,
            Id = Guid.NewGuid(),
            OccuredAt = new DateTimeOffset(2023, 12, 16, 12, 0, 0, TimeSpan.Zero),
        };

        public static Transaction ExampleEntertainment { get; } = new Transaction
        {
            Amount = -40,
            Name = "Kino",
            Description = "",
            Category = DefaultTransactionCategories.Entertainment,
            Id = Guid.NewGuid(),
            OccuredAt = new DateTimeOffset(2023, 12, 18, 12, 0, 0, TimeSpan.Zero),
        };

        public static List<Transaction> GetAll()
        {
            return new List<Transaction>
            {
                ExampleSalary,
                ExampleOtherIncome,
                ExampleBill,
                ExampleCommodity,
                ExampleEntertainment,
            };
        }
    }
}