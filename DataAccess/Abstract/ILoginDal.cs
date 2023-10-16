using Core.DataAccess;
using Entities.Concrete;
using Entities.Dtos.LoginAccount;


namespace DataAccess.Abstract
{
    public interface ILoginDal : IEntityRepository<User>
    {
        public LoginAccountResponseDto LoginAccount(LoginAccountRequestDto loginAccountRequest);
    }
}
