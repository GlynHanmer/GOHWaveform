using System;

namespace GOHWaveform
{
    public class SquareWave : Waveform
    {
        public const string DutyCycleNegativeMessage = "Negative duty cycle not allowed.";
        public const string DutyCycleAbove1 = "Duty cycle greather than 1 not allowed.";
        double dutyCycle;

        public SquareWave(double dutyCycle)
        {
            if (dutyCycle < 0.0)
            {
                throw new ArgumentOutOfRangeException("dutyCycle", dutyCycle, DutyCycleNegativeMessage);
            } else if (dutyCycle > 1.0)
            {
                throw new ArgumentOutOfRangeException("dutyCycle", dutyCycle, DutyCycleAbove1);
            }
            this.dutyCycle = dutyCycle;
        }

        public double Value(double phase)
        {
            phase %= 2 * Math.PI;
            if(phase >= 0.0 && phase < 2*Math.PI*dutyCycle)
            {
                return 1.0;
            } else if (2 * Math.PI * dutyCycle <= phase && phase < 2 * Math.PI)
            {
                return 0.0;
            }
            string exceptionMessage = string.Format("Unable to provide value for phase ({0}) and duty cycle ({1})", phase, dutyCycle);
            throw new InvalidOperationException(exceptionMessage);
        }
    }
}
