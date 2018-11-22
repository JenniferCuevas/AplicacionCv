﻿using AppDigitalCv.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDigitalCv.Business.Interface
{
    public interface IPersonalBusiness
    {
        /// <summary>
        /// obtiene todos los empleados
        /// </summary>
        /// <returns>rfegresa una lista de personal en la capa del modelo de dominio</returns>
        List<PersonalDomainModel> GetEmpleado();
        /// <summary>
        /// agrega o actualiza los datos de una entidad personal
        /// </summary>
        /// <param name="personalDM">recibe un objeto del modelo de dominio</param>
        /// <returns>regresa un mensaje con el resultado de la accion realizada</returns>
        string AddUpdatePersonal(PersonalDomainModel personalDM);
        /// <summary>
        /// este metodo se encarga de consultar a una persona por id
        /// </summary>
        /// <param name="idPersonal">recibe el id del personal a buscar</param>
        /// <returns>regresa una entidad del modelo de dominio</returns>
        PersonalDomainModel GetPersonalById(int idPersonal);
        
        /// <summary>
        ///Este metodo se encarga  de consultar los documentos de un empleado 
        /// </summary>
        /// <returns>regresa una lista de datos de la entidad personal</returns>
        List<PersonalDomainModel> GetEmpleadoDocumentos(int idPersonal);

        /// <summary>
        /// Este metodo se encarga de borrar el curp del personal 
        /// </summary>
        /// <param name="idPersonal">identidficador del personal que se va a eliminar</param>
        /// <returns>una respuesta boolean de confirmación de acción</returns>
        bool DeleteFileCurp(int idPersonal);
        /// <summary>
        /// Este metodo se encargar de consultar los documentos del personal
        /// </summary>
        /// <param name="idPersonal">identificador del personal</param>
        /// <returns>regresa una lista de documentos del personal</returns>
        DocumentoPersonalDomainModel GetDocumentoPersonal(int idPersonal);

        /// <summary>
        /// Este metodo se encarga de borrar el rfc del personal
        /// </summary>
        /// <param name="idPersonal">identificador del personal que se va a eliminar</param>
        /// <returns>regresa una respuesta boolean de confirmación de acción</returns>
        bool DeleteFileRfc(int idPersonal);
    }
}
