using System;
using static System.Console;
using System.Globalization;
using System.Collections.Generic;
class GreenvilleRevenue
{
   static void Main()
   {
     //WriteLine("Enter number of contestants last year >>");
     // int contestantsL = getContestantNumber("last", 0, 30);
      int contestantsL = 2;
      //WriteLine("Enter number of contestants this year >>");
      int contestantsT = getContestantNumber("this", 0, 30);
       Contestant[] cont = new Contestant[contestantsT]; 
     DisplayRelationship(contestantsT, contestantsL);
    /* string[] names = new string[contestantsT];
      char[] talents = new char[contestantsT];
      char[] talentCodes = {'S', 'D', 'M', 'O'};
      string[] talentCodesStrings = {"Singing", "Dancing", 
      "Musical Instrument", "Other"}; */
      int[] counts = {0,0,0,0};
      
      
      getContestantData(contestantsT, cont, counts);
      getLists(contestantsT, cont, counts);
  
   }
   public static int getContestantNumber(string when, int min, int max)
  {
    // Write your GetContestantNumber() here.
    /*int num = int.Parse(ReadLine());
    while (num < min || num >max) {
      WriteLine("Please enter a valid number");
      num = int.Parse(ReadLine());
    }*/
    if(when == "this") {
      WriteLine("Enter number of contestants this year >>");
    } else if (when== "last") {
      WriteLine("Enter number of contestants last year >>");
    }
     int num;
    string con = ReadLine();
    while(!int.TryParse(con, out num))
    {
      WriteLine("Invalid format - entry must be a number");
      WriteLine("Please enter a valid number");
      con = ReadLine();     
   }
     
     
   while (num < min || num > max)
   {
     LimitException le = new LimitException();
     throw(le);
     WriteLine("Please enter a valid number");
     con = ReadLine();
     while(!int.TryParse(con, out num))
    {
      WriteLine("Invalid format - entry must be a number");
      WriteLine("Please enter a valid number");
      con = ReadLine();     
   }

   }
    return num;
   }

   public static void DisplayRelationship(int numThisYear, int numLastYear)
   {
    // Write your DisplayRelationship() here.
    double fee = (double)numThisYear*25;
      //WriteLine("Last year's competition had {0} contestants and this year's has {1} contestants", numLastYear, numThisYear);
      WriteLine("Revenue expected this year is {0}",fee.ToString("C", CultureInfo.GetCultureInfo("en-US")));
      if (2*numLastYear <  numThisYear) {
         WriteLine("The competition is more than twice as big this year!");

      } else if (numLastYear <  numThisYear){
      WriteLine("The competition is bigger than ever!");
      } else {
        WriteLine("A tighter race this year! Come out and cast your vote!");
      }   
    
   }
   public static void getContestantData(int numThisYear, Contestant[] cont, int[] counts)
   {
     // Write your GetContestantData() here.
     int x;
     string name;
     int revenue = 0;
    
      for (x=0; x < numThisYear; ++x)
      {
         
         WriteLine("Enter the contestant's name >>");
        // names[x] = ReadLine();
        
         name = ReadLine();
         
         WriteLine("Talent codes are:");
         for (int y=0; y < Contestant.talentCodes.Length; ++y)
         {
           WriteLine("{0} {1}", Contestant.talentCodes[y], Contestant.talentStrings[y]);
         }  

         WriteLine("Enter talent code >>");
         string t = ReadLine();
         char tlc;
      
         while(!char.TryParse(t, out tlc))
         {
            
           WriteLine("Invalid format - entry must be a single character.");
           WriteLine("Enter talent code in con1>>");
           t = ReadLine();
         }
        //cont[x].TalentCode = tlc;
        
       while(tlc != Contestant.talentCodes[0]  && 
         tlc != Contestant.talentCodes[1] && 
        tlc != Contestant.talentCodes[2] && 
        tlc != Contestant.talentCodes[3])
          {
             talentException te = new talentException(tlc);
            throw(te);
             WriteLine("{0} is not a valid code in contestant", t);
          WriteLine("Enter talent code in con 2>>");  
          t = ReadLine();
          while(!char.TryParse(t, out tlc))
         {
           WriteLine("Invalid format - entry must be a single character.");
           WriteLine("Enter talent code in con1>>");
           t = ReadLine();
         }
         
         }    
         // talents[x] = tlc;
          //cont[x].TalentCode = tlc;

      WriteLine("Enter age >>");
         string a = ReadLine();
         int age;
      
         while(!int.TryParse(a, out age))
         {
           WriteLine("Invalid format - entry must be integer.");
           WriteLine("Enter age>>");
           a = ReadLine();
         }
         if (age <= 12)
         {
            cont[x] = new ChildContestant();
            
         } else if (age >= 13 && age <=17)
         {
            cont[x] = new TeenContestant();
            
         } else 
         {
            cont[x] = new AdultContestant();
         }

            cont[x].Name = name;
            cont[x].TalentCode = tlc;
            revenue += cont[x].Fee;
      }

      List<String> listS = new List<String>();
      List<String> listD = new List<String>();
      List<String> listM= new List<String>();
      List<String> listO = new List<String>();

      for (x=0; x < numThisYear; ++x)
      {
        switch(cont[x].TalentCode)
        {
           case 'S':
              counts[0]++;
              listS.Add(cont[x].Name);
              break;
           case 'D':
              counts[1]++;
              listD.Add(cont[x].Name);
              break;
           case 'M':
              counts[2]++;
              listM.Add(cont[x].Name);
              break;
           case 'O':
              counts[3]++;
              listO.Add(cont[x].Name);
              break;   
        }
        
      }

      WriteLine("The types of talent are:");
      WriteLine("Singing               {0}",counts[0]);
      WriteLine("Dancing               {0}",counts[1]);
      WriteLine("Musical instrument    {0}",counts[2]);
      WriteLine("Other                 {0}",counts[3]);

       WriteLine("Revenue expected this year is {0}",revenue.ToString("C", CultureInfo.GetCultureInfo("en-US")));
   }
   public static void getLists(int numThisYear, Contestant[] cont, int[] counts)
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
        switch(cont[x].TalentCode)
        {
           case 'S':
              countS++;
              listS.Add(cont[x].ToString());
              break;
           case 'D':
              countD++;
              listD.Add(cont[x].ToString());
              break;
           case 'M':
              countM++;
              listM.Add(cont[x].ToString());
              break;
           case 'O':
              countO++;
              listO.Add(cont[x].ToString());
              break;   
        }
      }
     // Write your GetLists() here.
     WriteLine("Enter talent code >>");
     string tC = ReadLine();
     char talentCode;
      while(!char.TryParse(tC, out talentCode))
     {
      WriteLine("Invalid format - entry must be a char");
      WriteLine("Please enter a valid char");
      tC = ReadLine();     
     }
      
      while (!talentCode.Equals('Z'))
      {
       
       switch(talentCode)
       {
        case 'S':
        WriteLine("Contestants with talent Singing are:");
        foreach(string one in listS)
         WriteLine(one);
         break;
         case 'D':
        WriteLine("Contestants with talent Dancing are:");
        foreach(string one in listD)
         WriteLine(one);
         break;
         case 'M':
        WriteLine("Contestants with talent Musical instrument are:");
        foreach(string one in listM)
         WriteLine(one);
         break;
         case 'O':
        WriteLine("Contestants with talent Other are:");
        foreach(string one in listO)
         WriteLine(one);
         break;
         
        default:
          talent2Exception te2 = new talent2Exception(talentCode);
          throw(te2);
          WriteLine("{0} is not a valid code in lists", talentCode);
          break;
        }

        WriteLine("Enter talent code in list 3>>");
        tC = ReadLine();
        while(!char.TryParse(tC, out talentCode))
     {
      WriteLine("Invalid format - entry must be a char");
      WriteLine("Please enter a valid char");
      tC = ReadLine();     
     }
    } 
   
   }
}

class Contestant
{
  public static char[] talentCodes = {'S', 'D', 'M', 'O'};
  public static string[] talentStrings = {"Singing", "Dancing", "Musical instrument", "Other"};
 public string Name {get; set;}
 private char talentCode;
 private string talent;
 public char TalentCode { 
   get{
   return talentCode;
   } 
 set
  {
    switch(value)
       {
        case 'S':
         talentCode = 'S';
         talent = "Singing";
         break;
         case  'D':
         talentCode = 'D';
         talent = "Dancing";
         break;
         case 'M':
         talentCode = 'M';
         talent = "Musical instrument";  
         break;
         case 'O':
         talentCode = 'O';
         talent = "Other";
          break;
         
        default:
         talentCode = 'I';
         talent = "Invalid";
         break;
  
        } 
  }
 }
 public string Talent
{
   get
   {
      return talent;
   }
}

public int Fee {get; set;}
public string Type {get; set;}


}

class ChildContestant : Contestant
{
  public ChildContestant()
  {
    Fee = 15;
    Type = "child";
  }

  public override string ToString()
  {
    return("Child Contestant " + Name + " " + TalentCode + "   Fee "+ Fee.ToString("C", CultureInfo.GetCultureInfo("en-US")));

  }
}

class TeenContestant : Contestant
{
    public TeenContestant()
  {
    Fee = 20;
    Type = "teen";
  }
   
  public override string ToString()
  {
    return("Teen Contestant " + Name + " " + TalentCode + "   Fee "+ Fee.ToString("C", CultureInfo.GetCultureInfo("en-US")));

  }
}

class AdultContestant : Contestant
{
     public AdultContestant()
  {
    Fee = 30;
    Type = "adult";
  }
   public override string ToString()
  {
    return("Adult Contestant " + Name + " " + TalentCode + "   Fee "+ Fee.ToString("C", CultureInfo.GetCultureInfo("en-US")));

  }
}

class LimitException : Exception
{
  private static string msg = "Number must be between 0 and 30";
  public LimitException() : base(msg)
  {}

}

class talentException : Exception
{
  
  private static string msg = " is not a valid talent code. Assigned as Invalid.";
  public talentException(char c) : base(c + msg)
  {}

}

class talent2Exception : Exception
{
  
  private static string msg =" is not a valid talent code. Assigned as Invalid.";
  public talent2Exception(char c) : base(c + msg)
  {}

}


