using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Events_brachi_fishof.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        public static List<Event> Events = new List<Event>()  {new Event( 1, "do homework", new DateTime(2023, 11, 26), new DateTime(2023, 11, 27) ), new Event(2, "some thing", new DateTime(2023, 12, 26), new DateTime(2023, 12, 27)), new Event(3, "big", new DateTime(2023, 12, 07), new DateTime(2023, 12, 10)) };
        // GET: api/<EventsController>
        [HttpGet]
        public IEnumerable<Event> Get()
        {
            return Events;
        }

        // GET api/<EventsController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            Event ev = Events.Find(e => e.Id == id);
            if (ev == null)
                return NotFound();
            return Ok(ev);
        }

        // POST api/<EventsController>
        [HttpPost]
        public void Post([FromBody] Event @event)
        {
            Events.Add(@event);
        }

        // PUT api/<EventsController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Event @event)
        {
            Event @event1 = Events.Find(e => e.Id == id);
            if (event1 == null)
                return NotFound();
            Events.Remove(event1);
            Events.Add(@event);
            return Ok();
        }

        // DELETE api/<EventsController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            Event @event1 = Events.Find(e => e.Id == id);
            if (event1 == null)
                return NotFound();
            Events.Remove(event1);
            return Ok();
        }
    }
}
