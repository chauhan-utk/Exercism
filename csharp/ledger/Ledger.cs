using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

public class LedgerEntry
{
   public LedgerEntry(DateTime date, string desc, decimal chg)
   {
       Date = date;
       Desc = desc;
       Chg = chg;
   }

   public DateTime Date { get; }
   public string Desc { get; }
   public decimal Chg { get; }
}

public static class Ledger
{
   public static LedgerEntry CreateEntry(string date, string desc, int chng)
   {
       return new LedgerEntry(DateTime.Parse(date, CultureInfo.InvariantCulture), desc, chng / 100.0m);
   }

   private static CultureInfo CreateCulture(string cur, string loc)
   {
        if ((cur != "USD" && cur != "EUR") || (loc != "nl-NL" && loc != "en-US"))
        {
            throw new ArgumentException("Invalid currency");
        }

        string curSymb = cur == "USD" ? "$" : "€";
        string datPat = loc == "en-US" ? "MM/dd/yyyy" : "dd/MM/yyyy";
        int curNeg = loc == "nl-NL" ? 12 : 0;

        var culture = new CultureInfo(loc);
        culture.NumberFormat.CurrencySymbol = curSymb;
        culture.NumberFormat.CurrencyNegativePattern = curNeg;
        culture.DateTimeFormat.ShortDatePattern = datPat;
        culture.DateTimeFormat.DateSeparator = loc == "en-US" ? "/" : "-";
        return culture;
   }

   private static string PrintHead(string loc)
   {
        if (loc != "nl-NL" && loc != "en-US")
            throw new ArgumentException("Invalid locale");
        return loc == "en-US" ? "Date       | Description               | Change       " : "Datum      | Omschrijving              | Verandering  ";
   }

   private static string Date(IFormatProvider culture, DateTime date) => date.ToString("d", culture);

   private static string Description(string desc)
   {
        return desc.Length > 25 ? string.Format("{0}...", desc.Substring(0, 22)) : desc;
   }

   private static string Change(IFormatProvider culture, decimal cgh)
   {
       return cgh < 0.0m ? cgh.ToString("C", culture) : cgh.ToString("C", culture) + " ";
   }

   private static string PrintEntry(IFormatProvider culture, LedgerEntry entry)
   {
       var date = Date(culture, entry.Date);
       var description = Description(entry.Desc);
       var change = Change(culture, entry.Chg);

        return string.Format("{0} | {1,-26}|{2,14}", date, description, change);
   }


   private static IEnumerable<LedgerEntry> sort(LedgerEntry[] entries)
   {
       var neg = entries.Where(e => e.Chg < 0).OrderBy(x => x.Date + "@" + x.Desc + "@" + x.Chg);
       var post = entries.Where(e => e.Chg >= 0).OrderBy(x => x.Date + "@" + x.Desc + "@" + x.Chg);

       var result = new List<LedgerEntry>();
       result.AddRange(neg);
       result.AddRange(post);

       return result;
   }

   public static string Format(string currency, string locale, LedgerEntry[] entries)
   {
       var formatted = PrintHead(locale);

       var culture = CreateCulture(currency, locale);

       if (entries.Length > 0)
       {
           var entriesForOutput = sort(entries);

           for (var i = 0; i < entriesForOutput.Count(); i++)
           {
               formatted += "\n" + PrintEntry(culture, entriesForOutput.Skip(i).First());
           }
       }

       return formatted;
   }
}
