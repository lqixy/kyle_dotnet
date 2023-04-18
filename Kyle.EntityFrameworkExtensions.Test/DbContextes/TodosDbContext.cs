using Microsoft.EntityFrameworkCore;

namespace Kyle.EntityFrameworkExtensions.Test.DbContextes;

public class TodosDbContextTest: KyleDbContextBase
{
    public TodosDbContextTest(DbContextOptions<TodosDbContextTest> options): base(options){}
}