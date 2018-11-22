using AppDigitalCv.Business.Interface;
using AppDigitalCv.Domain;
using AppDigitalCv.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppDigitalCv.Controllers
{
    public class DireccionController : Controller
    {
        IDireccionBussines IdireccionBusiness;

        public DireccionController(IDireccionBussines _IdDireccionBusiness)
        {
            IdireccionBusiness = _IdDireccionBusiness;

        }

        // GET: Direccion
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Pais = new SelectList(IdireccionBusiness.GetPais(), "IdPais", "StrValor");
            ViewBag.Estados = new SelectList("");
            ViewBag.Municipios = new SelectList("");
            ViewBag.Colonias = new SelectList("");
            return View();
        }

        /// <summary>
        /// Este metodo se encarga de hacer una consulta de los estados de un pais
        /// </summary>
        /// <param name="idPais"> pide el id de pais para asi realizar la consulta </param>
        /// <returns> Regresa una vista parecial que contiene una lista de estados dependiendo del pais seleccionado </returns>
        [HttpPost]
        public ActionResult ConsultarEstadosByPais(int idPais)
        {
            List<EstadoDomainModel> estadosDM = IdireccionBusiness.GetEstadoByIdPais(idPais);
            List<EstadoVM> estadosVM = new List<EstadoVM>();

            AutoMapper.Mapper.Map(estadosDM, estadosVM);
            ViewBag.Estados = new SelectList(estadosVM, "IdEstado", "StrValor");
            return PartialView("_Estados");
        }

        /// <summary>
        /// Este metodo se encarga de realizar la consulta de municipios cuando se selecciona un estado
        /// </summary>
        /// <param name="idEstado"> Pide el ID de estado para realizar la consulta </param>
        /// <returns> Regresa una vista parcialo con los datos cargados de los municipios </returns>
        [HttpPost]
        public ActionResult ConsultarMunicipiosByEstado(int idEstado)
        {
            List<MunicipioDomainModel> municipiosDM = IdireccionBusiness.GetMunicipioByIdEstado(idEstado);
            List<MunicipioVM> municipiosVM = new List<MunicipioVM>();

            AutoMapper.Mapper.Map(municipiosDM, municipiosVM);
            ViewBag.Municipios = new SelectList(municipiosVM, "IdMunicipio", "StrValor");
            return PartialView("_Municipios");
        }

        /// <summary>
        /// Este metodo se encarga de realizar la consulta de las colonias apor medio del ID del municipio
        /// </summary>
        /// <param name="idMunicipio"> Requere el Id del municipio para hacer la consulta </param>
        /// <returns> Regresa una vista parcial de colonias acorde al municipio seleccionado </returns>
        [HttpPost]
        public ActionResult ConsultarColoniasByMunicipio(int idMunicipio)
        {
            List<ColoniaDomainModel> coloniaDM = IdireccionBusiness.GetColoniaByMunicipio(idMunicipio);
            List<ColoniaVM> coloniasVM = new List<ColoniaVM>();

            AutoMapper.Mapper.Map(coloniaDM, coloniasVM);
            ViewBag.Colonias = new SelectList(coloniasVM, "IdColonia", "StrValor");
            return PartialView("_Colonias");
        }

        [HttpPost]
        public JsonResult ConsultarCodigoPostalByColonia(int idColonia)
        {
            string codigoPostal = IdireccionBusiness.GetCodigoPostalByColonia(idColonia);

            return Json(codigoPostal, JsonRequestBehavior.AllowGet);
        }
    }
}