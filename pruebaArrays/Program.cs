//using pruebaArrays.prueba1.Menu;
//using pruebaArrays.prueba3.logica;
//using pruebaArrays.prueba4.Menu;

//namespace pruebaArrays
//{
//    internal class Program
//    {
//        static void Main(string[] args)
//        {
//            //MenuTer menu = new MenuTer();
//            //menu.menuInporta();
//            //MenuImpl menu = new MenuImpl();
//            //menu.presentarM();

//            //Menu03 menu = new Menu03();
//            //menu.mostrarMenu();
//            //MostrarMenu menu = new MostrarMenu();
//            //menu.implementaMenu();

//            Console.ReadKey();
//        }


//    }
//}



//var sale = new Sale(17);



//class Sale { 
//    public decimal total {  get; set; }

//    public Sale(decimal total) {
//        total = total;
//    } 

//    public virtual string GetInfo(){
//        return "total es: " + total;
//    }
//}


//// herencia 
//class SaleWithTax : Sale
//{
//    public decimal Tax { get; set; }
//    public SaleWithTax(decimal total, decimal tax) : base(total)
//    {
//        Tax = tax;
//    }

//    public override string GetInfo() {
//        return "El total con tax es: " + total;
//    }


//}

public interface ISale { 
    public decimal total { get; set; }
}

public interface ISave {
    public void Save() { }
}

public class Sale : ISale, ISave 
{
    public decimal total { get; set; }

}
