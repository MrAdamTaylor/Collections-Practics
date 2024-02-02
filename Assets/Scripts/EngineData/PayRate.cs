using System;

public record PayRate
{
    private TimeSpan _duration;

    public PayRate(Money pay, TimeSpan duration)
    {
        this.Pay = pay;
        this.Duration = duration;
    }

    public Money Pay { get; set; }

    public TimeSpan Duration
    {
        get => this._duration;
        set => this._duration = (TimeSpan)value.NonZero(nameof(Duration));
    }

    public Money In(TimeSpan duration) =>
        duration == TimeSpan.Zero ? this.Pay with { Amount = 0 }
        : this.Pay.Divide(this.Ratio(duration));

    private decimal Ratio(TimeSpan duration) =>
        (decimal)(duration.TotalSeconds / this.Duration.TotalSeconds);
}