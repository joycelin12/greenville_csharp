using System;
using static System.Console;
using System.Globalization;
using System.Collections.Generic;
class GreenvilleRevenue
{
   static void Main()
   {
      // Your code here
      int x;
      WriteLine("Enter number of contestants last year >>");
      int contestantsL = int.Parse(ReadLine());
      
      WriteLine("Enter number of contestants this year >>");
      int contestantsT = int.Parse(ReadLine());
        
      string[ , ] talent = new string[contestantsT, 2];

      for (x=0; x < contestantsT; ++x)
      {
         
         WriteLine("Enter the contestant's name >>");
         talent[x,0] = ReadLine();
         
         WriteLine("Enter the contestant's talent (S for singing, D for dancing, M for playing musical instrument and O for other) >>");
         talent[x,1] = ReadLine();
         while(talent[x, 1] != "S" && talent[x, 1] != "D" && 
           talent[x, 1] != "M" && talent[x, 1] != "O")
          {
             WriteLine("{0} is not a valid code", talent[x,1]);
             WriteLine("Enter the contestant's talent (S for singing, D for dancing, M for playing musical instrument and O for other) >>");
         talent[x,1] = ReadLine();
         }     
      }
      
      int countS=0;
      int countD=0;
      int countM=0;
      int countO=0;

      List<String> listS = new List<String>();
      List<String> listD = new List<String>();
      List<String> listM= new List<String>();
      List<String> listO = new List<String>();

      for (x=0; x < contestantsT; ++x)
      {
        switch(talent[x,1])
        {
           case "S":
              countS++;
              listS.Add(talent[x,0]);
              break;
           case "D":
              countD++;
              listD.Add(talent[x,0]);
              break;
           case "M":
              countM++;
              listM.Add(talent[x,0]);
              break;
           case "O":
              countO++;
              listO.Add(talent[x,0]);
              break;   
        }
      }

      WriteLine("The types of talent are:");
      WriteLine("Singing               {0}",countS);
      WriteLine("Dancing               {0}",countD);
      WriteLine("Musical instrument    {0}",countM);
      WriteLine("Other                 {0}",countO);
      
      WriteLine("Enter talent code >>");
      string talentCode = ReadLine();

      while (talentCode != "Z")
      {
       switch(talentCode)
       {
        case "S":
        WriteLine("Contestants with talent Singing are:");
        foreach(string one in listS)
         WriteLine(one);
         break;
         case "D":
        WriteLine("Contestants with talent Dancing are:");
        foreach(string one in listD)
         WriteLine(one);
         break;
         case "M":
        WriteLine("Contestants with talent Musical instrument are:");
        foreach(string one in listM)
         WriteLine(one);
         break;
         case "O":
        WriteLine("Contestants with talent Other are:");
        foreach(string one in listO)
         WriteLine(one);
         break;
         
        default:
          WriteLine("{0} is not a valid code", talentCode);
          break;
        }

        WriteLine("Enter talent code >>");
        talentCode = ReadLine();
      } 
      

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
