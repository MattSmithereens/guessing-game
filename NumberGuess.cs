using System;

class NumberGuess {
  private int number;

  public void setNumber() {
    Console.WriteLine("Enter Your Number: ");
    number = int.Parse(Console.ReadLine());
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
    new Game().playGame();
  }

  public void playGame() {
    guessNumber.setNumber();
    bool gameOver = false;
    const string CORRECT = "correct";
    const string LOWER = "lower";
    const string HIGHER = "higher";
    int guess = 50;
    int guessCounter = 0;

    while(!guessNumber.isValidNumber()) {
      Console.WriteLine("Invalid number. Please enter a new number!");
      guessNumber.setNumber();
    }

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

}