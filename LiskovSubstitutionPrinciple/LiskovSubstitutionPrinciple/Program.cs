namespace LiskovSubstitutionPrinciple
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            IBirdBefore hummingbirdBefore = new HummingBirdBefore();
            hummingbirdBefore.fly();

            IBirdBefore ostrichbirdBefore = new OstrichBefore();
            ostrichbirdBefore.Weight = 200;
            // below line will throw error because Ostrich is bird which is can not fly which means  
            // instances of base class can not be completely substitutable by derived types(LSP violation)
            // ostrichbirdBefore.fly();


            IFlyingBird hummingBird = new HummingBird();
            hummingBird.Weight = 20;
            hummingBird.fly();
             
            IBird ostrichBird = new Ostrich();
            // now we dont have implementation of fly method for ostrich. 
            ostrichBird.Weight = 200;
            Console.Read();
        }
    }

    // LSP states that Base type instances can be completely substitutable by derived types
    // Below implementation violates LSP because Ostrich is type of bird but not actually a bird which can fly.
    // other example could be square is a rectangle but can not code in that way it will violate LSP
    public interface IBirdBefore
    {
        double Weight { get; set; }
        void fly();
    }

    public class HummingBirdBefore : IBirdBefore
    {
        public double Weight { get; set; }

        public void fly()
        {
            Console.WriteLine("Flying");
        }
    }




    public class OstrichBefore : IBirdBefore
    {
        public double Weight { get; set; }

        public void fly()
        {
            throw new NotImplementedException();
        }
    }



    // this implementation follows LSP as ostrich is bird which are not flying.
    // now base class objects can be fully replaced by derived class objects
    public interface IBird
    {
        double Weight { get; set; }
    }
    public interface IFlyingBird : IBird
    {
        void fly();
    }


    public class HummingBird : IFlyingBird
    {
        public double Weight { get; set; }

        public void fly()
        {
            Console.WriteLine("Flying");
        }
    }

    public class Ostrich : IBird
    {
        public double Weight { get; set; }
    }
}
