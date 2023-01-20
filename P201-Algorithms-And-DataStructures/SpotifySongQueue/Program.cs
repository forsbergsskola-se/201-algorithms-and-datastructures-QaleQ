using TurboCollections;

var tlq = new TurboLinkedQueue<string>();
while (true) {
    Console.WriteLine("What would you like to do? [s]kip or [a]dd?");
    var input = Console.ReadKey().Key;
    Console.WriteLine();
    if (input == ConsoleKey.A) {
        Console.WriteLine("Enter the Song's Name");
        tlq.Enqueue(Console.ReadLine());
    }
    else if (input == ConsoleKey.S)
        Console.WriteLine(tlq.Count == 0 ? "There is no more songs in the Queue." : $"Now Playing: {tlq.Dequeue()}");
}