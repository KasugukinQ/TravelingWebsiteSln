using System.Text.Json.Serialization;
using TravelingWebsite.Infrastructure;

namespace TravelingWebsite.Models
{
    public class SessionBooking : Booking
    {
        public static Booking GetBooking(IServiceProvider services) 
        {
            ISession? session = services
                .GetRequiredService<IHttpContextAccessor>()
                .HttpContext?.Session;
            SessionBooking Booking = session?.GetJson<SessionBooking>("Booking")
                ?? new SessionBooking();
            Booking.Session = session;
            return Booking;
        }

        [JsonIgnore]
        public ISession? Session { get; set; }

        public override void AddItem(Package package, int quantity) 
        {
            base.AddItem(package, quantity);
            Session?.SetJson("Booking", this);
        }

        public override void RemoveLine(Package package) 
        {
            base.RemoveLine(package);
            Session?.SetJson("Booking", this);
        }

        public override void Clear()
        {
            base.Clear();
            Session?.Remove("Booking");
        }
    }
}
