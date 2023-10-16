using Business.Abstract;
using DataAccess.Abstract;
using Entities.Dtos.LoginAccount;

namespace Business.Concrete
{
    public class LoginManager : ILoginService
    {
        ILoginDal _loginDal;
        public LoginManager(ILoginDal loginDal)
        {
            _loginDal = loginDal;
        }

        public LoginAccountResponseDto LoginAccount(LoginAccountRequestDto loginAccountRequest)
        {
            try
            {
                if (loginAccountRequest.Email == null || loginAccountRequest.Password == null)
                {
                    return new LoginAccountResponseDto
                    {
                        Result = false,
                        ResultCode = -99,
                        ResultMessage = "Eksik bilgi. Lütfen bilgileri eksiksiz giriniz.",
                    };
                }

                var response = _loginDal.LoginAccount(loginAccountRequest);

                if (response.LoginData != null)
                {
                    return new LoginAccountResponseDto
                    {
                        Result = true,
                        ResultCode = 10000,
                        ResultMessage = "Giriş işlemi başarılı",
                        LoginData = new LoginAccount
                        {
                            Email = loginAccountRequest.Email,
                            Password = loginAccountRequest.Password
                        }

                    };
                }

                return new LoginAccountResponseDto
                {
                    Result = false,
                    ResultCode = -99,
                    ResultMessage = response.ResultMessage
                }; ;
            }

            catch (Exception ex)
            {
                return new LoginAccountResponseDto
                {
                    Result = false,
                    ResultCode = -99,
                    ResultMessage = ex.Message,
                }; ;
            }
        }
    }
}
