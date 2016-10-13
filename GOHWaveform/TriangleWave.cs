using System;

namespace GOHWaveform
{
    public class TriangleWave : Waveform
    {
        private double dutyCycle;

        public TriangleWave(double dutyCycle)
        {
            if (dutyCycle < 0.0)
            {
                throw new ArgumentOutOfRangeException("dutyCycle", dutyCycle, Errors.DutyCycleNegativeMessage);
            }
            else if (dutyCycle > 1.0)
            {
                throw new ArgumentOutOfRangeException("dutyCycle", dutyCycle, Errors.DutyCycleAbove1);
            }
            this.dutyCycle = dutyCycle;
        }

        public double Value(double phase)
        {
            return 0.0;
        }
    }
}