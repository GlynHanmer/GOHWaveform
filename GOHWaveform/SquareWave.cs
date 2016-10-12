using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOHWaveform
{
    public class SquareWave
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
    }
}
