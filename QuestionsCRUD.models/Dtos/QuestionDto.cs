using System.Collections;
using System.Transactions;

namespace QuestionsCRUD.models.Dtos;

public class QuestionDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public Dictionary<int,String> Answers { get; set; }
    public bool Type { get; set; }
    public string Answer { get; set; }
}