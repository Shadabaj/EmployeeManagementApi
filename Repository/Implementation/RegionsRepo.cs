using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Models;
using Repository.Interface;

namespace Repository.Implementation
{
    class RegionsRepo : IRegionsRepo
    {
        private readonly AppDbContext _Db;

        public RegionsRepo(AppDbContext Db)
        {
            _Db = Db;
        }

        public IEnumerable<CountryModel> GetCountry()
        {
            try
            {
                var country = _Db.Countries.Select(c => new CountryModel
                {
                    RowId=c.RowId,
                    CountryName=c.CountryName
                }).ToList();

                return country;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return null;
        }

        public IEnumerable<StateModel> GetState()
        {
            try
            {
                var States = _Db.States.Select(c => new StateModel
                {
                    RowId=c.RowId,
                    CountryId=c.CountryId,
                    StateName=c.StateName
                }).ToList();
                return States;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        public IEnumerable<CityModel> GetCity()
        {
            try
            {
                var cities = _Db.Cities.Select(c => new CityModel
                {
                    RowId = c.RowId,
                    StateId = c.StateId,
                    CityName = c.CityName
                }).ToList();

                return cities;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

      

       
    }
}
