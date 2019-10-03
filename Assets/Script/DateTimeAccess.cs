using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class FunDateTimeAccess {

    static String[] cultureNames = { "en-US", "en-GB", "fr-FR", "de-DE", "ru-RU" };
    public static string GetCurrentTime(int cultureType = 1, int locationType = 0) {
        DateTime localDate = DateTime.Now;
        DateTime utcDate = DateTime.UtcNow;

        CultureInfo culture = new CultureInfo(cultureNames[cultureType]);

        if (locationType == 0) {
            return localDate.ToString(culture); // Local date and time
        } else if (locationType == 1) {
            return utcDate.ToString(culture); // UTC date and time
        } else {
            return culture.NativeName; // utcDate.Kind
        }
    }

    public static string GetTodayDate() {
        DateTime date1 = new DateTime(2008, 6, 1, 7, 47, 0);
        Console.WriteLine(date1.ToString());

        // Get date-only portion of date, without its time.
        DateTime dateOnly = date1.Date;
        return dateOnly.ToString("d");

        // Display date using short date string.
        //Console.WriteLine(dateOnly.ToString("d"));
        // Display date using 24-hour clock.
        //Console.WriteLine(dateOnly.ToString("g"));
        //Console.WriteLine(dateOnly.ToString("MM/dd/yyyy HH:mm"));


    }
}
