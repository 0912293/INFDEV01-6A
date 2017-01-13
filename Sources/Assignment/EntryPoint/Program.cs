using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;  

namespace EntryPoint
{
#if WINDOWS || LINUX
  public static class Program
  {

    [STAThread]
    static void Main()
    {

      var fullscreen = false;
      read_input:
      switch (Microsoft.VisualBasic.Interaction.InputBox("Which assignment shall run next? (1, 2, 3, 4, or q for quit)", "Choose assignment", VirtualCity.GetInitialValue()))
      {
        case "1":
          using (var game = VirtualCity.RunAssignment1(SortSpecialBuildingsByDistance, fullscreen))
            game.Run();
          break;
        case "2":
          using (var game = VirtualCity.RunAssignment2(FindSpecialBuildingsWithinDistanceFromHouse, fullscreen))
            game.Run();
          break;
        case "3":
          using (var game = VirtualCity.RunAssignment3(FindRoute, fullscreen))
            game.Run();
          break;
        case "4":
          using (var game = VirtualCity.RunAssignment4(FindRoutesToAll, fullscreen))
            game.Run();
          break;
        case "q":
          return;
      }
      goto read_input;
    }
       
    private static IEnumerable<Vector2> SortSpecialBuildingsByDistance(Vector2 house, IEnumerable<Vector2> specialBuildings)
    {                                                                
        Vector2[] buildings = new Vector2[50];      
        int i = 0;
        foreach(var item in specialBuildings)
        {
            buildings[i] = item;
            i++;
        }

        SplitnSort(buildings,0,49,house);

        IEnumerable<Vector2> sortedBuildings;
        sortedBuildings = buildings;
        return sortedBuildings;
//            return specialBuildings.OrderBy(v => Vector2.Distance(v, house));
    }

      static void mergeSort(Vector2[]number, int low, int mid, int high, Vector2 house)
    {
        Vector2[] temp = new Vector2[50];
        int i, pos, l_end, h;
        pos = low;
        l_end = (mid - 1);
        h = (high - low + 1);

        while ((low <= l_end) && (mid <= high)){ 
            if (Dist.get_dist(number[low],house) <= Dist.get_dist(number[mid], house))
            {
                temp[pos++] = number[low++];
            }else{
                temp[pos++] = number[mid++];
            }
        }

        while (low <= l_end){
            temp[pos++] = number[low++];
        }
        while (mid <= high){
            temp[pos++] = number[mid++];
        }
        for (i = 0; i < h; i++){
            number[high] = temp[high];
            high--;
        }

    }

    static void SplitnSort(Vector2[]number, int low, int high, Vector2 house)
    {
        int mid;
        if (high > low){
            mid = (low + high) / 2;
            SplitnSort(number, low, mid, house);
            SplitnSort(number, mid + 1, high, house);
            mergeSort(number, low, mid + 1, high, house);
        }
    }


     private static IEnumerable<IEnumerable<Vector2>> FindSpecialBuildingsWithinDistanceFromHouse(
      IEnumerable<Vector2> specialBuildings, 
      IEnumerable<Tuple<Vector2, float>> housesAndDistances)
     {                              
         Tree tree = new Tree(specialBuildings.ToArray());

         return tree.Traverse(tree, housesAndDistances);

//      return
//          from h in housesAndDistances
//          select
//            from s in specialBuildings
//            where Vector2.Distance(h.Item1, s) <= h.Item2
//            select s;
     }
                        
    private static IEnumerable<Tuple<Vector2, Vector2>> FindRoute(Vector2 startingBuilding, 
      Vector2 destinationBuilding, IEnumerable<Tuple<Vector2, Vector2>> roads)
    {
//        foreach (var i in roads)
//        {
//            Console.WriteLine(i);
//        }
//        Console.WriteLine(startingBuilding);
//        Console.WriteLine(destinationBuilding);
//        MatrixCreatrix mc = new MatrixCreatrix(startingBuilding, destinationBuilding, roads);
//        return mc.PleaseWork;
      var startingRoad = roads.Where(x => x.Item1.Equals(startingBuilding)).First();
      List<Tuple<Vector2, Vector2>> fakeBestPath = new List<Tuple<Vector2, Vector2>>() { startingRoad };
      var prevRoad = startingRoad;
      for (int i = 0; i < 30; i++)
      {
        prevRoad = (roads.Where(x => x.Item1.Equals(prevRoad.Item2)).OrderBy(x => Vector2.Distance(x.Item2, destinationBuilding)).First());
        fakeBestPath.Add(prevRoad);
      }
      return fakeBestPath;
    }
                        
    private static IEnumerable<IEnumerable<Tuple<Vector2, Vector2>>> FindRoutesToAll(Vector2 startingBuilding, 
      IEnumerable<Vector2> destinationBuildings, IEnumerable<Tuple<Vector2, Vector2>> roads)
    {
      List<List<Tuple<Vector2, Vector2>>> result = new List<List<Tuple<Vector2, Vector2>>>();
      foreach (var d in destinationBuildings)
      {
        var startingRoad = roads.Where(x => x.Item1.Equals(startingBuilding)).First();
        List<Tuple<Vector2, Vector2>> fakeBestPath = new List<Tuple<Vector2, Vector2>>() { startingRoad };
        var prevRoad = startingRoad;
        for (int i = 0; i < 30; i++)
        {
          prevRoad = (roads.Where(x => x.Item1.Equals(prevRoad.Item2)).OrderBy(x => Vector2.Distance(x.Item2, d)).First());
          fakeBestPath.Add(prevRoad);
        }
        result.Add(fakeBestPath);
      }
      return result;
    }
  }
#endif
}
