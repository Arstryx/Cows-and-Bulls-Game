// Arsenii Zakharenko aka arstryx

using System;

class MainClass 
{
  static int Main() 
  {
      
    // By default, the length of the guessed number is 4.
    int number_length = 4;
    
    // We need the number to be represented as an array 
    // so that we can interact with each digit separately.
    int[] number = new int[number_length];
    
    // Defining random numbers generator.
    var random = new System.Random();
    
    // Not only do we have to generate a number randomly, 
    // but we also have to make sure that the digits in it are not repeated.
    for(int i = 0; i < number_length; i++)
    {
        bool digitsDifferent = false;
        while(!digitsDifferent)
        {
            number[i] = random.Next(0, 10);
            // Ignore for the first digit.
            if(i==0)
            {
                break;
            }
            // When creating a new digit, 
            // this loop will check to see if it matches one of the past digits, 
            // and if it does, it will recreate it until it is not repeated.
            for(int j = 0; j < i; j++)
            {
                if(number[i] == number[j])
                {
                    break;
                }
                else if(j+1 == i)
                {
                    digitsDifferent = true;
                }
            }
        }
        
        
       // Console.WriteLine("{0}", number[i]);
    }
    
    Console.WriteLine("Try to guess the number!");
    Console.WriteLine();
    
    
    
    int turns = 0;
    
    // The game will continue unless the win or error.
    while(true)
    {
        Console.Write("{0}: ", turns+1);
        int cows = 0;
        int bulls = 0;
        string attempt = Console.ReadLine();
        
        // Any number we enter must be the same length as number we want to guess.
        if(attempt.Length != number_length)
        {
            Console.WriteLine("Not possible number!");
            return 1;
        }
        
        turns++;
        
        // Here we compare number the player entered with
        // the number our code generated.
        for(int i = 0; i < number_length; i++)
        {
            for(int j = 0; j < number_length; j++)
            {
                if(Char.GetNumericValue(attempt[i]) == number[j])
                {
                    // If 1 digit is in both numbers but in different positions, 
                    // it is a cow. If both positions are the same, it is a bull.  
                    if(i == j) bulls++;
                    else cows++;
                }
            }
        }
        
        
      
        
        // Tell the player the results of his attempt.
        Console.WriteLine("   Cows: {0}", cows);
        Console.WriteLine("   Bulls: {0}", bulls);
        Console.WriteLine();
        
          // Win.
        if(bulls == number_length)
        {
            Console.WriteLine();
            Console.WriteLine("You won!");
            Console.WriteLine("It took you {0} turns!", turns);
            return 0;
        }
        
        
    }
  }
}
