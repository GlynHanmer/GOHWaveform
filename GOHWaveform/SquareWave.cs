using System;

namespace GOHWaveform
{
    public class SquareWave : Waveform
    {
        double dutyCycle;

        public SquareWave(double dutyCycle)
        {
            if (dutyCycle < 0.0)
            {
                throw new ArgumentOutOfRangeException("dutyCycle", dutyCycle, Constants.DutyCycleNegativeMessage);
            } else if (dutyCycle > 1.0)
            {
                throw new ArgumentOutOfRangeException("dutyCycle", dutyCycle, Constants.DutyCycleAbove1);
            }
            this.dutyCycle = dutyCycle;
        }

        public double Value(double phase)
        {
            phase %= 2 * Math.PI;
            if(phase >= 0.0 && phase < Constants._2PI * dutyCycle)
            {
                return 1.0;
            } else if (Constants._2PI * dutyCycle <= phase && phase < Constants._2PI)
            {
                return 0.0;
            }
            string exceptionMessage = string.Format("Unable to provide value for phase ({0}) and duty cycle ({1})", phase, dutyCycle);
            throw new InvalidOperationException(exceptionMessage);
        }
    }
}
