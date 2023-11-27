using Events_brachi_fishof;
using Events_brachi_fishof.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace UnitTests
{
    public class EventsControllerTest
    {
        [Fact]
        public void Get_NotNull()
        {
            var controller = new EventsController();
            var result = controller.Get();
           Assert.NotNull(result);
        }
        [Fact]
        public void GetById_ReturnOk()
        {
            var controller = new EventsController();
            var id = 1;
            var result = controller.Get(id);
            Assert.IsType<OkObjectResult>(result);
        }
        [Fact]
        public void GetById_ReturnNotFound()
        {
            var controller = new EventsController();
            var result = controller.Get(99);
            Assert.IsType<NotFoundResult>(result);
        }
        [Fact]
        public void Post_Post()
        {
            var controller = new EventsController();
            Event event1 = new Event(7, "test", DateTime.Now, DateTime.Now);
            controller.Post(event1);
            var event2 = EventsController.Events.Find(e => e.Equals(event1));
            Assert.NotNull(event2);
        }
        [Fact]
        public void Put_Delete()
        {
            var controller = new EventsController();
            Event event1 = EventsController.Events.First();
            var id = event1.Id;
            Event event2 =new Event(id,event1.Title+"+change",event1.Start,event1.End);
            controller.Put(id, event2);
            var result = EventsController.Events.Find(e => e.Equals(event1));
            Assert.Null(result);
        }
        [Fact]
        public void Put_Post()
        {
            var controller = new EventsController();
            Event event1 = EventsController.Events.First();
            var id = event1.Id;
            Event event2 =new Event(id,event1.Title+"+change",event1.Start,event1.End);
            controller.Put(id, event2);
            var result = EventsController.Events.Find(e => e.Equals(event2));
            Assert.NotNull(result);
        }
        [Fact]
        public void Put_ReturnNotFound()
        {
            var controller = new EventsController();
            var id = 99;
            Event @event = new Event(id, "nothing", DateTime.Now, DateTime.Now);
            var result = controller.Put(id, @event);
            Assert.IsType<NotFoundResult>(result);
        }
        [Fact]
        public void Put_ReturnOk()
        {
            var controller = new EventsController();
            Event @event = EventsController.Events.First();
            var id = @event.Id;
            @event.Title = "change";
            var result = controller.Put(id, @event);
            Assert.IsType<OkResult>(result);
        }
        [Fact]
        public void Delete_ReturnNotFound()
        {
            var controller = new EventsController();
            var id = 99;
            var result = controller.Delete(id);
            Assert.IsType<NotFoundResult>(result);
        }
        [Fact]
        public void Delete_ReturnOk()
        {
            var controller = new EventsController();
            var id = 2;
            var result = controller.Delete(id);
            Assert.IsType<OkResult>(result);
        }
        [Fact]
        public void Delete_()
        {
            var controller = new EventsController();
            Event @event = EventsController.Events.First();
            var id = @event.Id;
            controller.Delete(id);
            @event = EventsController.Events.Find(e => e.Id == id);
            Assert.Null(@event);

        }
    }
}