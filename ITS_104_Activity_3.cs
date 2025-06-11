using System;

public struct Time
{
    private readonly int minutes;

    public Time(int hh, int mm)
    {

        if (hh < 0 || hh > 23) throw new ArgumentException("Hours must be between 0 and 23");
        if (mm < 0 || mm > 59) throw new ArgumentException("Minutes must be between 0 and 59");

        this.minutes = 60 * hh + mm;
    }

    public override string ToString()
    {
        int hours = minutes / 60;
        int mins = minutes % 60;


        string period = "AM";
        int displayHours = hours;

        if (hours >= 12)
        {
            period = "PM";
            if (hours > 12)
            {
                displayHours = hours - 12;
            }
        }
        else if (hours == 0)
        {
            displayHours = 12; 
        }

        return $"{displayHours:D2}:{mins:D2} {period}";
    }

    public int TotalMinutes => minutes;
}

class TestTime
{
    static void Main(string[] args)
    {
        
        Time morning = new Time(8, 30);   
        Time noon = new Time(12, 0);      
        Time midnight = new Time(0, 0);   
        Time evening = new Time(20, 45); 


        Console.WriteLine("Morning time: " + morning);
        Console.WriteLine("Noon time: " + noon);
        Console.WriteLine("Midnight time: " + midnight);
        Console.WriteLine("Evening time: " + evening);


        Console.WriteLine("\nEnter your own time:");

        try
        {
            Console.Write("Enter hours (0-23): ");
            int hh = int.Parse(Console.ReadLine());

            Console.Write("Enter minutes (0-59): ");
            int mm = int.Parse(Console.ReadLine());

            Console.Write("AM or PM? (leave blank for 24-hour format): ");
            string period = Console.ReadLine().ToUpper();


            if (period == "PM" && hh < 12)
            {
                hh += 12;
            }
            else if (period == "AM" && hh == 12)
            {
                hh = 0;
            }

            Time userTime = new Time(hh, mm);
            Console.WriteLine("\nYour time is: " + userTime);
            Console.WriteLine("Total minutes since midnight: " + userTime.TotalMinutes);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
