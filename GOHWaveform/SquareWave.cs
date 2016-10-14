using System;

namespace GOHWaveform
{
    public class SquareWave : Waveform
    {
        private double _dutyCycle;
        public double DutyCycle {
            get
            {
                return _dutyCycle;
            }
            set
            {
                SetDutyCycle(value);
            }
        }

        public SquareWave(double dutyCycle)
        {
            this.SetDutyCycle(dutyCycle);
        }

        public double Value(double phase)
        {
            phase %= 2 * Math.PI;
            if(phase >= 0.0 && phase < Constants._2PI * _dutyCycle)
            {
                return 1.0;
            } else if (Constants._2PI * _dutyCycle <= phase && phase < Constants._2PI)
            {
                return 0.0;
            }
            string exceptionMessage = string.Format("Unable to provide value for phase ({0}) and duty cycle ({1})", phase, _dutyCycle);
            throw new InvalidOperationException(exceptionMessage);
        }

        private void SetDutyCycle(double dutyCycle)
        {
            if (dutyCycle < 0.0)
            {
                throw new ArgumentOutOfRangeException("dutyCycle", dutyCycle, Constants.DutyCycleNegativeMessage);
            }
            else if (dutyCycle > 1.0)
            {
                throw new ArgumentOutOfRangeException("dutyCycle", dutyCycle, Constants.DutyCycleAbove1);
            }
            this._dutyCycle = dutyCycle;
            return;
        }
    }
}
