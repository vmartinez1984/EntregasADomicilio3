using EntregasADomicilio.BusinessLayer.Contexts;
using EntregasADomicilio.Core.Entidades;
using EntregasADomicilio.BusinessLayer.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace EntregasADomicilio.BusinessLayer.Bl
{
    public class PlatilloBl
    {
        private readonly AppDbContext _appDbContext;

        public PlatilloBl(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public void Actualizar(int id, Platillo platillo)
        {
            Platillo platillo1;

            platillo1 = Obtener(id);
            platillo1.CategoriaId = platillo.CategoriaId;
            platillo1.EstaActivo = platillo.EstaActivo;
            platillo1.Descripcion = platillo.Descripcion;
            platillo1.Nombre = platillo.Nombre;
            platillo1.Precio = platillo.Precio;
            platillo1.NombreDelArchivo = platillo.NombreDelArchivo;
            //platillo1.Ruta = platillo.Ruta;
            if (platillo.FormFile != null)
            {
                platillo1.ImagenEnBytes = platillo.FormFile.OpenReadStream().ReadToEnd();// ObtenerBytes(platillo.FormFile);
                platillo1.ContentType = platillo.FormFile.ContentType;
                platillo1.NombreDelArchivo = platillo.FormFile.FileName;
                //platillo1.ImagenEnBase64 = Convert.ToBase64String(platillo.FormFile.OpenReadStream().ReadToEnd());
            }
            _appDbContext.Update(platillo1);

            _appDbContext.SaveChanges();
        }

        public int Agregar(Platillo platillo)
        {
            if (platillo != null)
            {
                platillo.ImagenEnBytes = platillo.FormFile.OpenReadStream().ReadToEnd();// ObtenerBytes(platillo.FormFile);
                platillo.ContentType = platillo.FormFile.ContentType;
                platillo.NombreDelArchivo = platillo.FormFile.FileName;
            }
            //platillo.ImagenEnBase64 = Convert.ToBase64String(platillo.FormFile.OpenReadStream().ReadToEnd());
            _appDbContext.Platillo.Add(platillo);
            _appDbContext.SaveChanges();

            return platillo.Id;
        }

        private byte[] ObtenerBytes(IFormFile formFile)
        {
            byte[] bytes;

            using (var memoryStream = new MemoryStream())
            {
                formFile.CopyTo(memoryStream);
                bytes = memoryStream.ToArray();
            }

            return bytes;
        }

        public Platillo Obtener(int id)
        {
            Platillo platillo;

            platillo = _appDbContext.Platillo.Where(x => x.Id == id).FirstOrDefault();

            return platillo;
        }

        public List<Platillo> ObtenerPorCategoriaId(int categoriaId)
        {
            List<Platillo> lista;

            lista = _appDbContext.Platillo.Where(x => x.EstaActivo == true && x.CategoriaId == categoriaId).ToList();

            return lista;
        }

        public List<Platillo> ObtenerTodos()
        {
            List<Platillo> lista;

            lista = _appDbContext.Platillo
                .Include(x => x.Categoria)
                .Where(x => x.EstaActivo == true).ToList();
            lista.ForEach(platillo =>
            {
                if (platillo.ImagenEnBytes == null)
                {
                    platillo.Ruta = string.Empty;
                }
                else
                {
                    platillo.ImagenEnBytes = null;
                    platillo.Ruta = $"/Platillos/{platillo.Id}/Imagen";
                }
            });

            return lista;
        }
    }
}
