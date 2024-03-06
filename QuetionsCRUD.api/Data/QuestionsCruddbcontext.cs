using Microsoft.EntityFrameworkCore;
using QuetionsCRUD.api.Entites;

namespace QuetionsCRUD.api.Data;

public class QuestionsCrudDbContext : DbContext
{
    public QuestionsCrudDbContext(DbContextOptions options):base(options)
    {
    }
    public DbSet<Question> Questions { get; set; }
    
}