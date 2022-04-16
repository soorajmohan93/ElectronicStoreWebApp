using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElectronicStoreModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ElectronicStoreAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CalculationAPIController : ControllerBase
    {
        [HttpGet("{Price},{Quantity}")]
        public decimal GetTotalPrice(decimal Price, int Quantity)
        {
           return Calculations.TotalPrice(Price, Quantity);
        }

        [HttpGet("{TotalQuantity},{QuantitySelected}")]
        public int GetRemainingQuantity(int TotalQuantity, int QuantitySelected)
        {
            return Calculations.RemainingQuantity(TotalQuantity, QuantitySelected);
        }
    }
}