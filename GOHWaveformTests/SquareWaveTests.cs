using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GOHWaveform;

namespace GOHWaveformTests
{
    [TestClass]
    public class SquareWaveTests : WaveformTests
    {
        [TestMethod]
        public void Constructor_ReturnsSquareWave()
        {
            double[] dutyCycles = { 0.0, 0.5, 1.0 };
            foreach (var dutyCycle in dutyCycles)
            {
                SquareWave sw = new SquareWave(dutyCycle);
                Assert.IsInstanceOfType(sw, typeof(SquareWave));
            }
        }

        [TestMethod]
        public void Constructor_ThrowsArgumentOutOfRangeException_ForNegativeDutyCycle()
        {
            double dutyCycle = -1.0;
            try
            {
                SquareWave sw = new SquareWave(dutyCycle);
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
                SquareWave sw = new SquareWave(dutyCycle);
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
            double[] dutyCycles = { 0.0, 0.5, 1.0 };
            double[] phases = { 0.0, 0.25 * Math.PI, 0.5 * Math.PI, Constants._2PI };
            foreach (double dutyCycle in dutyCycles)
            {
                SquareWave sw = new SquareWave(dutyCycle);
                foreach (double phase in phases)
                {
                    Assert.IsInstanceOfType(sw.Value(phase), typeof(double));
                }
            }
        }

        [TestMethod]
        public void Value_Returns0AlwaysForDutyCycleOf0()
        {
            double dutyCycle = 0.0;
            double[] phases = { 0.0, 0.25 * Math.PI, 0.5 * Math.PI, Constants._2PI };
            double expected = 0.0;
            SquareWave sw = new SquareWave(dutyCycle);
            foreach (double phase in phases)
            {
                Assert.AreEqual(sw.Value(phase), expected);
            }
        }

        [TestMethod]
        public void Value_Returns1AlwaysForDutyCycleOf1()
        {
            double dutyCycle = 1.0;
            double[] phases = { 0.0, 0.25 * Math.PI, 0.5 * Math.PI, Constants._2PI };
            double expected = 1.0;
            SquareWave sw = new SquareWave(dutyCycle);
            foreach (double phase in phases)
            {
                Assert.AreEqual(sw.Value(phase), expected);
            }
        }


        [TestMethod]
        public void Value_ReturnsKnownValues_ForKnownPhases()
        {
            double dutyCycle = 0.25;
            double[] phases = { 0.0, 0.2, dutyCycle * Constants._2PI, 3.0, Constants._2PI };
            double[] expectedValues = { 1.0, 1.0, 0.0, 0.0, 1.0 };
            SquareWave sw = new SquareWave(dutyCycle);
            Assert.AreEqual(phases.Length, expectedValues.Length, "Known inputs and results test sets do not contain the same number of values.");
            for (int count = 0; count < phases.Length; count++)
            {
                double phase = phases[count];
                double actual = sw.Value(phase);
                double expected = expectedValues[count];
                string message = string.Format("Phase: {0}\nExpected: {1}\nActual:{2}", phase, expected, actual);
                Assert.AreEqual(actual, expected, message);
            }
        }

        [TestMethod]
        public void SetDutyCycle_ThrowsArgumentOutOfRangeException_ForNegativeDutyCycle()
        {
            double initialDutyCycle = 0.5;
            SquareWave sw = new SquareWave(initialDutyCycle);
            try
            {
                double negativeDutyCycle = -0.25;
                sw.DutyCycle = negativeDutyCycle;
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
        public void Value_ReturnsKnownResults_ForKnownPhases_BeforeAndAfterSetDutyCycle()
        {
            double initialDutyCycle = 0.25;
            double[] initialPhases = { 0.0, 0.2, initialDutyCycle * Constants._2PI, 3.0, Constants._2PI };
            double[] initialexpectedValues = { 1.0, 1.0, 0.0, 0.0, 1.0 };
            SquareWave sw = new SquareWave(initialDutyCycle);
            TestMethods.TestKnownInputsAgainstKnownResults(sw, initialPhases, initialexpectedValues);

            double finalDutyCycle = 0.6;
            double[] finalPhases = { 0.0, 0.2, initialDutyCycle * Constants._2PI, 3.0, 6.0, Constants._2PI };
            double[] finalExpectedValues = { 1.0, 1.0, 1.0, 1.0, 0.0, 1.0 };
            sw.DutyCycle = finalDutyCycle;
            TestMethods.TestKnownInputsAgainstKnownResults(sw, finalPhases, finalExpectedValues);
        }
    }
}
