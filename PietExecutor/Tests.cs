using NUnit.Framework;
using PietExecutor.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PietExecutor
{
    class Tests
    {
        /*
         * 0   
         * 1   R 
         * 2   
         *   0 1 2
         */
        [Test]
        public void SinglePixelCodelHasCorrectExits()
        {
            var pixel = new Pixel(1, 1, PietColor.Red);

            var codel = new Codel(PietColor.Red);
            codel.AddPixel(pixel);

            var directionPointer = new DirectionPointer(); // right
            var codelChooser = new CodelChooser();

            CheckBothCodelDirections(directionPointer, codel, codelChooser, (2, 1), (2, 1));
            directionPointer.Cycle(); // down
            CheckBothCodelDirections(directionPointer, codel, codelChooser, (1, 2), (1, 2));
            directionPointer.Cycle(); // left
            CheckBothCodelDirections(directionPointer, codel, codelChooser, (0, 1), (0, 1));
            directionPointer.Cycle(); // up
            CheckBothCodelDirections(directionPointer, codel, codelChooser, (1, 0), (1, 0));
        }

        /*
         * 0
         * 1   R R R
         * 2   R R R
         * 3
         *   0 1 2 3 4
         */
        [Test]
        public void BarCodelHasCorrectExits()
        {
            var codel = new Codel(PietColor.Red);
            for (int y = 1; y <= 2; y++)
            {
                for (int x = 1; x <= 3; x++)
                {
                    codel.AddPixel(new Pixel(x, y, PietColor.Red));
                }
            }

            var directionPointer = new DirectionPointer(); // right
            var codelChooser = new CodelChooser();

            CheckBothCodelDirections(directionPointer, codel, codelChooser, (4, 1), (4, 2));
            directionPointer.Cycle(); // down
            CheckBothCodelDirections(directionPointer, codel, codelChooser, (3, 3), (1, 3));
            directionPointer.Cycle(); // left
            CheckBothCodelDirections(directionPointer, codel, codelChooser, (0, 2), (0, 1));
            directionPointer.Cycle(); // up
            CheckBothCodelDirections(directionPointer, codel, codelChooser, (1, 0), (3, 0));
        }

        [Test]
        public void BarHasCorrectExitsIfPixelsAreInsertedOtherWayAround()
        {
            var codel = new Codel(PietColor.Red);
            for (int y = 2; y >= 1; y--)
            {
                for (int x = 3; x >= 1; x--)
                {
                    codel.AddPixel(new Pixel(x, y, PietColor.Red));
                }
            }

            var directionPointer = new DirectionPointer(); // right
            var codelChooser = new CodelChooser();

            CheckBothCodelDirections(directionPointer, codel, codelChooser, (4, 1), (4, 2));
            directionPointer.Cycle(); // down
            CheckBothCodelDirections(directionPointer, codel, codelChooser, (3, 3), (1, 3));
            directionPointer.Cycle(); // left
            CheckBothCodelDirections(directionPointer, codel, codelChooser, (0, 2), (0, 1));
            directionPointer.Cycle(); // up
            CheckBothCodelDirections(directionPointer, codel, codelChooser, (1, 0), (3, 0));
        }

        /*
         * 0
         * 1   R R
         * 2   R R R R
         * 3   R R R R
         * 4       R R
         * 5
         *   0 1 2 3 4 5
         */
        [Test]
        public void CustomCodel1HasCorrectExits()
        {
            var codel = new Codel(PietColor.Red);
            for (int y = 2; y <=3; y++)
            {
                for (int x = 1; x <= 4; x++)
                {
                    codel.AddPixel(new Pixel(x, y, PietColor.Red));
                }
            }
            codel.AddPixel(new Pixel(1, 1, PietColor.Red));
            codel.AddPixel(new Pixel(2, 1, PietColor.Red));
            codel.AddPixel(new Pixel(3, 4, PietColor.Red));
            codel.AddPixel(new Pixel(4, 4, PietColor.Red));

            var directionPointer = new DirectionPointer(); // right
            var codelChooser = new CodelChooser();

            CheckBothCodelDirections(directionPointer, codel, codelChooser, (5, 2), (5, 4));
            directionPointer.Cycle(); // down
            CheckBothCodelDirections(directionPointer, codel, codelChooser, (4, 5), (3, 5));
            directionPointer.Cycle(); // left
            CheckBothCodelDirections(directionPointer, codel, codelChooser, (0, 3), (0, 1));
            directionPointer.Cycle(); // up
            CheckBothCodelDirections(directionPointer, codel, codelChooser, (1, 0), (2, 0));
        }

        private void CheckBothCodelDirections(DirectionPointer directionPointer, Codel codel, CodelChooser codelChooser, (int x, int y) left, (int x, int y) right)
        {
            Assert.AreEqual(left, codel.GetExitPixel(directionPointer, codelChooser));
            codelChooser.Cycle();
            Assert.AreEqual(right, codel.GetExitPixel(directionPointer, codelChooser));
            codelChooser.Cycle();
        }
    }
}
