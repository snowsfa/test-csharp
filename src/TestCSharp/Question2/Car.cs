namespace TestCSharp.Question2
{
    public abstract class Car
    {
        private bool isSedan;
        private string seats;

        public bool getIsSedan()
        {
            return this.isSedan;
        }

        public string getSeats()
        {
            return this.seats;
        }

        protected Car(bool isSedan, string seats)
        {
            this.isSedan = isSedan;
            this.seats = seats;
        }

        public abstract string getMileage();
    }
}
