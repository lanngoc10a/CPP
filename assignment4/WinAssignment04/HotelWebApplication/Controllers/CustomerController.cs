using DBAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HotelWebApplication.Models;

namespace HotelWebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {

       
        public IEnumerable<HotelRoom> Get()
        {

            using (masterEntities dx = new masterEntities())
            {
                return dx.HotelRoom.ToList();
                
            }
        }
    }
}
