using System.Collections.Generic;
using System.Threading.Tasks;
using person_api.Model;

namespace person_api.Repository
{
    public interface IPersonRepository
    {
        Task<Person> GetById(int id);
        Task<IEnumerable<Person>> GetAll();
        Task<int> Add(Person person);
        Task<int> Update(Person person);
        Task<int> Delete(int id);
    }
}