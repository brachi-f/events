namespace Events_brachi_fishof
{
    public class Event
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public Event(int id,string title,DateTime start,DateTime end)
        {
            Id = id;
            Title = title;
            Start = start;
            End = end;
        }
        public override bool Equals(object? obj)
        {
            Event o = obj as Event;
            return this.Id==o.Id&&DateTime.Equals(this.Start,o.Start)&&DateTime.Equals(o.End,this.End)&&String.Equals(o.Title,this.Title);
        }
    }
}
