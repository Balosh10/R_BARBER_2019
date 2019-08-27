using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;
using BARBER_MOVIL_2019.Model;

namespace BARBER_MOVIL_2019.Services
{
    public interface IRestClientAPI
    {
        [Get("/posts")]
        Task<ICollection<User>> GetAll();

        [Get("/posts/{id}")]
        Task<User> GetAll(int id);

        //[Post("/posts")]
        //Task AddPost(User post);
    }
}
