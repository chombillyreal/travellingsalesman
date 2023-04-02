class Program
{
    static int[,] distanceMatrix = new int[,]
   {
        {0, 10, 15, 20},
        {10, 0, 35, 25},
        {15, 35, 0, 30},
        {20, 25, 30, 0}
   };

static int cityCount = distanceMatrix.GetLength(0);

static int[] shortestPath = new int[cityCount];
static bool[] visited = new bool[cityCount];
static int shortestDistance = int.MaxValue;

static void TravelingSalesman(int[,] distanceMatrix, int cityCount, int currentCity, int citiesVisited)
{
    if (citiesVisited == cityCount && distanceMatrix[currentCity, 0] > 0)
    {
        if (distanceMatrix[currentCity, 0] < shortestDistance)
        {
            for (int i = 0; i < cityCount; i++)
            {
                shortestPath[i] = visited[i] ? i + 1 : 0;
            }
            shortestDistance = distanceMatrix[currentCity, 0];
        }
    }
    else
    {
        for (int i = 0; i < cityCount; i++)
        {
            if (distanceMatrix[currentCity, i] > 0 && !visited[i])
            {
                visited[i] = true;
                TravelingSalesman(distanceMatrix, cityCount, i, citiesVisited + 1);
                visited[i] = false;
            }
        }
    }
}

static void Main()
{
    visited[0] = true;
    TravelingSalesman(distanceMatrix, cityCount, 0, 1);

    Console.WriteLine("Shortest path: " + string.Join(" -> ", shortestPath) + " -> 1");
    Console.WriteLine("Total distance: " + shortestDistance);
}

