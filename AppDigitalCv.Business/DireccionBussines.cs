using AppDigitalCv.Business.Interface;
using AppDigitalCv.Domain;
using AppDigitalCv.Repository;
using AppDigitalCv.Repository.Infraestructure.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AppDigitalCv.Business
{
    public class DireccionBussines : IDireccionBussines
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly PaisRepository paisRepository;
        private readonly EstadoRepository estadoRepository;
        private readonly MunicipioRepository municipioRepository;
        private readonly ColoniaRepository coloniaRepository;

        public DireccionBussines(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            paisRepository = new PaisRepository(unitOfWork);
            estadoRepository = new EstadoRepository(unitOfWork);
            municipioRepository = new MunicipioRepository(unitOfWork);
            coloniaRepository = new ColoniaRepository(unitOfWork);
        }

        //Metodo para obtener los paises 
        public List<PaisDomainModel> GetPais()
        {
            ///creamos la lista de paises, se encuentra vacia
            List<PaisDomainModel> paises = null;

            //consultamos todos los paises y los almacenamos en la lista de paises
            paises = paisRepository.GetAll().Select(p => new PaisDomainModel { IdPais = p.id, StrValor = p.strValor }).ToList();
            PaisDomainModel inicial = new PaisDomainModel();
            inicial.IdPais = 0;
            inicial.StrValor = "Seleccionar";
            paises.Insert(0, inicial);
            return paises;
        }


        /// <summary>
        /// Este metodo se encarga de consultar estados por el id del páis
        /// </summary>
        /// <param name="idPais"> Recibe el id del pais</param>
        /// <returns> Regresa una lista de estados que pertenecen a un pais </returns>
        public List<EstadoDomainModel> GetEstadoByIdPais(int idPais)
        {
            List<CatEstado> catEstados = null;
            Expression<Func<CatEstado, bool>> predicado = p => p.idPais.Equals(idPais);

            List<EstadoDomainModel> estadosDM = new List<EstadoDomainModel>();
            catEstados = estadoRepository.GetAll(predicado).ToList();

            foreach (CatEstado estados in catEstados)
            {
                EstadoDomainModel estadoDM = new EstadoDomainModel();
                estadoDM.IdEstado = estados.id;
                estadoDM.StrValor = estados.strValor;
                estadoDM.IdPais = estados.idPais;
                estadosDM.Add(estadoDM);
            }
            return estadosDM;
        }

        /// <summary>
        /// Este metodo se encarga de consultar los municipios por el id del estado
        /// </summary>
        /// <param name="idEstado"> Requiere recibir el id del estado </param>
        /// <returns> Regresa una lista de los estados dependiendo el pais seleccionado </returns>
        public List<MunicipioDomainModel> GetMunicipioByIdEstado(int idEstado)
        {
            List<CatMunicipio> catMunicipios = null;
            Expression<Func<CatMunicipio, bool>> predicado = p => p.idEstado.Equals(idEstado);

            List<MunicipioDomainModel> municipiosDM = new List<MunicipioDomainModel>();
            catMunicipios = municipioRepository.GetAll(predicado).ToList();


            foreach (CatMunicipio municipios in catMunicipios)
            {
                MunicipioDomainModel municipioDM = new MunicipioDomainModel();
                municipioDM.IdMunicipio = municipios.id;
                municipioDM.StrValor = municipios.strValor;
                municipioDM.IdEstado = municipios.idEstado;
                municipiosDM.Add(municipioDM);
            }
            return municipiosDM;
        }

        /// <summary>
        /// Este metodo se encarga de consultar las colonias por medio del id del municipio
        /// </summary>
        /// <param name="idMunicipio"> Requere del id del municipio para realizar la consulta </param>
        /// <returns> Regresa una lista de colonias dependiendo del municipio seleccionado </returns>
        public List<ColoniaDomainModel> GetColoniaByMunicipio(int idMunicipio)
        {
            List<CatColonia> catColonias = null;
            Expression<Func<CatColonia, bool>> predicado = p => p.idMunicipio.Equals(idMunicipio);

            List<ColoniaDomainModel> coloniasDM = new List<ColoniaDomainModel>();
            catColonias = coloniaRepository.GetAll(predicado).ToList();

            foreach (CatColonia colonias in catColonias)
            {
                ColoniaDomainModel coloniaDM = new ColoniaDomainModel();
                coloniaDM.IdColonia = colonias.id;
                coloniaDM.StrValor = colonias.strValor;
                coloniaDM.IntCp = colonias.intCp;
                coloniaDM.IdMunicipio = colonias.idMunicipio;
                coloniasDM.Add(coloniaDM);
            }
            return coloniasDM;
        }

        public string GetCodigoPostalByColonia(int idColonia)
        {
            string codigoPostal = string.Empty;
            List<CatColonia> catColonia = null;
            Expression<Func<CatColonia, bool>> predicado = p => p.id.Equals(idColonia);

            List<ColoniaDomainModel> colonias = new List<ColoniaDomainModel>();
            catColonia = coloniaRepository.GetAll(predicado).ToList();

            foreach (CatColonia col in catColonia)
            {
                codigoPostal = col.intCp.ToString();
            }
            
            return codigoPostal;
        }

    }
}
