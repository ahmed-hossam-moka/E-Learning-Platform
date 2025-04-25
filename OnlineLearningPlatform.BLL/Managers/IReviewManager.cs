using OnlineLearningPlatform.BLL.Dtos.Reviews;
using System.Collections.Generic;

namespace OnlineLearningPlatform.BLL.Managers
{
    public interface IReviewManager
    {
        IEnumerable<ReviewReadDto> GetAll();
        ReviewReadDto GetById(int id);
        void Add(ReviewAddDto review);
        void Update(ReviewUpdateDto review);
        void Delete(int id);
    }

}