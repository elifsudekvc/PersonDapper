using personDapper.Models;

namespace personDapper.Repository
{
    public interface IPersonRepository
    {
        IEnumerable<Person> GetAll();
        public Person GetById(int id);
        void Insert(Person person);
        void Update(Person person);
        void Delete(int id);
    }

}
