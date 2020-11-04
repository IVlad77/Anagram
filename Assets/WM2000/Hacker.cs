using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;

public class Hacker : MonoBehaviour
{

    string[] level1Passwords = { "books", "aisle", "shelf", "password", "font", "borrow" };
    string[] level2Passwords = { "prisoner", "handcuffs", "holster", "uniform", "arrest" };
    string[] level3Passwords = { "prisoner", "handcuffs", "holster", "uniform", "arrest" };

    int level;
    string password;

    enum Screen { MainMenu, Password, Win };

    Screen currentScreen;

    private void Start()
    {

        ShowMainMenu();

    }

    void ShowMainMenu()
    {
        currentScreen = Screen.MainMenu;
        Terminal.WriteLine("Yo playa");
        Terminal.WriteLine("Choose hacking domain");
        Terminal.WriteLine("Press 1 for Mega Image");
        Terminal.WriteLine("Press 2 for Carrefour");
        Terminal.WriteLine("Press 3 for Cora");
    }

    void OnUserInput (string input)
    {
        if(input == "menu")
        {
            Terminal.ClearScreen();
            ShowMainMenu();
            
        }
        else if(currentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        }
        else if(currentScreen == Screen.Password)
        {
            RunPasswordMenu(input);
        }
        
    }
    void RunMainMenu(string input)
    {
        bool isValidLevelNumber = (input == "1" || input == "2" || input == "3");
        if(isValidLevelNumber)
        {
            level = int.Parse(input);
            AskForPassword();
        }
        else
        {
            Terminal.WriteLine("Wrong input");
        }
    }
    void AskForPassword()
    {
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        Terminal.WriteLine("Type menu to return to main menu");
        SetRandomPassword();
        Terminal.WriteLine("Input the password, hint: " + password.Anagram());
    }
    void SetRandomPassword()
    {
        switch (level)
        {
            case 1:
                password = level1Passwords[Random.Range(0, level1Passwords.Length)];
                break;
            case 2:
                password = level2Passwords[Random.Range(0, level2Passwords.Length)];
                break;
            case 3:
                password = level3Passwords[Random.Range(0, level3Passwords.Length)];
                break;
            default:
                Debug.LogError("Invalid");
                break;
        }
    }

    void RunPasswordMenu(string input)
    {
        if(input == password)
        {
            DisplayWinScreen();
        }
        else
        {
            AskForPassword();
        }
    }

    void DisplayWinScreen()
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        ShowLevelReward();

    }

    void ShowLevelReward()
    {
        switch(level)
        {
            case 1:
                Terminal.WriteLine("Have a penguin");
                Terminal.WriteLine(@"
       .---.
      /     \
      \.@-@./
      /`\_/`\
     //  _  \\
    | \     )|_
   /`\_`>  <_/ \
jgs\__/'---'\__/
"
                );
                break;

            case 2:
                Terminal.WriteLine("Have a football");
                Terminal.WriteLine(@"
          ___
      _.-'___'-._
    .'--.`   `.--'.
   /.'   \   /   `.\
  | /'-._/```\_.-'\ |
  |/    |     |    \|
  | \ .''-._.-''. / |
   \ |     |     | /
    '.'._.-'-._.'.'
jgs   '-:_____;-'



"
                );
                break;
            case 3:
                Terminal.WriteLine("Have nothing");
                Terminal.WriteLine(" ");
                break;
            default:
                Debug.Log("Invalid");
                break;
        }
    } 


}
