namespace GOHWaveform
{
    interface Waveform
    {
        double Value(double phase);
        double DutyCycle { get; set; }
    }
}
