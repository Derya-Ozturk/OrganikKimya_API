
using Entities.Dtos.LoginAccount;

namespace Business.Abstract
{
    public interface ILoginService
    {
        public LoginAccountResponseDto LoginAccount(Entities.Dtos.LoginAccount.LoginAccountRequestDto loginAccountRequest);
    }
}
