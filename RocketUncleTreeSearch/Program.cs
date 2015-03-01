using System;

namespace RocketUncleTreeSearch
{
    class Program
    {
        static void Main(string[] args)
        {
            // count number of oranges.
            var oranges = DummyData.GetDummyFruitTree().CountFruit<Orange>();
            Console.WriteLine("{0} total oranges...", oranges);

            // count number of apples.
            var apple = DummyData.GetDummyFruitTree().CountFruit<Apple>();
            Console.WriteLine("\n{0} total apple...", apple);
            
            // return the branch that has the largest amount of fruits on it.
            var branchWithMostFruits = DummyData.GetDummyFruitTree().GetBranchWithMostFruits();
            Console.WriteLine(
                "\nBranch that has the largest amount of fruits on it (including sub branches), " +
                "total number of fruits on this branch is {0}", branchWithMostFruits.Item2);

            // return the color of any of the first fruits you find on the tree (start from left) 
            var strFormat = "\nThe color of the first fruits found on the tree (start from left) is {0}";
            Console.WriteLine(strFormat, DummyData.GetDummyFruitTree2().GetLeftMostFruit().Color);

            Console.ReadLine();
        }

    }
}
