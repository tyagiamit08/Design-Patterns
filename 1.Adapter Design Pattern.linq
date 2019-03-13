<Query Kind="Program" />

void Main()
{
	var portal = new ShoppingPortalClient(new Adaptar());
	var products = portal.GetProductsForSale();
	products.ForEach(p=> p.Dump());
}

public interface ITarget{
	List<string> GetProducts();
}

public class Adaptar: ITarget{

	public List<string> GetProducts(){
		var productsFromVendor= new VendorAdaptee().GetProductsFromVendor();
		return productsFromVendor;																																																																																																					
	}
}

public class VendorAdaptee{

	public List<string> GetProductsFromVendor(){
		var products = new List<string>(){
		"Books",
		"Scooter",
		"Bike",
		"Car"
		};	
		
		return products;
	}
}

public class ShoppingPortalClient{

	private ITarget _target;
	
	public ShoppingPortalClient(ITarget target){
		_target =target;
	}
	
	public List<string> GetProductsForSale(){
		return _target.GetProducts();
	}
}