using System.Collections.Generic;
using System.Threading.Tasks;
using CovidInfo.Models;
using Microsoft.AspNetCore.Mvc;

namespace CovidInfo.Services.Interfaces
{
    public interface ICovidService
    {
        Task<Estado> GetStatusEstado();

        Task<DtoListaEstado> GetEstados();

        Task<DtoListaEstado> GetOlderEstados();
    }
}