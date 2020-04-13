namespace ContactMap3.Models
{
    public class Address
    {
        public string Number { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Postal { get; set; }
        public string Country { get; set; }

        public override string ToString()
        {
            return $"{this.Number} " +
                    $"{this.Street} " +
                    $"{this.City} " +
                    $"{this.State} " +
                    $"{this.Postal} " +
                    $"{this.Country}";
        }
    }
}
