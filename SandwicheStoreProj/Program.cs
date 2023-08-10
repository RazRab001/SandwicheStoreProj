namespace SandwicheStoreProj
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FirstKitchenApp first = new FirstKitchenApp();
            Ingridient i1 = Ingridient.Create(first, "Mustard");
            Bread bread1 = Bread.Create(first, "Black bread");
            first.addBreadToSandvich("White bread");
            first.addIngridientToSandvich("Salami");
            first.addIngridientToSandvich("Salad");
            first.addIngridientToSandvich("Garlic souse");
            first.createNewSandvich("Simple");


            foreach (var bread in first.sandviches.GetCatalog())
            {
                Console.WriteLine(bread);
            }

        }
    }
}