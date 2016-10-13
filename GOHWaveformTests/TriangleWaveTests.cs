using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GOHWaveform;

namespace GOHWaveformTests
{
    [TestClass]
    public class TriangleWaveTests
    {
        [TestMethod]
        public void Constructor_ReturnsTriangleWave()
        {
            double[] dutyCycles = { 0.0, 0.5, 1.0 };
            foreach (var dutyCycle in dutyCycles)
            {
                TriangleWave tw = new TriangleWave(dutyCycle);
                Assert.IsInstanceOfType(tw, typeof(TriangleWave));
            }
        }

        [TestMethod]
        public void Constructor_ThrowsArgumentOutOfRangeException_ForNegativeDutyCycle()
        {
            double dutyCycle = -1.0;
            try
            {
                TriangleWave tw = new TriangleWave(dutyCycle);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Assert.IsInstanceOfType(e, typeof(ArgumentOutOfRangeException));
                StringAssert.Contains(e.Message, Errors.DutyCycleNegativeMessage);
                return;
            }
            Assert.Fail();
        }

        [TestMethod]
        public void Constructor_ThrowsArgumentOutOfRangeException_ForDutyCycleGreatherThan1()
        {
            double dutyCycle = 1.000001;
            try
            {
                TriangleWave sw = new TriangleWave(dutyCycle);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Assert.IsInstanceOfType(e, typeof(ArgumentOutOfRangeException));
                StringAssert.Contains(e.Message, Errors.DutyCycleAbove1);
                return;
            }
            Assert.Fail();
        }

        [TestMethod]
        public void Value_ReturnsDouble()
        {
            double dutyCycle = 0.25;
            double[] phases = { 0.0, 0.2, dutyCycle * 2.0 * Math.PI, 3.0, 2.0 * Math.PI };
            TriangleWave tw = new TriangleWave(dutyCycle);
            foreach (double phase in phases)
            {
                Assert.IsInstanceOfType(tw.Value(phase), typeof(double));
            }
        }

        
    }
}
