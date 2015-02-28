using FizzWare.NBuilder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RocketUncleTreeSearch
{
    public static class DummyData
    {
        public static FruitTree GetDummyFruitTree()
        {
            var twoAppleOneOrange = new List<IFruit>() { new Apple(), new Apple(), new Orange() };
            var twoOrangeOneApple = new List<IFruit>() { new Orange(), new Orange(), new Apple() };

            var branchesBuilder = Builder<Branch>
            .CreateListOfSize(5)
            .TheFirst(1)
            .With(i => i.Fruits, twoOrangeOneApple)
            .TheNext(1)
            .With(i => i.Fruits, twoOrangeOneApple)
            .TheNext(1)
            .With(i => i.Fruits, twoOrangeOneApple)
            .TheNext(1)
            .With(i => i.Fruits, twoOrangeOneApple)
            .TheNext(1)
            .With(i => i.Fruits, twoOrangeOneApple);

            var branches = branchesBuilder.Build();

            branches.First().ChildBranches = Builder<Branch>.CreateListOfSize(3).All().With(i => i.Fruits, twoAppleOneOrange).Build();

            branches.First().ChildBranches.ElementAt(2).ChildBranches = Builder<Branch>.CreateListOfSize(3).All().With(i => i.Fruits, twoAppleOneOrange).Build();

            return new FruitTree() { ChildBranches = branches };
        }

        public static FruitTree GetDummyFruitTree2()
        {
            var oneAppleTwoOrange = new List<IFruit>() { new Apple(), new Orange(), new Orange() };
            var threeOranges = new List<IFruit>() { new Orange(), new Orange(), new Orange() };

            var branchesBuilder = Builder<Branch>
            .CreateListOfSize(5)
            .TheFirst(1)
            .With(i => i.Fruits, threeOranges)
            .TheNext(1)
            .With(i => i.Fruits, threeOranges)
            .TheNext(1)
            .With(i => i.Fruits, threeOranges)
            .TheNext(1)
            .With(i => i.Fruits, threeOranges)
            .TheNext(1)
            .With(i => i.Fruits, threeOranges);

            var branches = branchesBuilder.Build();

            branches.First().ChildBranches = Builder<Branch>.CreateListOfSize(3).All().With(i => i.Fruits, oneAppleTwoOrange).Build(); // the first apple will be leftmost.

            branches.First().ChildBranches.ElementAt(2).ChildBranches = Builder<Branch>.CreateListOfSize(3).All().With(i => i.Fruits, threeOranges).Build();

            return new FruitTree() { ChildBranches = branches };
        }
    }
}
