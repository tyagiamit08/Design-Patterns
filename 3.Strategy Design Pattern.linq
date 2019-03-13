<Query Kind="Program" />

void Main()
{
 	Console.WriteLine("Sorting data using the strategy A (not sure how it'll do it)\n");
	var strategy1 = new Strategy(new StrategyA());	
	strategy1.PerformAlgorithm(new List<string>{"1","2","5","3","7"});
	 
	Console.WriteLine("\n**************************************************\n");
	
	Console.WriteLine("Sorting data and then reversing using the strategy B( not sure how it'll do it)\n");
	var strategy2 = new Strategy(new StrategyB());	
	strategy2.PerformAlgorithm(new List<string>{"1","2","5","3","7"});
}
 

public interface IStrategy {
	object  DoAlgorithm(object obj);
}

public class StrategyA:IStrategy{

		public object DoAlgorithm(object obj) {
		
			var listToSort =  obj as List<string>;			
			listToSort.Sort();		
			return listToSort;
		}
}

public class StrategyB:IStrategy{

		public object DoAlgorithm(object obj) {
		
			var listToSortAndReverse =  obj as List<string>;
			listToSortAndReverse.Sort();	
			listToSortAndReverse.Reverse();
			return listToSortAndReverse;
		}
}

//Strategy Class to encapsulate the strategies
public class Strategy{

	private IStrategy _strategy;
	public Strategy(IStrategy chosenStrategy){
		_strategy = chosenStrategy;
	}
	
	public void PerformAlgorithm(object obj){
	
		var result = _strategy.DoAlgorithm(obj);	
		
		foreach (var element in result as List<string>)
        {
             Console.WriteLine(element);
        }
	}
}