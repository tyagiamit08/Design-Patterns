<Query Kind="Program" />

void Main()
{
	var facadeForClient =  new Facade();
	//Client calling System 1 methods A and B though system 1 has method A2
	//as well but it is not visible to the client
	facadeForClient.PerformOperationA();
	facadeForClient.PerformOperationB();
	
	Console.WriteLine("----------------------------------------------------------------");
	
	//Client calling System 2 methods C and D though system 2 has method D2
	//as well but it is not visible to the client
	facadeForClient.PerformOperationC();
	facadeForClient.PerformOperationD();
} 

public class Facade {

	private ISystem1 _system1;
	private ISystem2 _system2;
	
	public Facade(){
		_system1 =  new System1();	
		_system2 =  new System2();
	}
	
	public void PerformOperationA(){
		_system1.PerformOperationA();
	}
	
	public void PerformOperationB(){
		_system1.PerformOperationB();
	}
	
	public void PerformOperationC(){
		_system2.PerformOperationC();
	}
	
	public void PerformOperationD(){
		_system2.PerformOperationD();
	}
}

public interface ISystem1 {
	void PerformOperationA();
	void PerformOperationB();	
}

public class System1: ISystem1 {
	public void PerformOperationA() {
		Console.WriteLine("Performing operation A from System 1");
		PerformOperationA2();
	}
	
	public void PerformOperationB() {
		Console.WriteLine("Performing operation B from System 1");
	}
	
	private void PerformOperationA2() {
		Console.WriteLine("Performing operation A2 from System 1");
	}
}

public interface ISystem2 {
	void PerformOperationC();
	void PerformOperationD();
}

public class System2 : ISystem2 {

	public void PerformOperationC() {
		Console.WriteLine("Performing operation C from System 2");
	}
	
	public void PerformOperationD() {
		Console.WriteLine("Performing operation D from System 2");
 		PerformOperationD2();
	}
	
	private void PerformOperationD2() {
		Console.WriteLine("Performing operation D2 from System 2");
	}
}