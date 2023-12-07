using personDapper.Models;

namespace personDapper.Repository
{
    public interface IVKIRepository
    {
        List<VKI> GetAll(string que, object parametres = null);
        public VKI GetById(string que, object parametres = null);
        public void Insert(VKI vki);
        void Delete(string que, object parametres = null);

    }

}
