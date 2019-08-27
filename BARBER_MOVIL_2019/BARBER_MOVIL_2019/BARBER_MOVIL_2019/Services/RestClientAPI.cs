using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;
using BARBER_MOVIL_2019.Model;

namespace BARBER_MOVIL_2019.Services
{
    public class RestClientAPI : IRestClientAPI
    {
        private readonly IRestClientAPI _restClient;

        public RestClientAPI()
        {
            _restClient = RestService.For<IRestClientAPI>(RestEndPoints.BaseUrl);
        }

        //public async Task AddPost(User post)
        //{
        //    await _restClient.AddPost(post);
        //}

        public async Task<ICollection<User>> GetAll()
        {
            return await _restClient.GetAll();
        }

        public async Task<User> GetAll(int id)
        {
            return await _restClient.GetAll(id);
        }
    }
}
