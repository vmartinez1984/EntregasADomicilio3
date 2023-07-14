using EntregasADomicilio.BusinessLayer.Bl;
using EntregasADomicilio.Core.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EntregasADomicilio.Mvc.Admin.Controllers
{
    public class PlatillosController : Controller
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public PlatillosController(UnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: PlatillosController
        public ActionResult Index()
        {
            List<Platillo> platillos;

            platillos = _unitOfWork.Platillo.ObtenerTodos();

            return View(platillos);
        }

        // GET: PlatillosController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PlatillosController/Create
        public ActionResult Create()
        {
            ViewBag.Categorias = new SelectList( _unitOfWork.Categoria.ObtenerTodos(),"Id","Nombre");

            return View();
        }

        // POST: PlatillosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Platillo platillo)
        {
            try
            {                
                _unitOfWork.Platillo.Agregar(platillo);               
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PlatillosController/Edit/5
        public ActionResult Edit(int id)
        {
            Platillo platillo;

            platillo = _unitOfWork.Platillo.Obtener(id);
            ViewBag.Categorias = new SelectList(_unitOfWork.Categoria.ObtenerTodos(), "Id", "Nombre");

            return View(platillo);
        }

        // POST: PlatillosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Platillo platillo)
        {
            try
            {
                //Guid guid = Guid.NewGuid();
                //var fileName = System.IO.Path.Combine(_webHostEnvironment.ContentRootPath, "wwwroot", "img", "platillos", $"{guid}.jpg");
                ////C:\Users\vmartinez\source\repos\EntregasADomicilio\EntregasADomicilio.Mvc.Admin\wwwroot\img\platillos\
                //platillo.FormFile.CopyToAsync(new System.IO.FileStream(fileName, System.IO.FileMode.Create));
                //platillo.Ruta = System.IO.Path.Combine("wwwroot", "img", "platillos", $"{guid}.jpg");
                //platillo.NombreDelArchivo = platillo.FormFile.FileName;
                _unitOfWork.Platillo.Actualizar(id,platillo);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ViewBag.Categorias = new SelectList(_unitOfWork.Categoria.ObtenerTodos(), "Id", "Nombre");
                return View(platillo);
            }
        }

        [HttpGet("Platillos/{platilloId}/Imagen")]
        public ActionResult ObtenerIamgen(int platilloId)
        {            
            Platillo platillo;

            platillo = _unitOfWork.Platillo.Obtener(platilloId);            

            return File(platillo.ImagenEnBytes, platillo.ContentType);
        }
    }
}
