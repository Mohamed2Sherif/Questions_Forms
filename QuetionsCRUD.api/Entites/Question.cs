using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace QuetionsCRUD.api.Entites;

public class Question
{
    public int Id { get; set; }
    
    public string QuestionTitle { get; set; }
    
    [Column(TypeName = "jsonb")]
    public string Choices  { get; set; }
    public bool Type { get; set; }
    public string Answer { get; set; }
    
}