<Query Kind="Program" />

void Main()
{
	var subject  = new Subject();
	
	var observerA =  new Observer("Observer A");
	var observerB =  new Observer("Observer B");
	var observerC =  new Observer("Observer C");
	
	Console.WriteLine("Intially items in inventory "+subject.Inventory+"\n");

	subject.Subscribe(observerA);
	subject.Subscribe(observerB);
	subject.Inventory++;
	
	Console.WriteLine("------------------------------------------------------------------------\n");
	
	subject.Subscribe(observerC);
	subject.UnSubscribe(observerB);
	subject.Inventory++;
} 

public interface IObserver {
	void Update();
}

public class Observer : IObserver {
	
	public string ObserverName;
	
	public Observer(string name){
		ObserverName = name;
	}
	
	public void Update(){
		Console.WriteLine("Hello "+ObserverName + ", a new product has been arrived at the store.");
	}
}

public interface ISubject {
	void Subscribe(Observer observer);
	void UnSubscribe(Observer observer);
	void Notify();
}

public class Subject: ISubject {
	
	private List<Observer> Observers = new List<Observer>();
	private int itemsCount;
	
	public int Inventory {
		get { return itemsCount;}
		set {
			if(value > itemsCount)
			{
				itemsCount++;
				Console.WriteLine("Now Items in inventory are "+itemsCount);
				Notify();
			}
		}
	}

	public 	void Subscribe(Observer observer){
		Observers.Add(observer);
	}
	
	public void UnSubscribe(Observer observer){
		Observers.Remove(observer);
	}
	
	public void Notify(){
		foreach(var observer in Observers){
			observer.Update();
		}
	}
}