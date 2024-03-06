using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using QuestionsCRUD.models.Dtos;
using QuetionsCRUD.api.Entites;
using QuetionsCRUD.api.Extensions;
using QuetionsCRUD.api.Repositories.Contracts;

namespace QuetionsCRUD.api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class QuestionController:ControllerBase
{
    private readonly IQuestionRepository _questionRepository;

    public QuestionController(IQuestionRepository _questionRepository)
    {
        this._questionRepository = _questionRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<QuestionDto>>> GetQuestions()
    {
        try
        {
            var questions = await _questionRepository.GetQuestions();
            if (questions == null)
            {
                return NotFound();
            }
            else
            {
                IEnumerable<QuestionDto> questionsDto = questions.ConvertToQuestionDto();
                return Ok(questionsDto);
            }
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,"Error retrieving data from the database");
        }
    }

    [HttpPost]
    public async Task<ActionResult> AddQuestion(QuestionDto questionDto)
    {
        try
        {
            var question = questionDto.ConvertFromQuestionDto();
            var created = await _questionRepository.AddQuestion(question);
            if (created)
            {
                return StatusCode(StatusCodes.Status201Created, "success");
            }
            else
            {
                var error_message = "Error happend while Creating Question";
                throw new Exception(error_message);
            }
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpGet("{Id:int}")]
    public async Task<ActionResult<QuestionDto>> GetQuestion(int Id)
    {
        try
        {
            var question = await _questionRepository.GetQuestion(Id);
            if (question == null)
            {
                return NotFound();
            }
            else
            {
                QuestionDto question_Dto = question.ConvertToQuestionDto();
                return Ok(question_Dto);
            }
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,"Error retrieving data from the database");
 
        }
    }

    [HttpPut("({id:int})")]
    public async Task<ActionResult> UpdateQuestion(int id, [FromBody] UpdateQuestionDto  uQuestionDto)
    {
        try
        {

            var existing_question = await _questionRepository.GetQuestion(id);
            if (existing_question == null)
            {
                return NotFound();
            }

            var question = uQuestionDto.ConvertFromUQuestionDto();
            bool isUpdated = await _questionRepository.UpdateQuestion(question,existing_question);
            if (isUpdated)
            {
                return Ok();
            }
            else
            {
                return StatusCode(500);
            }
            
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
        }
    }

    [HttpDelete("{Id:int}")]
    public async Task<ActionResult> DeleteQuestion(int Id)
    {
        try
        {

            var deleted = await _questionRepository.DeleteQuestion(Id);
            if (deleted)
            {
                return StatusCode(StatusCodes.Status200OK, "Question Deleted successfully");
            }
            else
            {
                var message = "Error while deleting the question";
                throw new Exception(message);
            }

        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
        }
    }
}