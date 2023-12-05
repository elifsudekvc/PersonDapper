using personDapper.Models;

namespace personDapper.Repository
{
    public interface IDepartmantRepository
    {
        IEnumerable<Departmant> GetAll();
        public Departmant GetById(int DepartmantId);
        void Insert(Departmant departmant);
        void Update(Departmant departmant);
        void Delete(int DepartmantId);
    }

}
