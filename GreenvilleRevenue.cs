using System;
using static System.Console;
using System.Globalization;
class GreenvilleRevenue
{
   static void Main()
   {
      // Write your main here
      WriteLine("Enter number of contestants last year >>");
      int contestantsL = int.Parse(ReadLine());
      WriteLine("Enter number of contestants this year >>");
      int contestantsT = int.Parse(ReadLine());
      double fee = (double)contestantsT*25;
      WriteLine("Last year's competition had {0} contestants and this year;s has {1} contestants", contestantsL, contestantsT);
      WriteLine("Revenue expected this year is {0}",fee.ToString("C", CultureInfo.GetCultureInfo("en-US")));
      if (contestantsL >  contestantsT) {
         WriteLine("It is False that this year's competition is bigger than last year's.");

      } else {
      WriteLine("It is True that this year's competition is bigger than last year's.");
      }

   }
}
