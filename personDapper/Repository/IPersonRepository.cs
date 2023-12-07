using personDapper.Models;

namespace personDapper.Repository
{
    public interface IPersonRepository
    {
        List<Person> GetAll(string que, object parametres = null);
        public Person GetById(string que, object parametres=null);
        void Insert(Person person);
        void Update( Person person);
        void Delete(string que, object parametres=null);
    }

}
