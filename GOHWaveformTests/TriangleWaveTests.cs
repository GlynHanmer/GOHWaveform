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
    }
}
