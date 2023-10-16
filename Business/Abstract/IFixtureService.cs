
using Entities.Concrete;
using Entities.Dtos.Fixtures;
using Entities.Dtos.LoginAccount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IFixtureService
    {
        public object GetFixtureList(string type, string name);

        public FixtureResponseDto AddToFixtureList(Fixture fixture);

        public FixtureResponseDto DeleteFromFixtureList(int id);

        public FixtureResponseDto UpdateFixtureList(Fixture fixture);

    }
}
