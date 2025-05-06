using OnlineLearningPlatform.BLL.Dtos.Withdrawal;

namespace OnlineLearningPlatform.BLL.Managers
{
    public interface IWithdrawalManager
    {
        IEnumerable<WithdrawalReadDto> GetAll();
        WithdrawalReadDto GetById(int id);
        void Add(WithdrawalAddDto withdrawal);
        void Update(WithdrawalUpdateDto withdrawal);
    }
}