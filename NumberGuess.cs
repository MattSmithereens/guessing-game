using System;

class NumberGuess {
  private int number;

  public void setNumber() {
    Console.WriteLine("Pick a number between 1 and 100.");

    while(!int.TryParse(Console.ReadLine(), out number)) {
      Console.WriteLine("Invalid number. Please enter a new number!");
    }
  }

  public void setRandomNumber() {
    Random rand = new Random();
    Console.WriteLine("Picking number...");
    number = rand.Next(1, 100);
  }

  public int getNumber() {
    
    return number;
  }

  public bool isValidNumber() {
    bool isValid = (getNumber() % 1) == 0;

    return isValid;
  }

}

public class Game {
  NumberGuess guessNumber = new NumberGuess();
  const string INVALID_RESPONSE = "Invalid response.";

  public static void Main() {
    new Game().showMenu();
  }

  public void showMenu() {
    Console.WriteLine("Enter An Option");
    Console.WriteLine("(1) User Guesses (2) Computer Guesses");
    int choice = int.Parse(Console.ReadLine());

    if(choice == 1) {
      playUserGuess();
    } else if(choice == 2) {
      playComputerGuess();
    } else {
      Console.WriteLine("Not a valid choice!");
      showMenu();
    }
  }
  
  /*--------------------------- 
  COMPUTER GUESS FUNCTIONALITY 
  ---------------------------*/

  public void playComputerGuess() {
    guessNumber.setNumber();
    if(guessNumber.getNumber() > 100 || guessNumber.getNumber() < 1) 
    {
    Console.WriteLine("Invalid number!");
    guessNumber.setNumber();
    }
    bool gameOver = false;
    const string CORRECT = "correct";
    const string HIGHER = "higher";
    int guess = 50;
    int guessCounter = 0;

    while(!gameOver) {
      string response = makeGuess(guess);
      guessCounter++;

      if(response == INVALID_RESPONSE && guessCounter > 0) {
        guessCounter--;
      }

      if(response == CORRECT) {
        gameOver = true;
        break;
      }

      if(response == HIGHER && guessCounter == 1) {
        guess += 25;
      } else if(guessCounter == 1) {
        guess -= 25;
      }

      if(response == HIGHER && guessCounter == 2) {
        guess += 10;
      } else if(guessCounter == 2) {
        guess -= 10;
      }

      if(response == HIGHER && guessCounter == 3) {
        guess += 5;
      } else if(guessCounter == 3) {
        guess -= 5;
      }

      if(response == HIGHER && guessCounter == 4) {
        guess += 5;
      } else if(guessCounter == 4) {
        guess -= 5;
      }

      if(response == HIGHER && guessCounter == 5) {
        guess += 2;
      } else if(guessCounter == 5) {
        guess -= 2;
      }

      if(response == HIGHER && guessCounter == 6) {
        guess += 2;
      } else if(guessCounter == 6) {
        guess -= 2;
      }

      if(response == HIGHER && guessCounter == 7) {
        guess += 1;
      } else if(guessCounter == 7) {
        guess -= 1;
      }


    }

    Console.WriteLine("Your number is " + guess + "!" );
    Console.WriteLine("It took me " + guessCounter + " turns to guess your number.");
    showMenu();
  }

  public string makeGuess(int guess) {
    string response = "";

    Console.WriteLine("Please answer 'higher', 'lower', or 'correct'");
    Console.WriteLine("Is your number higher or lower than " + guess);
    response = Console.ReadLine().ToLower();
    
    if(checkResponse(response)) {
      return response;
    } else {
      return INVALID_RESPONSE;
    }

  }

  public bool checkResponse(string response) {
    bool isValid;

    if(response == "higher") {
      isValid = true;
    } else if(response == "lower") {
      isValid = true;
    } else if(response == "correct") {
      isValid = true;
    } else {
      isValid = false;
    }

    return isValid;
  }

  /*--------------------------- 
  USER GUESS FUNCTIONALITY 
  ---------------------------*/

  public void playUserGuess() {
    guessNumber.setRandomNumber();
    int guessCounter = 0;
    bool gameOver = false;
    const string CORRECT = "correct";
    const string LOWER = "lower";

    while(!gameOver) {
      int userGuess = enterUserGuess();
      string response = checkGuess(userGuess);
      guessCounter++;

      if(response == CORRECT) {
        gameOver = true;
      } else if(response == LOWER) {
        Console.WriteLine("Lower");
      } else {
        Console.WriteLine("Higher");
      }
    }

    Console.WriteLine("You win! The number was " + guessNumber.getNumber() + ".");
    Console.WriteLine("It took you " + guessCounter + " turns to guess the number.");
    showMenu();
  }

  public int enterUserGuess() {
    int guess;
    Console.WriteLine("Enter Number: ");

    while(!int.TryParse(Console.ReadLine(), out guess)) {
      Console.WriteLine("Invalid number. Please enter a new number!");
    }

    return guess;
  }

  public string checkGuess(int guess) {
    int correctGuess = guessNumber.getNumber();
    string response = "";
    
    if(guess > correctGuess) {
      
      response = "lower";
    } else if(guess < correctGuess) {

      response = "higher";
    } else if(guess == correctGuess) {

      response = "correct";
    }

    return response;
  }

}