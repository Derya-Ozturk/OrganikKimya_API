using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos.Fixtures;
using Entities.Dtos.LoginAccount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class FixtureManager : IFixtureService
    {
        IFixtureDal _fixtureDal;
        public FixtureManager(IFixtureDal fixtureDal)
        {
            _fixtureDal = fixtureDal;
        }

        public object GetFixtureList(string type, string name)
        {
            try
            {
                var response = _fixtureDal.GetFixtureList(type, name);

                return response;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public FixtureResponseDto AddToFixtureList(Fixture fixture)
        {
            try
            {
                var response = _fixtureDal.AddToFixtureList(fixture);

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

        public FixtureResponseDto DeleteFromFixtureList(int id)
        {
            try
            {
                var response = _fixtureDal.DeleteFromFixtureList(id);

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

        public FixtureResponseDto UpdateFixtureList(Fixture fixture)
        {
            try
            {
                var response = _fixtureDal.UpdateFixtureList(fixture);

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
