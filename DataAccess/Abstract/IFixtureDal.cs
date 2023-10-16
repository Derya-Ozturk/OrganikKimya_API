using Core.DataAccess;
using Entities.Concrete;
using Entities.Dtos.Fixtures;

namespace DataAccess.Abstract
{
    public interface IFixtureDal : IEntityRepository<Fixture>
    {
        public object GetFixtureList(string type, string name);
        public FixtureResponseDto AddToFixtureList(Fixture fixture);
        public FixtureResponseDto DeleteFromFixtureList(int id);
        public FixtureResponseDto UpdateFixtureList(Fixture fixture);

    }
}
