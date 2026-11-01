using HotelListing.API.Data;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HotelListing.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private static List<Hotel> hotels = new List<Hotel>
        {
            new Hotel { Id = 1,Name="Grand Plaza",Adress="123 main str",Rating=4.5 },
            new Hotel { Id = 2,Name="Ocean View",Adress="857 main str",Rating=2.11 },
        };
        // GET: api/<HotelController>
        [HttpGet]
        public ActionResult<List<Hotel>> Get()
        {
            return Ok(hotels);
        }

        // GET api/<HotelController>/5
        [HttpGet("{id}")]
        public ActionResult<Hotel> Get(int id)
        {
            var hotel = hotels.FirstOrDefault(h => h.Id == id);
            if (hotel == null)
            {
                return NotFound();
            }
            return Ok(hotel);
        }

        // POST api/<HotelController>
        [HttpPost]
        public ActionResult<Hotel> Post([FromBody] Hotel newHotel)
        {
            if (hotels.Any(h => h.Id == newHotel.Id))
            {
                return BadRequest("Hotel with this id already exisit");
            }
            hotels.Add(newHotel);
            return CreatedAtAction(nameof(Get), new {id = newHotel.Id},newHotel);
                
        }

        // PUT api/<HotelController>/5
        [HttpPut("{id}")]
        public ActionResult<Hotel> Put(int id, [FromBody] Hotel updateHotel)
        {
            var exisitingHotel = hotels.FirstOrDefault(h=>h.Id == id);
            if(exisitingHotel == null)
            {
                return NotFound("hotel from id is not exisit");
            }
            exisitingHotel.Name = updateHotel.Name;
            exisitingHotel.Adress = updateHotel.Adress;
            exisitingHotel.Rating = updateHotel.Rating;
            return NoContent();
        }

        // DELETE api/<HotelController>/5
        [HttpDelete("{id}")]
        public ActionResult<Hotel> Delete(int id)
        {
            var exisitingHotel = hotels.FirstOrDefault(h => h.Id == id);
            if (exisitingHotel == null)
            {
                return NotFound("hotel from id is not exisit");
            }
            hotels.Remove(exisitingHotel);
            return NoContent();
        }
    }
}
