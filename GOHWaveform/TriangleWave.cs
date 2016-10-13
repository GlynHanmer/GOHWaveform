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
                throw new ArgumentOutOfRangeException("dutyCycle", dutyCycle, Constants.DutyCycleNegativeMessage);
            }
            else if (dutyCycle > 1.0)
            {
                throw new ArgumentOutOfRangeException("dutyCycle", dutyCycle, Constants.DutyCycleAbove1);
            }
            this.dutyCycle = dutyCycle;
        }

        public double Value(double phase)
        {
            phase %= Constants._2PI;
            if (0.0 <= phase && phase < dutyCycle * Math.PI)
            {
                return phase / dutyCycle / Math.PI;
            } else if (dutyCycle * Math.PI <= phase && phase < dutyCycle * Constants._2PI) {
                return 2.0 - phase / dutyCycle / Math.PI;
            } else {
                return 0.0;
            }
        }
    }
}