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
            Boolean[,] expectedarray = new Boolean[,] { { true,true, false, false, false },
                                    { false,true, false, false, true},
                                    { false,false, false, false, false},
                                    { false,false, false, false, false},
                                    { false,false, false, false, true} };

            Boolean[,] actualarray = new Boolean[,] { {false,false, false, false, false },
                                                    { false,false, false, false, false},
                                                    { false,false, false, false, false},
                                                    { false,false, false, false, false},
                                                    { false,false, false, false, false} };
            minefield.SetBomb(0, 0);
            expectedarray[0, 0] = true;
            CollectionAssert.AreEqual(expectedarray, actualarray);
        }
        public void AddAdjacentValueCount()
        {
            int[,] expectedAdjacentValue = new int[,] { { 1, 1, 1, 0, 0 },
                                                        { 1, 0, 1, 0, 0 },
                                                        { 1, 1, 1, 0, 0 },
                                                        { 0, 0, 0, 0, 0 },
                                                        { 0, 0, 0, 0, 0 },
            };

            int[,] actualAdjacentValue = new int[,] { { 1, 1, 1, 0, 0 },
                                                      { 1, 0, 1, 0, 0 },
                                                      { 1, 1, 1, 0, 0 },
                                                      { 0, 0, 0, 0, 0 },
                                                      { 0, 0, 0, 0, 0 },
            };
            minefield.AddAdjacentValue(1, 1);
            CollectionAssert.AreEqual(expectedAdjacentValue, actualAdjacentValue);
        }
    }
}

// 
