namespace QuestionsCRUD.models.Dtos;

public class UpdateQuestionDto
{
    public string Title { get; set; }
    public Dictionary<int,string> Answers { get; set; }
    public string Answer { get; set; }
    
}