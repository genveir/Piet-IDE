using NUnit.Framework;
using PietExecutor.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PietExecutor.Tests
{
    class RunnerTests
    {
        [Test]
        public void SinglePixelProgramEnds()
        {
            var pixels = new Pixel[1][];
            pixels[0] = new Pixel[1];
            pixels[0][0] = new Pixel(0, 0, PietColor.Red);

            var program = new Program(pixels);
            var runner = new PietRunner(program);

            Assert.AreEqual(false, runner.ExecuteStep());
        }

        [Test]
        public void ControlExitsRight()
        {
            var pixels = new Pixel[1][];
            pixels[0] = new Pixel[2];
            pixels[0][0] = new Pixel(0, 0, PietColor.Red);
            pixels[0][1] = new Pixel(1, 0, PietColor.Blue);

            var program = new Program(pixels);
            var state = new ExecutionState(program.GetPixel(0, 0).codel);
            var runner = new PietRunner(program, state);

            Assert.AreEqual(true, runner.ExecuteStep());
            Assert.AreEqual(DirectionPointer.DP_RIGHT, state.DirectionPointer.currentValue);
            Assert.AreEqual(CodelChooser.CC_LEFT, state.CodelChooser.currentValue);
            Assert.AreEqual(program.GetPixel(1, 0).codel, state.CurrentCodel);
        }

        [Test]
        public void ControlExitsDown()
        {
            var pixels = new Pixel[2][];
            pixels[0] = new Pixel[] { new Pixel(0, 0, PietColor.Red) };
            pixels[1] = new Pixel[] { new Pixel(0, 1, PietColor.Blue) };

            var program = new Program(pixels);
            var state = new ExecutionState(program.GetPixel(0, 0).codel);
            var runner = new PietRunner(program, state);

            Assert.AreEqual(true, runner.ExecuteStep());
            Assert.AreEqual(DirectionPointer.DP_DOWN, state.DirectionPointer.currentValue);
            Assert.AreEqual(CodelChooser.CC_RIGHT, state.CodelChooser.currentValue);
            Assert.AreEqual(program.GetPixel(0, 1).codel, state.CurrentCodel);
        }

        [Test]
        public void ControlExitsLeft()
        {
            var pixels = new Pixel[1][];
            pixels[0] = new Pixel[2];
            pixels[0][0] = new Pixel(0, 0, PietColor.Red);
            pixels[0][1] = new Pixel(1, 0, PietColor.Blue);

            var program = new Program(pixels);
            var state = new ExecutionState(program.GetPixel(1, 0).codel);
            var runner = new PietRunner(program, state);

            Assert.AreEqual(true, runner.ExecuteStep());
            Assert.AreEqual(DirectionPointer.DP_LEFT, state.DirectionPointer.currentValue);
            Assert.AreEqual(CodelChooser.CC_LEFT, state.CodelChooser.currentValue);
            Assert.AreEqual(program.GetPixel(0, 0).codel, state.CurrentCodel);
        }

        [Test]
        public void ControlExitsUp()
        {
            var pixels = new Pixel[2][];
            pixels[0] = new Pixel[] { new Pixel(0, 0, PietColor.Red) };
            pixels[1] = new Pixel[] { new Pixel(0, 1, PietColor.Blue) };

            var program = new Program(pixels);
            var state = new ExecutionState(program.GetPixel(0, 1).codel);
            var runner = new PietRunner(program, state);

            Assert.AreEqual(true, runner.ExecuteStep());
            Assert.AreEqual(DirectionPointer.DP_UP, state.DirectionPointer.currentValue);
            Assert.AreEqual(CodelChooser.CC_RIGHT, state.CodelChooser.currentValue);
            Assert.AreEqual(program.GetPixel(0, 0).codel, state.CurrentCodel);
        }
    }
}
