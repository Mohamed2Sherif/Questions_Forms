using Newtonsoft.Json;
using QuestionsCRUD.models.Dtos;
using QuetionsCRUD.api.Entites;

namespace QuetionsCRUD.api.Extensions;

public static class ConvertFromDto
{
    public static Question ConvertFromQuestionDto(this QuestionDto questionDto)
    { 
        var questionObj = new Question();
        questionObj.Choices = JsonConvert.SerializeObject(questionDto.Answers);
        questionObj.Id = questionDto.Id;
        questionObj.Answer = questionDto.Answer;
        questionObj.QuestionTitle = questionDto.Title;
        questionObj.Type = questionDto.Type;

        return questionObj;



    }

    public static Question ConvertFromUQuestionDto(this UpdateQuestionDto uQuestionDto)
    {
        var questionObj = new Question();
        questionObj.Choices = JsonConvert.SerializeObject(uQuestionDto.Answers);
        questionObj.Answer = uQuestionDto.Answer;
        questionObj.QuestionTitle = uQuestionDto.Title;
        return questionObj;
    }
}