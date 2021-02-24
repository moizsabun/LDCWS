using LDCWS.BO;
using LDCWS.Service.Interfaces;
using LDCWS.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LDCWS.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class LoadShediingController : ControllerBase
    {
        private readonly ILoadSheding _LS;

        public LoadShediingController(ILoadSheding ls)
        {
            this._LS = ls;
        }





        // GET: api/<LoadShediingController>
        [HttpGet("GetLoadSheddings")]
        public List<LoadShedding> GetLoadSheddings()
        {
           return _LS.getAllLoadSheddingData();
        }

        [HttpPost("addLoadSheddding")]
        public string addLoadSheddding(InsertLS ls)
        {
            return _LS.addLoadsheddindgData(ls.ls , ls.userid);
        }

        [HttpPost("editExpiry")]
        public string sEditExpiry(InsertExpiry expiry)
        {
            string dateTime = expiry.dateTime.ToShortDateString();

            return _LS.editExpiry(expiry.dateTime, expiry.userid);
        }

        [HttpPost("editLoadShedding")]
        public string editLoadShedding(InsertLS ls)
        {
           
            return _LS.EditLoadsheddindgData(ls.ls, ls.userid);
        }

        [HttpGet("GetLSDataArchieveforDisplay")]
        public List<LoadSheddingCompleteList> GetLSDataArchieveforDisplay()
        {
            return _LS.GetLSDataArchieveforDisplay();
        }
    }
}
