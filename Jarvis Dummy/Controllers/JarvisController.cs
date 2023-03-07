using Dapr.Client;
using Jarvis_Dummy.Context;
using Jarvis_Dummy.Model;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Metrics;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Jarvis_Dummy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JarvisController : ControllerBase
    {
        private ILogger<JarvisController> _logger;
        private JarvisContext _context;
        private readonly IRepository _repository;


        public JarvisController(ILogger<JarvisController> logger, JarvisContext context, IRepository repository)
        {
            _logger = logger;
            _context = context;
            _repository = repository;
        }
        // GET: api/<JarvisController>
        [HttpGet("[action]")]       
        [ActionName("GetJarvisUserInfo")]
        public ActionResult<IList<GetJarvisInfo>> Get()
        {
            return Ok(_context.getJarvisInfos.ToList<GetJarvisInfo>());
        }

        // GET api/<JarvisController>/5
        [HttpGet("[action]/{SingpassID}")]
        [ActionName("UserInfoBySingpassID")]
        public async Task<ActionResult<IList<GetJarvisInfo>>> Get(String SingpassID)
        {

            GetJarvisInfo info = _context.getJarvisInfos.FirstOrDefault(a => a.SingpassID == SingpassID);
            await _repository.GetUserStateAsync(SingpassID);
            return Ok(info);
        }

        [HttpGet("[action]/{Postalcode}")]
        [ActionName("GetAddress")]
        public async Task<ActionResult<Getaddress>> GetAddress(int Postalcode)
        {
            if (Postalcode == 0)
            {
                return BadRequest();
            }
            Getaddress address = new Getaddress();
                var  info = _context.getJarvisInfos.FirstOrDefault(a => a.BBA_PostalCode == Postalcode);
            if (info != null)
            {

                address.PostalCode = info.BBA_PostalCode;
                address.Country = info.BBA_Country;
                address.BlockNumber = info.BBA_BlockNumber;
                address.BuildingName = info.BBA_BuildingName;
                address.LevelNumber = info.BBA_LevelNumber;
                address.StreetName = info.BBA_StreetName;
                address.UnitNumber = info.BBA_UnitNumber;
                              
            }
            var info1 = _context.getJarvisInfos.FirstOrDefault(a => a.BMA_PostalCode == Postalcode);
            if (info1 != null)
            {
                address.PostalCode = info1.BMA_PostalCode;
                address.Country = info1.BMA_Country;
                address.BlockNumber = info1.BMA_BlockNumber;
                address.BuildingName = info1.BMA_BuildingName;
                address.LevelNumber = info1.BMA_LevelNumber;
                address.StreetName = info1.BMA_StreetName;
                address.UnitNumber = info1.BMA_UnitNumber;
            }
           if (info == null && info1 == null) { 
                return NotFound();
            }
            return Ok(address);

        }

        // POST api/<JarvisController>
        [HttpPost]
        public async Task< ActionResult<IList<GetJarvisInfo>>> Post()
        {
            GetJarvisInfo info = new GetJarvisInfo
            {
                UEN = "196900049H",
                BusinessName = "Makino Asia Pvt Ltd",
                BusinessRegisteredAddress = "48 Pandan Road, Singapore 602289",
                LegalEntity = "Local Company",
                

                BBA_PostalCode = 123456,
                BBA_Country = "Singapore",
                BBA_BlockNumber = 1,
                BBA_BuildingName = "Poh Tiong Logistics",
                BBA_LevelNumber = 2,
                BBA_StreetName = "Pandan Road",
                BBA_UnitNumber = 3,

                BMA_PostalCode = 234567,
                BMA_Country = "Singapore",
                BMA_BlockNumber = 4,
                BMA_BuildingName = "Hop Giong LTD",
                BMA_LevelNumber = 2,
                BMA_StreetName = "Pandon Road",
                BMA_UnitNumber = 3,

                SingpassID = "1234567",
                FirstName = "James",
                LastName = "Lee",
                Salutation = "Mr",
                Designation = "Admin",
                OfficeNumber = "6123455671",
                MobileNumber = "6123456789",
                Email = "abc@gmail.com",
                EmailNotification = false,
                SMSNotification = true


            };
            
            _context.getJarvisInfos.Add(info);
            _context.SaveChanges();
           // await _repository.SaveUserStateAsync(info);
            return Ok(_context.getJarvisInfos.ToList<GetJarvisInfo>());
        }

        // PUT api/<JarvisController>/5
        [HttpPut]
        public ActionResult<string> Put( [FromBody] GetJarvisInfo jarvisInfo)
        {
            _context.getJarvisInfos.Update(jarvisInfo);
            _context.SaveChanges();
            return Ok("Saved Successfully");
        }

        // DELETE api/<JarvisController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
