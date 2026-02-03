using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepasoActividadesEventos.Models;
using RepasoActividadesEventos.Repositories;

namespace RepasoActividadesEventos.Controllers
{
    public class AlumnosController : Controller
    {
        RepositoryAlumnos repoAl;
        RepositoryActividades repoAc;
        RepositoryInscripciones repoIn;
        RepositoryCurso repoCu;
        public AlumnosController()
        {
            this.repoAl = new RepositoryAlumnos();
            this.repoAc = new RepositoryActividades();
            this.repoIn = new RepositoryInscripciones();
            this.repoCu = new RepositoryCurso();
        }
        public ActionResult Index()
        {
            List<Usuarios> u = this.repoAl.LoadUsuarios();
            return View(u);
        }
        public ActionResult Details(int id)
        {
            Usuarios u = this.repoAl.FindUsuario(id);
            List<Inscripciones> inscripciones = this.repoIn.GetInscripcionesUsuario(id);
            List<Actividades> a = this.repoAc.GetActividades();
            Curso c = this.repoCu.GetCursos(u.IdCurso);

            foreach (var ins in inscripciones)
            {
                ins.NombreActividad = a.FirstOrDefault(x => x.idActividad == ins.IdEventoActividad).Nombre;
            }

            ResumenUsuario res=new ResumenUsuario()
            {
                usu = u,
                inscripciones = inscripciones,
                nombreCurso = c.Nombre
            };

            return View(res);
        }
    }
}
