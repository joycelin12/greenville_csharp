using System;
using static System.Console;
using System.Globalization;
using System.Collections.Generic;
class GreenvilleRevenue
{
   static void Main()
   {
      // Write your main here. 
       
      WriteLine("Enter number of contestants last year >>");
      int contestantsL = GetContestantNumber("L", 0, 30);
      
      WriteLine("Enter number of contestants this year >>");
      int contestantsT = GetContestantNumber("T", 0, 30);

      DisplayRelationship(contestantsT, contestantsL);
      string[] names = new string[contestantsT];
      char[] talents = new char[contestantsT];
      char[] talentCodes = {'S', 'D', 'M', 'O'};
      string[] talentCodesStrings = {"Singing", "Dancing", 
      "Musical Instrument", "Other"};
      int[] counts = {0,0,0,0};
      
      GetContestantData(contestantsT, names, talents, talentCodes, talentCodesStrings, counts);
      GetLists(contestantsT, talentCodes, talentCodesStrings, names, talents, counts);
  
   }
   public static int GetContestantNumber(string when, int min, int max)
  {
    // Write your GetContestantNumber() here.
    int num = int.Parse(ReadLine());
    while (num < min || num >max) {
      WriteLine("Please enter a valid number");
      num = int.Parse(ReadLine());
    }
    return num;
   }

   public static void DisplayRelationship(int numThisYear, int numLastYear)
   {
    // Write your DisplayRelationship() here.
    double fee = (double)numThisYear*25;
      //WriteLine("Last year's competition had {0} contestants and this year's has {1} contestants", numLastYear, numThisYear);
      //WriteLine("Revenue expected this year is {0}",fee.ToString("C", CultureInfo.GetCultureInfo("en-US")));
      if (2*numLastYear <  numThisYear) {
         WriteLine("The competition is more than twice as big this year!");

      } else if (numLastYear <  numThisYear){
      WriteLine("The competition is bigger than ever!");
      } else {
        WriteLine("A tighter race this year! Come out and cast your vote!");
      }   
    
   }
   public static void GetContestantData(int numThisYear, string[] names, char[] talents, char[] talentCodes, string[] talentCodesStrings, int[] counts)
   {
     // Write your GetContestantData() here.
     int x,y;
    
      for (x=0; x < numThisYear; ++x)
      {
         
         WriteLine("Enter the contestant's name >>");
         names[x] = ReadLine();

         WriteLine("Talent codes are:");
         for (y=0; y < talentCodes.Length; ++y)
         {
           WriteLine("{0}   {1}", talentCodes[y], talentCodesStrings[y]);
         }  
         
         WriteLine("Enter talent code >>");
         talents[x] = ReadLine()[0];
         while(talents[x] != talentCodes[0]  && 
         talents[x] != talentCodes[1] && 
        talents[x] != talentCodes[2] && 
        talents[x] != talentCodes[3])
          {
             WriteLine("{0} is not a valid code", talents[x]);
             WriteLine("Talent codes are:");
         for (y=0; y < talents.Length; ++y)
         {
           WriteLine("{0}   {1}", talentCodes[y], talentCodesStrings[y]);
         }  
         talents[x] = ReadLine()[0];
         }     
      }

   
      List<String> listS = new List<String>();
      List<String> listD = new List<String>();
      List<String> listM= new List<String>();
      List<String> listO = new List<String>();

      for (x=0; x < numThisYear; ++x)
      {
        switch(talents[x])
        {
           case 'S':
              counts[0]++;
              listS.Add(names[x]);
              break;
           case 'D':
              counts[1]++;
              listD.Add(names[x]);
              break;
           case 'M':
              counts[2]++;
              listM.Add(names[x]);
              break;
           case 'O':
              counts[3]++;
              listO.Add(names[x]);
              break;   
        }
      }

      WriteLine("The types of talent are:");
      WriteLine("Singing               {0}",counts[0]);
      WriteLine("Dancing               {0}",counts[1]);
      WriteLine("Musical instrument    {0}",counts[2]);
      WriteLine("Other                 {0}",counts[3]);
   }
   public static void GetLists(int numThisYear, char[] talentCodes, string[] talentCodesStrings, string[] names, char[] talents, int[] counts)
   {
      int countS=0;
      int countD=0;
      int countM=0;
      int countO=0;

      List<String> listS = new List<String>();
      List<String> listD = new List<String>();
      List<String> listM= new List<String>();
      List<String> listO = new List<String>();

      for (int x=0; x < numThisYear; ++x)
      {
        switch(talents[x])
        {
           case 'S':
              countS++;
              listS.Add(names[x]);
              break;
           case 'D':
              countD++;
              listD.Add(names[x]);
              break;
           case 'M':
              countM++;
              listM.Add(names[x]);
              break;
           case 'O':
              countO++;
              listO.Add(names[x]);
              break;   
        }
      }
     // Write your GetLists() here.
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
   }
}
