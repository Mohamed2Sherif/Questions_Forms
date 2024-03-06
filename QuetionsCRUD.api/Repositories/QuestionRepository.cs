using Microsoft.EntityFrameworkCore;
using QuetionsCRUD.api.Data;
using QuetionsCRUD.api.Entites;
using QuetionsCRUD.api.Repositories.Contracts;

namespace QuetionsCRUD.api.Repositories;

public class QuestionRepository:IQuestionRepository
{
    private readonly QuestionsCrudDbContext _dbcontext;

    public QuestionRepository(QuestionsCrudDbContext _dbcontext)
    {
        this._dbcontext = _dbcontext;
        
    }
    public async Task<IEnumerable<Question>> GetQuestions()
    {
        var questions = await _dbcontext.Questions.ToListAsync();
        return questions;
    }

    public async Task<Question> GetQuestion(int Id)
    {
        var question = await _dbcontext.Questions.FirstAsync(p => p.Id == Id);
        return question;
    }

    public async Task<bool> AddQuestion(Question question)
    {
        await _dbcontext.Questions.AddAsync(question);
        return await _dbcontext.SaveChangesAsync() > 0;
    }


    public async Task<bool> UpdateQuestion(Question requestQuestion,Question existingQuestion)
    {
        existingQuestion.QuestionTitle = requestQuestion.QuestionTitle;
        existingQuestion.Answer = requestQuestion.Answer;
        existingQuestion.Choices = requestQuestion.Choices;
        return await _dbcontext.SaveChangesAsync() > 0;
    }
    

    public async Task<bool> DeleteQuestion(int Id)
    {
        var questionToDelete = await _dbcontext.Questions.FindAsync(Id);
        _dbcontext.Remove(questionToDelete);
        return await _dbcontext.SaveChangesAsync() > 0;
    }
}