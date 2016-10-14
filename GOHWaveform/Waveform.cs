namespace GOHWaveform
{
    public interface Waveform
    {
        double Value(double phase);
        double DutyCycle { get; set; }
    }
}
