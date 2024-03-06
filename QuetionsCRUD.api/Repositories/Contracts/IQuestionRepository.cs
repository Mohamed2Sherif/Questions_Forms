using QuetionsCRUD.api.Entites;

namespace QuetionsCRUD.api.Repositories.Contracts;

public interface IQuestionRepository
{
     public Task<IEnumerable<Question>> GetQuestions();
     public Task<Question> GetQuestion(int Id);
     public Task<bool> AddQuestion(Question question);
     public Task<bool> UpdateQuestion(Question question,Question existingQuestion);
     public Task<bool> DeleteQuestion(int Id);
     

}