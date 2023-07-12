using EntregasADomicilio.BusinessLayer.Bl;
using EntregasADomicilio.Core.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace EntregasADomicilio.Mvc.Admin.Controllers
{
    public class CategoriasController : Controller
    {
        private readonly UnitOfWork _unitOfWork;

        public CategoriasController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: CategoriasController
        public ActionResult Index()
        {
            List<Categoria> categorias;

            categorias = _unitOfWork.Categoria.ObtenerTodos(true);

            return View(categorias);
        }

        // GET: CategoriasController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoriasController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Categoria categoria)
        {
            try
            {
                _unitOfWork.Categoria.Agregar(categoria);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoriasController/Edit/5
        public ActionResult Edit(int id)
        {
            Categoria categoria;

            categoria = _unitOfWork.Categoria.Obtener(id);

            return View(categoria);
        }

        // POST: CategoriasController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Categoria  categoria)
        {
            try
            {
                _unitOfWork.Categoria.Actualizar(id, categoria);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }       
    }
}
