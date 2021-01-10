using System;
using static System.Console;
using System.Globalization;
class GreenvilleRevenue
{
   static void Main()
   {
      // Your code here
      WriteLine("Enter number of contestants last year >>");
      int contestantsL = int.Parse(ReadLine());
      while (contestantsL >-1 && contestantsL <31) {
      
      WriteLine("Enter number of contestants this year >>");
      int contestantsT = int.Parse(ReadLine());
      while (contestantsT > -1 && contestantsT <31) {
      
      double fee = (double)contestantsT*25;
      WriteLine("Last year's competition had {0} contestants and this year;s has {1} contestants", contestantsL, contestantsT);
      WriteLine("Revenue expected this year is {0}",fee.ToString("C", CultureInfo.GetCultureInfo("en-US")));
      if (2*contestantsL <  contestantsT) {
         WriteLine("The competition is more than twice as big this year!");

      } else if (contestantsL <  contestantsT){
      WriteLine("The competition is bigger than ever!");
      } else {
        WriteLine("A tighter race this year! Come out and cast your vote!");
      } 
      } 
      } 
     
   
   }
}
