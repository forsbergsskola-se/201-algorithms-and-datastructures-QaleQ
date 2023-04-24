using System.Collections;

List<int> numbers = new() {
    137,
    1000,
    -200
};
for (var i = 0; i < numbers.Count; i++) Console.WriteLine(numbers[i]);

ArrayList list = new() {
    true,
    "Forsbergs",
    'a',
    1000,
    .12f
};

for (var i = 0; i < list.Count; i++) Console.WriteLine(list[i]);