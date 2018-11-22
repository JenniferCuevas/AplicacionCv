﻿using AppDigitalCv.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDigitalCv.Business.Interface
{
    public interface IAccountBusiness
    {
        /// <summary>
        /// Este metodo se encarga de realizar la validacion del login
        /// </summary>
        /// <param name="AccountDomain">recibe un objeto del tipo account</param>
        /// <returns>regresa un valor boolean</returns>
        bool Login(AccountDomainModel AccountDomain);
        /// <summary>
        /// Este metodo se encarga de realizar una validacion de login
        /// </summary>
        /// <param name="AccountDomain">recibe un objeto del tipo account</param>
        /// <returns>regresa un objeto del tipo accountDomainModel</returns>
        AccountDomainModel ValidarLogin(AccountDomainModel AccountDomain);
    }
}
