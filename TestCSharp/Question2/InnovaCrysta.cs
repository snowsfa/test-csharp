namespace TestCSharp.Question2
{
    public class InnovaCrysta : Car
    {
        private int mileage;

        public InnovaCrysta(int mileage) : base(false, "6")
        {
            this.mileage = mileage;
        }

        public override string getMileage()
        {
            return this.mileage + " kmpl";
        }
    }
}
