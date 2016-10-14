using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GOHWaveform;

namespace GOHWaveformTests
{
    class TestMethods
    {
        public static void TestKnownInputsAgainstKnownResults(Waveform wf, double[] knownInputs, double[] knownResults)
        {
            Assert.AreEqual(knownInputs.Length, knownResults.Length, "Known inputs and results test sets do not contain the same number of values.");
            for (int count = 0; count < knownInputs.Length; count++)
            {
                double phase = knownInputs[count];
                double actual = wf.Value(phase);
                double expected = knownResults[count];
                if (actual != expected)
                {
                    String message = "";
                    message += "Test Pair: " + count;
                    message += "\nDuty Cycle: " + wf.DutyCycle;
                    message += "\nPhase: " + phase;
                    message += "\nExpected: " + expected;
                    message += "\nActual: " + actual;
                    double tolerance = Math.Abs(expected) * 0.00001;
                    Assert.AreEqual(expected, actual, tolerance, message);
                }
            }
        }
    }
}
