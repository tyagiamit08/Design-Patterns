<Query Kind="Program" />

void Main()
{
	var hero =  new VehicleCreator(new HeroBuilder());
	hero.CreateVehicle();
	hero.GetVehicle().Dump();
	
	Console.WriteLine("-----------------------------------------------");
	
	var honda =  new VehicleCreator(new HondaBuilder());
	honda.CreateVehicle();
	honda.GetVehicle().Dump();
}

//Product Class
public class Vehicle {
	public string Model {get;set;}
	public string Engine {get;set;}
	public string Transmission {get;set;}
	public string Body {get;set;}
}

//Builder Interface
public interface IVehicleBuilder {
	void SetModel();
	void SetEngine();
	void SetTransmission();
	void SetBody();
	
	Vehicle GetVehicle();
}

//Concrete Builder Class
public class HeroBuilder: IVehicleBuilder {

	Vehicle	heroVehicle =  new Vehicle();
	
	public void SetModel() {
		heroVehicle.Model="Hero";
	}
	
	public void SetEngine() {
		heroVehicle.Engine="4 Stroke";
	}

	public void SetTransmission() {
		heroVehicle.Transmission="Manual";	
	}
	
	public void SetBody() {
		heroVehicle.Body="Steel";
	}

	public Vehicle GetVehicle() {
		return heroVehicle;
	}
}

//Concrete Builder Class
public class HondaBuilder: IVehicleBuilder {

	Vehicle	hondaVehicle =  new Vehicle();
	
	public void SetModel() {
		hondaVehicle.Model="Honda";
	}
	
	public void SetEngine() {
		hondaVehicle.Engine="2 Stroke";
	}

	public void SetTransmission() {
		hondaVehicle.Transmission="Automatic";	
	}
	
	public void SetBody() {
		hondaVehicle.Body="Plastic";
	}

	public Vehicle GetVehicle() {
		return hondaVehicle;
	}
}

//Director Class
public class VehicleCreator {
	
	private IVehicleBuilder _vehicleBuilder;
	
	public VehicleCreator(IVehicleBuilder vehicleBuilder){
		_vehicleBuilder = vehicleBuilder;
	}
	
	public void CreateVehicle(){
		_vehicleBuilder.SetModel();
		_vehicleBuilder.SetEngine();
		_vehicleBuilder.SetTransmission();
		_vehicleBuilder.SetBody();
	}

	public Vehicle GetVehicle(){
		return _vehicleBuilder.GetVehicle();
	}
}