namespace TestCSharp.Question2
{
    public class HondaCity : Car
    {
        private int mileage;

        public HondaCity(int mileage) : base(true, "4")
        {
            this.mileage = mileage;
        }

        public override string getMileage()
        {
            return this.mileage + " kmpl";
        }
    }
}
