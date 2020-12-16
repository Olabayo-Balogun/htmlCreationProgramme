using System;
using System.IO;
using System.Collections.Generic;
using System.Timers;

public class Example
{
    private static Timer aTimer;
    private static List<String> eventlog;
    private static int nEventsFired = 0;
    private static DateTime previousTime;

    public static void Main()
    {
        eventlog = new List<String>();

        StreamWriter sr = new StreamWriter("C:\\users\\OlabayoBalogun\\source\\repos\\htmlCreationProgramme\\htmlCreationProgramme\\hoodlumChecker.html");

        // Create a timer with a five millisecond interval.
        aTimer = new Timer(5000);
       
        aTimer.Elapsed += OnTimedEvent;

        // Hook up the Elapsed event for the timer. 
        aTimer.AutoReset = true;
        sr.WriteLine("The timer should fire every {0} milliseconds. <br>",
                     aTimer.Interval);
        aTimer.Enabled = true;

        Console.WriteLine("Press the Enter key to exit the program... ");
        Console.ReadLine();
        foreach (var item in eventlog)
            sr.WriteLine(item);
        sr.Close();
        Console.WriteLine("Terminating the application...");
    }

    private static void OnTimedEvent(Object source, ElapsedEventArgs e)
    {
        string time = DateTime.Now.ToString("G");
        
        eventlog.Add(String.Format($"The time is {time} <q>No hoodlum on site</q> <br>",
                                   e.SignalTime,
                                   nEventsFired++ == 0 ?
                                      0.0 : (e.SignalTime - previousTime).TotalMilliseconds));
        previousTime = e.SignalTime;
        if (nEventsFired == 20)
        {
            Console.WriteLine("No more events will fire... ");
            aTimer.Enabled = false;
        }
    }
}