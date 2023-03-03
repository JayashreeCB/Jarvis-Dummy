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
        
        
        public JarvisController(ILogger<JarvisController> logger , JarvisContext context, IRepository repository)
        {
            _logger = logger;
            _context = context;       
            _repository = repository;
        }
        // GET: api/<JarvisController>
        [HttpGet]
        public ActionResult<IList<GetJarvisInfo>> Get()
        {
            return Ok( _context.getJarvisInfos.ToList<GetJarvisInfo>());
        }

       

        // GET api/<JarvisController>/5
        [HttpGet("{SingpassID}")]
        public async Task<ActionResult<IList<GetJarvisInfo>>> Get(String SingpassID)
        {

            GetJarvisInfo info = _context.getJarvisInfos.FirstOrDefault(a => a.SingpassID == SingpassID);
            await _repository.GetUserStateAsync(SingpassID);            
            return Ok(info);
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
            await _repository.SaveUserStateAsync(info);
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
