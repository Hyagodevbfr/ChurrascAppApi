namespace ChurrascApp.Domain.Value_Objects;

public class DateAndTime
{
    public DateOnly Date { get; private set; }
    public TimeOnly Time { get; private set; }
    
    public DateAndTime(DateOnly date, TimeOnly time)
    {
        Validate(date, time);
        Date = date;
        Time = time;
    }

    private void Validate(DateOnly date, TimeOnly time)
    {
        var today = new DateOnly(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
        var now = new TimeOnly(DateTime.Now.Hour);
        var sixMonthsBeforeToday = new DateOnly(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day).AddMonths(6);
        
        if (date < today && time < now)
            throw new ArgumentException("Date must be after this exact moment.");
        
        if (date > sixMonthsBeforeToday)
            throw new ArgumentException("Date must be within six months.");
    }

    public override string ToString()
    {
        return $"{Date:dd/MM/yyyy} - {Time:hh\\:mm}";
    }
}