# Algorithms Advanced
All the various types of algorithms that are studied in this course will be described below in detail, with examples in C#!

# 1. Dijkstra's Algorithm

How the algorithm works:   
   Dijkstra's Algorithm is used, mostly, to find the shortets path in a weighted graph. In the example below the shortest path to node (1) is: 
(3) -> (1). Meaning the total cost (sum of all edge weights) is equal to 10. However, if we take the oppsite path, through node 2: (3) -> (2) -> (1), we can clearly see that the cost in this case is equal to 12, which is greater than 10.

  <p align="center">
     <img width="300" height="300" src="https://github.com/deyordanov/Softuni-Exercises/assets/122925849/151a170d-705f-4e6f-bfba-91178ec1f52e"/>
   </p>  

The implementation of Dijkstra's Algorithm isn't complicated and it is rather easy to understand, especially if you are already familiar with the 'graph' data structure.

Code:   
- We are given 'n' count, randomly numbered nodes. We have chosen to store them in an array, whose indexes will represent the vertices themselves and the values - the distance from the starting point to the specified vertix. In order to make it of the correct size, we need the largest numbered node.
In our case that would be (3). We create the array of size [3 + 1].

```C#
double[] distance = new double[largestNode + 1]; // largestNode = 3
```

We have to assign default values to the cells - instead of leaving the default value of 0, we will asign positive infinity.

```C#
for (int i = 0; i < distance.Length; i++)
{
   distance[i] = double.PositiveInfinity;
}
```
