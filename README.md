A variant of the Knapsack problem (where the goal is to fill a backpack, with things of different weights, as close as possible to the backpack's maximum capacity), only this would be a grid of squares you walk on, 'picking up' the weights as you walk on them.

The tiles of the grid can only be walked on once per game.

You can only walk onto adjacent squares, and you cannot walk on a square you have already walked on.

The maximum capacity of the backpack (the threshold) is 60.

The game finds the optimal path's weight automatically, and you'll be scored by the difference between your highest achieved weight and the optimal path's weight.

This could prove a unconventional pathfinding problem, because the objective is not to take the path of least or most weight, but rather the path with a result closest to, without exceeding, a given limit.

Since no path (that does not lead directly to the threshold) can be excluded before all viable paths have been explored, this seems to force a custom algorithm, since it would have to account for weight, store viable paths unless the target can be reached

-----

This problem seems to force a custom algorithm, since it would both have to account for the weight of a given path, and look at all viable paths (not just the shortest/cheapest way to get to a given point).

Making the path into a struct allowed storing each individual path's information about the tiles they already 'visited' separate, which breadth first search did not do.  

An application for this sort of problem could be i.e. when packing boxes in a warehouse.

https://user-images.githubusercontent.com/5792742/222988136-dc527f7c-261f-4b7b-ba31-fcd2fbea8cf2.mp4

