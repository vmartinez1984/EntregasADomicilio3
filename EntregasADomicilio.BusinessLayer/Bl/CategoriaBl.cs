using EntregasADomicilio.BusinessLayer.Contexts;
using EntregasADomicilio.Core.Entidades;

namespace EntregasADomicilio.BusinessLayer.Bl
{
    public class CategoriaBl
    {
        private readonly AppDbContext _appDbContext;

        public CategoriaBl(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public void Actualizar(int id, Categoria categoria)
        {
            Categoria original;

            original = Obtener(id);
            original.EstaActivo = categoria.EstaActivo;
            original.Nombre = categoria.Nombre;
            _appDbContext.Categoria.Update(original);

            _appDbContext.SaveChanges();
        }

        public int Agregar(Categoria categoria)
        {
            _appDbContext.Categoria.Add(categoria);
            _appDbContext.SaveChanges();

            return categoria.Id;
        }

        public Categoria Obtener(int id)
        {
            return _appDbContext.Categoria.Where(x => x.Id == id).FirstOrDefault();
        }

        public List<Categoria> ObtenerTodos(bool todos = false)
        {
            if (todos)
                return _appDbContext.Categoria.ToList();
            else
                return _appDbContext.Categoria.Where(x => x.EstaActivo == true).ToList();
        }
    }
}
