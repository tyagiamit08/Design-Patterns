<Query Kind="Program" />

void Main()
{
     var userInput =  Console.ReadLine();
	 var mobileDetails =  MobileFactory.GetMobile(userInput);
	 
	 if(mobileDetails ==null)
	 {
	 	Console.WriteLine("No Such Mobile Found");
	 }
	 else{
	 	mobileDetails.OperatingSystem.Dump();
	    mobileDetails.ModelName().Dump();
	    Console.ReadLine(); 
	 }
}
 
public interface IMobile{
	  string OperatingSystem {get;}
	  string ModelName();
}

public class Samsung: IMobile{

	public string OperatingSystem =>  "Android";
	
	public string ModelName(){
		return "Samsung S90";
	}
}

public class Nokia: IMobile{

	public string OperatingSystem=>  "Symbian";
	
	public string ModelName(){
		return "Nokia 3220";
	}
}

public class Iphone: IMobile{

	public string OperatingSystem=>  "iOS";
	
	public string ModelName(){
		return "IPhone 6S";
	}
}

public static class MobileFactory {

	public static IMobile GetMobile(string mobileType){
		
		if(mobileType =="Samsung")
			return new Samsung();
		else if(mobileType =="Nokia")
			return new Nokia();
		else if(mobileType =="Iphone")
			return new Iphone();
		else
			return null;
	}	
}