namespace TravelingWebsite.Models
{
    public class Booking
    {
        public List<BookingLine> Lines { get; set; } = new List<BookingLine>();

        public virtual void AddItem(Package package, int quantity)
        {
            BookingLine? line = Lines
                .Where(p => p.Package.PackageID == package.PackageID)
                .FirstOrDefault();

            if (line == null)
            {
                Lines.Add(new BookingLine
                {
                    Package = package,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        public virtual void RemoveLine(Package package) =>
            Lines.RemoveAll(l => l.Package.PackageID
                == package.PackageID);

        public decimal ComputeTotalValue() =>
            Lines.Sum(e => e.Package.Price * e.Quantity);

        public virtual void Clear() => Lines.Clear();
        
    }

    public class BookingLine
    {
        public int BookingLineID { get; set; }
        public Package Package { get; set; } = new();
        public int Quantity { get; set; }
    }
}
