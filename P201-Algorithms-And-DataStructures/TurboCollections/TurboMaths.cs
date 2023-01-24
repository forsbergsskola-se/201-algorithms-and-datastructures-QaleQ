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
        for (int i = 0; i < maxNumber + 1; i += 2)
            yield return i;
    }

    public static float Average(float[] array)
    {
        float sum = 0;
        foreach (float num in array) sum += num;
        return sum / array.Length;
    }

    public static int FibonacciRecursive(int n)
    {
        if (n == 0) return 0;
        if (n == 1) return 1;
        return FibonacciRecursive(n - 1) + FibonacciRecursive(n - 2);
    }
    
    public static int FibonacciIterative(int n)
    {
        if (n == 0) return 0;
        if (n == 1) return 1;
        
        int previous = 0;
        int current = 1;
        int next = 0;
        for (int i = 0; i < n - 1; i++)
        {
            next = current + previous;
            previous = current;
            current = next;
        }
        return next;
    }
    
}