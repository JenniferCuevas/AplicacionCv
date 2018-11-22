using AppDigitalCv.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDigitalCv.Business.Interface
{
    public interface IDireccionBussines
    {
        /// <summary>
        /// Este metodo se encarga de obtener la lista de paises
        /// </summary>
        /// <returns> regresa una lista de direcciones con el pais cargado </returns>
        List<PaisDomainModel> GetPais();
        List<EstadoDomainModel> GetEstadoByIdPais(int idPais);
        List<MunicipioDomainModel> GetMunicipioByIdEstado(int idEstado);
        List<ColoniaDomainModel> GetColoniaByMunicipio(int idMunicipio);
        string GetCodigoPostalByColonia(int idColonia);
    }
}
