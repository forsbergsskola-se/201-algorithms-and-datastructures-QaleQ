List<int> list = new() {
    1, 1, 2, 3, 5
};

IEnumerable<int> listEnum = list; // no idea why we make this
IEnumerator<int> enumerator = list.GetEnumerator();
int sum = 0;

while (enumerator.MoveNext())
{
    Console.WriteLine(enumerator.Current);
    sum += enumerator.Current;
}

Console.WriteLine(sum);

foreach (var num in TurboCollections.TurboMaths.GetEvenNumbers(12)) Console.WriteLine(num);
foreach (var num in TurboCollections.TurboMaths.GetEvenNumbersList(12)) Console.WriteLine(num);
