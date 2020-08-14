using System.Collections.Generic;
using System.Threading.Tasks;
using CovidInfo.Models;

namespace CovidInfo.Services.Interfaces
{
    public interface ICovidService
    {
        Estado GetStatusEstados();
    }
}