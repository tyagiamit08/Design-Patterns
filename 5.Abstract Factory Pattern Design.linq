<Query Kind="Program" />

void Main()
{
	var ikeaFactory = new ClientClass(new IkeaFactory()); 
	var ikeaChair = ikeaFactory.CreateChair();
	var ikeaSofa = ikeaFactory.CreateSofa();
 	Console.WriteLine(" Testing with the first factory type...");
	Console.WriteLine("------------------------------------------------------------------------------");
 	Console.WriteLine(ikeaChair.printProductDetails());
	Console.WriteLine(ikeaSofa.printProductDetails());
	
	Console.WriteLine("\n***********************************************************************\n");
	
	var modernFactory = new ClientClass(new ModernFactory()); 
	var modernChair = modernFactory.CreateChair();
	var modernSofa = modernFactory.CreateSofa();
	Console.WriteLine(" Testing with the second factory type...");
	Console.WriteLine("------------------------------------------------------------------------------");
	Console.WriteLine(modernChair.printProductDetails());
	Console.WriteLine(modernSofa.printProductDetails());
}

//This Client Class lets you pass any factory
public class ClientClass {
	
	private IAbstractFactory _abstractFactory;
	
	public ClientClass(IAbstractFactory abstractFactory){
		_abstractFactory =abstractFactory;
	}

	public IChair CreateChair(){
		return _abstractFactory.CreateChair();
	}
	
	public ISofa CreateSofa(){
			return _abstractFactory.CreateSofa();
	}
}

// The Abstract Factory interface declares a set of methods that return different abstract products.
//These products are called a family and are related by a high-level theme or concept.

public interface IAbstractFactory{
	IChair CreateChair();
	ISofa CreateSofa();
}

// Concrete Factories produce a family of products that belong to a single variant. 
public class IkeaFactory : IAbstractFactory {

	public IChair CreateChair(){
		return new IkeaChair();
	}
	
	public ISofa CreateSofa(){
		return new IkeaSofa();
	}
}

// Concrete Factories produce a family of products that belong to a single variant. 
public class ModernFactory : IAbstractFactory {

	public IChair CreateChair(){
		return new ModernChair();
	}
	
	public ISofa CreateSofa(){
		return new ModernSofa();
	}
}

// Each distinct product of a product family should have a base interface.
public interface IChair{
	string printProductDetails();
}

// All variants of the product must implement this interface.
public class IkeaChair: IChair {

	public string printProductDetails() {
		return "I am IKEA Chair";
	}
}

public class ModernChair: IChair {

	public string printProductDetails() {
		return "I am a Modern Chair";
	}
}

public interface ISofa{
		string printProductDetails();
}

public class IkeaSofa: ISofa {

	public string printProductDetails() {
		return "I am IKEA Sofa";
	}
}

public class ModernSofa: ISofa {

	public string printProductDetails() {
		return "I am Modern Sofa";
	}
}