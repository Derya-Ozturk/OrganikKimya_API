using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;
using Entities.Dtos;
using Entities.Dtos.LoginAccount;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfLoginDal : EfEntityRepositoryBase<User, DatabaseContext>, ILoginDal
    {

        public LoginAccountResponseDto LoginAccount(LoginAccountRequestDto loginAccountRequest)
        {
            try
            {
                var response = Get(a => a.Email == loginAccountRequest.Email && a.Password == loginAccountRequest.Password);

                if (response == null)
                {
                    return new LoginAccountResponseDto
                    {
                        Result = false,
                        ResultCode = -99,
                        ResultMessage = "Verilen bilgilerle eşleşen bir kullanıcı bulunamadı. Lütfen tekrar deneyiniz."
                    };
                }

                return new LoginAccountResponseDto
                {
                    Result = true,
                    ResultCode = 10000,
                    ResultMessage = "Başarılı",
                    LoginData = new LoginAccount
                    {
                        Email = loginAccountRequest.Email,
                        Password = loginAccountRequest.Password
                    }

                };
            }

            catch (Exception ex)
            {
                return new LoginAccountResponseDto
                {
                    Result = false,
                    ResultCode = -99,
                    ResultMessage = ex.Message
                };
            }
        }
    }
}
