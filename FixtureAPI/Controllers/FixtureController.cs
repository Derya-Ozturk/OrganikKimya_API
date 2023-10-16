using Business.Abstract;
using Entities.Concrete;
using Entities.Dtos.Fixtures;
using Entities.Dtos.LoginAccount;
using Microsoft.AspNetCore.Mvc;

namespace FixtureAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FixtureController : ControllerBase
    {
        private IFixtureService _fixtureService;
        private ILoginService _loginService;
        public FixtureController(IFixtureService fixtureService, ILoginService loginService)
        {
            _fixtureService = fixtureService;
            _loginService = loginService;
        }

        [HttpPost]
        [Route("loginaccount")]
        public LoginAccountResponseDto LoginAccount(LoginAccountRequestDto loginAccountRequest)
        {
            try
            {
                if (string.IsNullOrEmpty(loginAccountRequest.Password) && string.IsNullOrEmpty(loginAccountRequest.Password))
                {
                    return new LoginAccountResponseDto
                    {
                        Result = false,
                        ResultCode = -99,
                        ResultMessage = "Lütfen email ve şifre alanlarını doldurunuz."
                    };
                }

                var response = _loginService.LoginAccount(loginAccountRequest);

                if (response.Result == true)
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

        [HttpGet]
        [Route("getfixturelist")]
        public object GetFixtureList(string? type = "", string? name = "")
        {
            try
            {
                var response = _fixtureService.GetFixtureList(type, name);

                return response;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        [HttpPost]
        [Route("addtofixturelist")]
        public FixtureResponseDto AddToFixtureList(Fixture fixture)
        {
            try
            {

                if (fixture.Id == 0 && fixture.Type == "string" && fixture.Name == "string" && fixture.Quantity == 0 && fixture.Status == 0)
                {
                    return new FixtureResponseDto
                    {
                        Result = false,
                        ResultCode = -99,
                        ResultMessage = "Lütfen eklemek istediğiniz verileri giriniz."
                    };
                }

                var response = _fixtureService.AddToFixtureList(fixture);

                return new FixtureResponseDto
                {
                    Result = response.Result,
                    ResultCode = response.ResultCode,
                    ResultMessage = response.ResultMessage
                };

            }

            catch (Exception ex)
            {
                return new FixtureResponseDto
                {
                    Result = false,
                    ResultCode = -99,
                    ResultMessage = ex.Message
                };
            }
        }

        [HttpPost]
        [Route("deletefromfixturelist")]
        public FixtureResponseDto DeleteFromFixtureList(int id)
        {
            try
            {
                if (id == 0)
                {
                    return new FixtureResponseDto
                    {
                        Result = false,
                        ResultCode = -99,
                        ResultMessage = "Lütfen silmek istediğiniz verinin id numarasını giriniz."
                    };
                }

                var response = _fixtureService.DeleteFromFixtureList(id);

                return new FixtureResponseDto
                {
                    Result = response.Result,
                    ResultCode = response.ResultCode,
                    ResultMessage = response.ResultMessage
                };
            }

            catch (Exception ex)
            {
                return new FixtureResponseDto
                {
                    Result = false,
                    ResultCode = -99,
                    ResultMessage = ex.Message
                };
            }

        }

        [HttpPost]
        [Route("updatefixturelist")]
        public FixtureResponseDto UpdateFixtureList(Fixture fixture)
        {
            try
            {
                if (fixture.Id == 0)
                {
                    return new FixtureResponseDto
                    {
                        Result = false,
                        ResultCode = -99,
                        ResultMessage = "Lütfen güncellemek istediğiniz verinin id'sini giriniz."
                    };                   
                }

                var response = _fixtureService.UpdateFixtureList(fixture);

                return new FixtureResponseDto
                {
                    Result = response.Result,
                    ResultCode = response.ResultCode,
                    ResultMessage = response.ResultMessage
                };
            }
            catch (Exception ex)
            {
                return new FixtureResponseDto
                {
                    Result = false,
                    ResultCode = -99,
                    ResultMessage = ex.Message
                };
            }

        }

    }
}
