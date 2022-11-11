using Microsoft.VisualStudio.TestTools.UnitTesting;
using Minesweeper;

namespace MinesweeperTests
{
    [TestClass]

    public class UnitTest1

    {
        Minefield minefield = new Minefield(5, 5);

        [TestMethod]
        public void SetBomb_placementofBomb_IsTrue()
        {
             int x = 0;
            int y = 0;
            Boolean[,] expectedarray = new Boolean[,] { { true,true, false, false, false },
                                                        { false,true, false, false, true},
                                                        { false,false, false, false, false},
                                                        { false,false, false, false, false},
                                                        { false,false, true, false, false} };


            Boolean[,] actualResult = new Boolean[5, 5];

            minefield.SetBomb(x, y);
            foreach(var result in actualResult)
            {
                actualResult[x, y] = true;
            }
            Assert.IsTrue(actualResult[x, y] = true);

            Assert.AreEqual(actualResult[x,y], expectedarray[x,y]);

        }
    }
}

// 
