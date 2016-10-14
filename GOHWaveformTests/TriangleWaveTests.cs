using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GOHWaveform;

namespace GOHWaveformTests
{
    [TestClass]
    public class TriangleWaveTests : WaveformTests
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
                StringAssert.Contains(e.Message, Constants.DutyCycleNegativeMessage);
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
                StringAssert.Contains(e.Message, Constants.DutyCycleAbove1);
                return;
            }
            Assert.Fail();
        }

        [TestMethod]
        public void Value_ReturnsDouble()
        {
            double dutyCycle = 0.25;
            double[] phases = { 0.0, 0.2, dutyCycle * Constants._2PI, 3.0, Constants._2PI };
            TriangleWave tw = new TriangleWave(dutyCycle);
            foreach (double phase in phases)
            {
                Assert.IsInstanceOfType(tw.Value(phase), typeof(double));
            }
        }

        [TestMethod]
        public void Value_Returns0_AtBothEndsOfPeriod()
        {
            double[] dutyCycles = { 0.0, 0.5, 1.0 };
            double[] phases = { 0.0, 2 * Math.PI };
            foreach (double dutyCycle in dutyCycles)
            {
                TriangleWave tw = new TriangleWave(dutyCycle);
                foreach (double phase in phases)
                {
                    double expected = 0.0;
                    double actual = tw.Value(phase);
                    if (actual != expected)
                    {
                        String message = "";
                        message += "Duty Cycle: " + dutyCycle;
                        message += "\nPhase: " + phase;
                        message += "\nExpected: " + expected;
                        message += "\nActual: " + actual;
                        Assert.AreEqual(0.0, tw.Value(phase), message);
                    }
                }
            }
        }

        [TestMethod]
        public void Value_Returns1_AtHalfDutyCyclePhase_ForDutyCycleGreaterThan0()
        {
            double[] dutyCycles = { 0.5, 1.0 };
            foreach (double dutyCycle in dutyCycles)
            {
                TriangleWave tw = new TriangleWave(dutyCycle);
                double phase = dutyCycle * Constants._2PI / 2.0;
                double actual = tw.Value(phase);
                double expected = 1.0;
                if (actual != expected)
                {
                    String message = "";
                    message += "Duty Cycle: " + dutyCycle;
                    message += "\nPhase: " + phase;
                    message += "\nExpected: " + expected;
                    message += "\nActual: " + actual;
                    Assert.AreEqual(expected, tw.Value(phase), message);
                }
            }
        }

        [TestMethod]
        public void Value_ReturnsKnownValues_ForKnownPhases()
        {
            double dutyCycle = 0.32;
            double[] phases = { 0.0, 0.08 * Constants._2PI, 0.24 * Constants._2PI, 0.32 * Constants._2PI, 0.99 * Constants._2PI, Constants._2PI };
            double[] expectedValues = { 0.0, 0.5, 0.5, 0.0, 0.0, 0.0 };
            TriangleWave tw = new TriangleWave(dutyCycle);
            Assert.AreEqual(phases.Length, expectedValues.Length, "Known inputs and results test sets do not contain the same number of values.");
            for (int count = 0; count < phases.Length; count++)
            {
                double phase = phases[count];
                double actual = tw.Value(phase);
                double expected = expectedValues[count];
                string message = string.Format("Phase: {0}\nExpected: {1}\nActual:{2}", phase, expected, actual);
                Assert.AreEqual(actual, expected, message);
            }
        }

        public void Value_ReturnsKnownResults_ForKnownPhases_BeforeAndAfterSetDutyCycle()
        {
            throw new NotImplementedException();
        }
    }
}
