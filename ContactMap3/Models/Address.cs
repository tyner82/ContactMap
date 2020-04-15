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
        public Address() { }
        public Address(string number, string street, string city, string state, string postal, string country)
        {
            Number = number;
            Street = street;
            City = city;
            State = state;
            Postal = postal;
            Country = country;
        }

        public override string ToString()
        {
            return $"{this.Number} "+
                $"{this.Street} \n" +
                $"{this.City} \n" +
                $"{this.State}, " +
                $"{this.Country}";
        }
    }
}
