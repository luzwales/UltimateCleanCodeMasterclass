//you can use this file to try out any code you want
Console.WriteLine("Press any key to close.");
Console.ReadKey();


//this method will be hard to test,
//because static Now property cannot be mocked
string GetCurrentDayDescription()
{
DateTime today = DateTime.Now;
return $"Today is {today.DayOfWeek}";
}

//solution: a wrapper class + interface
//the interface can be mocked
interface IDateTime
{
    DateTime Now { get; }
}

class DateTimeWrapper : IDateTime
{
    public DateTime Now
    {
        get
        {
            return DateTime.Now;
        }
    }
}