namespace TestCSharp.Question2
{
    public class WagonR : Car
    {
        private int mileage;

        public WagonR(int mileage) : base(false, "4")
        {
            this.mileage = mileage;
        }

        public override string getMileage()
        {
            return this.mileage + " kmpl";
        }
    }
}
