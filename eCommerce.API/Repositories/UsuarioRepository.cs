using eCommerce.API.Database;

namespace eCommerce.API.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly EcommerceContext _db;

        public UsuarioRepository(EcommerceContext db)
        {
            _db = db;
        }

        public List<Usuario> Get()
        {
            return _db.Usuarios.OrderBy(x => x.Id).ToList();
        }

        public Usuario Get(int id)
        {
            return _db.Usuarios.Find(id)!;
        }

        public void Add(Usuario usuario)
        {
            _db.Add(usuario); // Ele infere o devido ao tipo. Poderia ser _db.Usuarios.Add(usuario)
            _db.SaveChanges(); // Memory to SGBD
        }

        public void Update(Usuario usuario)
        {
            _db.Update(usuario);
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            _db.Remove(Get(id));
            _db.SaveChanges();
        }
    }
}
