using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Repository.Interface
{
    public interface IRegionsRepo
    {

        IEnumerable<CountryModel> GetCountry();

        IEnumerable<StateModel> GetState();

        IEnumerable<CityModel> GetCity();

        

    }
}
