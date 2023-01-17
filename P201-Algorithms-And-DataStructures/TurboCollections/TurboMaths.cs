namespace TurboCollections;

public static class TurboMaths
{
    public static void SayHello() => Console.WriteLine($"Hello, I'm {typeof(TurboMaths)}");
    
    public static List<int> GetEvenNumbersList(int maxNumber)
    {
        List<int> returnValue = new();
        if (maxNumber < 0) return returnValue;
        
        for (int i = 0; i < maxNumber + 1; i += 2)
            returnValue.Add(i);
        
        return returnValue;
    }

    public static IEnumerable<int> GetEvenNumbers(int maxNumber)
    {
        for (int i = 0; i < maxNumber + 1; i += 2) yield return i;
    }
}