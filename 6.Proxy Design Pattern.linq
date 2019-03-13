<Query Kind="Program" />

void Main()
{
	var experiencedServer =   new ExperiencedServer("Pizzaa");
	experiencedServer.TakeOrder();
	Console.WriteLine("Order "+experiencedServer.DeliverOrder()+" Delivered");
	experiencedServer.ProcessPayment();
	
	Console.WriteLine("-----------------------------------------------------------------");
	
	var traineeServer =   new TraineeServer("Pasta");
	traineeServer.TakeOrder();
	Console.WriteLine("Order "+traineeServer.DeliverOrder()+" Delivered");
	traineeServer.ProcessPayment();
}

 
public interface IServer{
	void TakeOrder();
	string DeliverOrder();
	void ProcessPayment();
}

public class ExperiencedServer : IServer {

	private string Order;
	
	public ExperiencedServer(string order){
		Order = order;
	}
	
	public void TakeOrder(){
		Console.WriteLine("Experienced Server is taking order of "+ Order +" for the client");
	}
	
	public string DeliverOrder(){
		return Order;
	}
	
	public void ProcessPayment(){
		Console.WriteLine("Processed payment for order of "+ Order);
	}
}

public class TraineeServer : IServer {

	private string Order;
	
	public TraineeServer(string order){
		Order = order;
	}
	
	public void TakeOrder(){
		Console.WriteLine("Trainee Server is taking order of "+ Order +" for the client");
	}
	
	public string DeliverOrder(){
		return Order;
	}
	
	public void ProcessPayment(){
		Console.WriteLine("Processing payment started by the trainee server");
		new ExperiencedServer(Order).ProcessPayment();
	}
}