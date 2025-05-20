using OnlineLearningPlatform.BLL.Dtos.Earnings;
using System.Collections.Generic;

namespace OnlineLearningPlatform.BLL.Managers
{
    public interface IEarningsManager
    {
        IEnumerable<EarningsReadDto> GetAll();
        EarningsReadDto GetById(int id);
        void Add(EarningsAddDto earning);
        void Update(EarningsUpdateDto earning);
    }
}