<Query Kind="Program" />

void Main()
{
	var cakeBase =  new CakeBase();
	Console.WriteLine("Base of Cake before decoration costs Rs."+cakeBase.GetPrice());
	
	var cakeDecoratedWithCream =  new CreamDecorator(cakeBase);
	Console.WriteLine(cakeDecoratedWithCream.GetName()+" with Decoration Cost "+cakeDecoratedWithCream.GetDecorationCost());
	Console.WriteLine("Base of Cake after cream decoration costs Rs."+cakeDecoratedWithCream.GetPrice());
	
	Console.WriteLine("--------------------------------------------------------------------");

	var cakeDecoratedWithCreamAndCherry =  new CherryDecorator(cakeDecoratedWithCream);
	Console.WriteLine(cakeDecoratedWithCreamAndCherry.GetName()+" with Decoration Cost "+cakeDecoratedWithCreamAndCherry.GetDecorationCost());
	Console.WriteLine("Cake with cream after cherry decoration costs Rs."+cakeDecoratedWithCreamAndCherry.GetPrice());
	
	
	Console.WriteLine("--------------------------------------------------------------------");
	
	var cakeDecoratedWithCreamCherryAndScent =  new ScentDecorator(cakeDecoratedWithCreamAndCherry);
	Console.WriteLine(cakeDecoratedWithCreamCherryAndScent.GetName()+" with Decoration Cost "+cakeDecoratedWithCreamCherryAndScent.GetDecorationCost());
	Console.WriteLine("Cake with cream and cherry after scent decoration costs Rs."+cakeDecoratedWithCreamCherryAndScent.GetPrice());
}

public abstract class BakeryItem {
	public abstract string GetName();
	public abstract int GetPrice();
}

public class CakeBase : BakeryItem {
	
	private string name= "Base Of Cake";
	private int price= 100;
	
	public override string GetName() {
		return name;
	}
	
	public override int GetPrice() {
		return price;
	}
}

public abstract class Decorator : BakeryItem {
	
	private BakeryItem _bakeryItem;
	protected string decoratorName= "";
	protected int decoratorAdditionalPrice= 0;
	
	public Decorator (BakeryItem bakeryItem){
		_bakeryItem = bakeryItem;
	}
	
	public override string GetName() {
		return  " DECORATOR :["+decoratorName+"]";
	}
	
	public override int GetPrice() {
		return  _bakeryItem.GetPrice() + decoratorAdditionalPrice;
	}
	
	public abstract int GetDecorationCost();
	
}

//Decorators
public class CreamDecorator : Decorator {

	public CreamDecorator(BakeryItem bakeryItem): base (bakeryItem){
		decoratorName="Cream Decorator";
		decoratorAdditionalPrice=25;
	}
	
	public override int GetDecorationCost(){
		return decoratorAdditionalPrice;
	}
}

//Decorators
public class CherryDecorator : Decorator {

	public CherryDecorator(BakeryItem bakeryItem): base (bakeryItem){
		decoratorName="Cherry Decorator";
		decoratorAdditionalPrice=40;
	}
	
	public override int GetDecorationCost(){
		return decoratorAdditionalPrice;
	}
}

//Decorators
public class ScentDecorator : Decorator {

	public ScentDecorator(BakeryItem bakeryItem): base (bakeryItem){
		decoratorName="Scent Decorator";
		decoratorAdditionalPrice=400;
	}
	
	public override int GetDecorationCost(){
		return decoratorAdditionalPrice;
	}
}
