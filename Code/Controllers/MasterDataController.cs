using LDCWS.BO;
using LDCWS.Service.Interfaces;
using LDCWS.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace LDCWS.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MasterDataController : ControllerBase
    {
        private readonly IMasterData _iMasterData;
        public MasterDataController (IMasterData imasterData)
        {
            this._iMasterData = imasterData;
                
        }

   
        [HttpPost("AddMasterData")]
        public string AddMasterData([FromBody] List<MasterDataViewModel> masterData)
        {
            try
            {



                return _iMasterData.AddMasterData(masterData[1].masterData, masterData[0].userId);
            }
            catch (Exception)
            {

                throw;
            }
        }


        [HttpGet("getAllMasterData")]
        public List<MasterData> getAllMasterData()
        {
            return _iMasterData.GetMasterDataforDisplay();
        }

        [HttpGet("getAllMasterDataArchive")]
        public List<MasterDataCompleteList> getAllArchiveMasterData()
        {
            return _iMasterData.GetMasterDataArchieveforDisplay();
        }

        [HttpGet("getAllGridBlock")]
        public List<gridBlock> GetGridBlocks()
        {
            return _iMasterData.getGridBlock();
        }

        [HttpPost("getGroup")]
        public List<getGroup> getGroup([FromBody] GridBlock gridblock)
        {
            return _iMasterData.getGroup(gridblock.getGridBlock);
        }

        [HttpPost("getCategory")]
        public List<getCategory> getCategory([FromBody] GridBlock gridblock)
        {
            return _iMasterData.getCategory(gridblock.getGridBlock, gridblock.getGroup);
        }

        [HttpPost("updateMasterData")]
        public bool updateMasterData([FromBody] MasterDataViewModel masterData)

        {
            //var _bearer_token = Request.Headers[HeaderNames.Authorization].ToString().Replace("Bearer ", "");
            //var token = new JwtSecurityToken(jwtEncodedString: _bearer_token);
            //var userID = token.Claims.First(c => c.Type == "Email").Value;
            return _iMasterData.updateMasterData(masterData.masterData[0], masterData.userId,masterData.MasterDataSNO );
        }

        [HttpPost("DeleteMasterData")]
        public string DeleteMasterData([FromBody] MasterDataViewModel masterData)

        {
            //var _bearer_token = Request.Headers[HeaderNames.Authorization].ToString().Replace("Bearer ", "");
            //var token = new JwtSecurityToken(jwtEncodedString: _bearer_token);
            //var userID = token.Claims.First(c => c.Type == "Email").Value;
            return _iMasterData.DeleteMasterData(masterData.masterData[0], masterData.userId);
        }

        [HttpPost("InsertMasterData")]
        public string InsertMasterData([FromBody] MasterDataViewModel masterData)
        {
            try
            {



                return _iMasterData.InsertMasterData(masterData.masterData, masterData.userId);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
