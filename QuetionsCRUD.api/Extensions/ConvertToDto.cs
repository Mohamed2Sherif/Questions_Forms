using Newtonsoft.Json;
using QuestionsCRUD.models.Dtos;
using QuetionsCRUD.api.Entites;

namespace QuetionsCRUD.api.Extensions;

public static class ConvertToDto
{
    public static IEnumerable<QuestionDto> ConvertToQuestionDto(this IEnumerable<Question> questions)
    { 
        foreach (var question in questions)
        {
            Dictionary<int,String> answers = JsonConvert.DeserializeObject<Dictionary<int, String>>(question.Choices);
            var questionDto = new QuestionDto
            {
                Id = question.Id,
                Title = question.QuestionTitle,
                Answers = answers,
                Type = question.Type,
                Answer = question.Answer
            };
            yield return questionDto;
        }
        
    }

    public static QuestionDto ConvertToQuestionDto(this Question question)
    {
        Dictionary<int,String> answers = JsonConvert.DeserializeObject<Dictionary<int, String>>(question.Choices);
        var questionDto = new QuestionDto
        {
            Id = question.Id,
            Title = question.QuestionTitle,
            Answers = answers,
            Type = question.Type,
            Answer = question.Answer
        };
         return questionDto;
    }
}