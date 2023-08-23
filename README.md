# KnapsackProblem

A variant of the Knapsack problem (where the goal is to fill a backpack, with things of different weights, as close as possible to the backpack's maximum capacity), only this would be a grid of squares you walk on, 'picking up' the weights as you walk on them.

You can only walk onto adjacent squares, and you cannot walk on a square you have already walked on.

The maximum capacity of the backpack (the threshold) is 60.

The game finds the optimal path's weight automatically, and you'll be scored by the difference between your highest achieved weight and the optimal path's weight.

This could prove an unconventional pathfinding problem, because the objective is not to take the path of least or most weight, but rather the path with a result closest to, without exceeding, a given limit.

-----

This problem seemed to force a custom algorithm, since it had to account for both the weight of a given path, and look at all viable paths (not just the shortest/cheapest way to get to a given point).

I achieved this by making a modified version of Breadth First Search (the version that stores all paths invidivually, not the more 'optimized' version that only stores each node's 'successor node').

Making the path into a struct allowed storing each individual path's information about the tiles they already 'visited' separate, as well as the cost they have accumulated so far, which breadth first search did not do by default. 

----

Data structures used:

HashSet - To store all visited node for each individual path.

Queue - To store the next node to be visited (part of BFS)

Dictionary - To store each finalized path (a path with no more viable neighbor nodes), together with the cost they achieved (Dictionary<int, Path>). This allows me to know that whichever path has the highest key in the dict is the best path to return.

https://user-images.githubusercontent.com/5792742/222988136-dc527f7c-261f-4b7b-ba31-fcd2fbea8cf2.mp4

----

An application for this sort of problem could be i.e. when packing boxes in a warehouse.


