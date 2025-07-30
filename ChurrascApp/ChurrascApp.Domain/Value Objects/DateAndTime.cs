namespace ChurrascApp.Domain.Value_Objects;

public class DateAndTime
{
    public DateOnly Date { get; set; }
    public TimeOnly Time { get; set; }

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
        
        if (date < today && time < now)
            throw new ArgumentException("Date cannot be in the future");
        
        // Create validation if date is Greater than some year
    }

    public override string ToString()
    {
        return $"{Date:dd/MM/yyyy} {Time:hh\\:mm}";
    }
}