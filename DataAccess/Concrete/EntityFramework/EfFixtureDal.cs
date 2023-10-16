using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;
using Entities.Dtos.Fixtures;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfFixtureDal : EfEntityRepositoryBase<Fixture, DatabaseContext>, IFixtureDal
    {

        DatabaseContext dbContext = new();

        public object GetFixtureList(string type, string name)
        {
            try
            {
                if (string.IsNullOrEmpty(type) && string.IsNullOrEmpty(name))
                {
                    return GetList(a => a.Status == 1);
                }

                return GetList(a => (a.Type == type || a.Name == name) && a.Status == 1);
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
                var response = Add(fixture);

                if (response > 0)
                {
                    return new FixtureResponseDto
                    {
                        Result = true,
                        ResultCode = 10000,
                        ResultMessage = "Ekleme işlemi başarıyla gerçekleştirildi."
                    };
                }

                return new FixtureResponseDto
                {
                    Result = false,
                    ResultCode = -99,
                    ResultMessage = "Ekleme işlemi başarısız."
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
                var deletedData = dbContext.Fixture.Where(a => a.Id == id).FirstOrDefault();

                var response = Delete(deletedData);

                if (response > 0)
                {
                    return new FixtureResponseDto
                    {
                        Result = true,
                        ResultCode = 10000,
                        ResultMessage = "Silme işlemi başarıyla gerçekleştirildi."
                    };
                }

                return new FixtureResponseDto
                {
                    Result = false,
                    ResultCode = -99,
                    ResultMessage = "Silme işlemi başarısız."
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
                var response = Update(fixture);

                if (response > 0)
                {
                    return new FixtureResponseDto
                    {
                        ResultCode = 10000,
                        Result = true,
                        ResultMessage = "Güncelleme işlemi başarılı"
                    };
                }

                return new FixtureResponseDto
                {
                    ResultCode = -99,
                    Result = false,
                    ResultMessage = "Güncelleme işlemi başarısız"
                };

            }
            catch (Exception ex)
            {
                return new FixtureResponseDto
                {
                    ResultCode = -99,
                    Result = false,
                    ResultMessage = ex.Message
                };
            }
        }
    }
}
