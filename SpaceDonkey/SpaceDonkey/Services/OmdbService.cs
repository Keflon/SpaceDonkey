using SpaceDonkey.Models.Omdb;
using SpaceDonkey.Services.Rest;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SpaceDonkey.Services
{
    public class OmdbService
    {
        private readonly IRestService _restService;

        public OmdbService(IRestService restService)
        {
            if (_restService == null)
                throw new ArgumentNullException("restService");

            _restService = restService;
        }


        //_omdbService.GetMovies

        public async Task<MovieCollectionModel> GetMoviesAsync(string filter)
        {
            var result = await _restService.GetAsync<MovieCollectionModel>("movies/" + filter);

            return result.payload;
        }
    }
}
