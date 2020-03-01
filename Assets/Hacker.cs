using UnityEngine;

public class Hacker : MonoBehaviour
{
    //Game Config Data
    const string menuHint = "For Main Menu, type menu anywhere";
    string[] l1pass = { "hold", "men", "word", "password", "tree", "drive" };
    string[] l2pass = { "harrased", "mentioned", "information", "governor", "leeward", "properties" };
    string[] l3pass = { "worcestershire", "anemone", "isthmus", "bye69", "hello123", "pseudonym" };
    const int lives = 3;
    //Game Start
    int level;
    string password;
    enum Screen { MainMenu, Password, Win };
    Screen currentScreen;

    // Start is called before the first frame update
    void Start()
    {
        var n = "HackerMan";
        ShowMainMenu(n);
    } 
    void ShowMainMenu(string name)
    {
       currentScreen = Screen.MainMenu;
       Terminal.ClearScreen();
       Terminal.WriteLine("     -----Welcome to Hackergram-----") ;
       Terminal.WriteLine("\nWhat do you want to hack into ?") ;
       Terminal.WriteLine("1.Hack into your Crush's Iphone") ;
       Terminal.WriteLine("2.Hack into Air Traffic Control") ;
       Terminal.WriteLine("3.Infiltrate inside CIA Secure Facility") ;
       Terminal.WriteLine("\nWhich one it's gonna be "+name+" :");   
    }
    void OnUserInput(string input)
    {
        if(input.ToLower() == "menu")
            Start();
        else if(input.ToLower() == "quit" || input.ToLower() == "close" || input.ToLower() == "exit" || input.ToLower() == "terminate")
        {
            Terminal.ClearScreen();
            Terminal.WriteLine("You've now exited the game.\nYou may close the tab");
            Application.Quit();  
		}
        else if(currentScreen == Screen.MainMenu)
           RunMainMenu(input);
        else if(currentScreen == Screen.Password)
           CheckPassword(input);
    }
    void RunMainMenu(string input)
    {
        bool isValidLevel = (input == "1" || input == "2" || input == "3");
        if(isValidLevel)
        {
            level = int.Parse(input);
            AskForPassword();
        }
        else if(input == "007")
            Terminal.WriteLine("Choose a level Mr.Bond");
        else if(input == "69")
            Terminal.WriteLine("Choose a level Johnny Sins");
        else
            Terminal.WriteLine("Please a Choose a correct level\n"+menuHint);
	}
    void AskForPassword()
    {
        SetRandomPassword();
        Terminal.ClearScreen();
        Terminal.WriteLine("To hack Enter the password :\nHint: "+password.Anagram());
        Terminal.WriteLine(menuHint);
        currentScreen = Screen.Password;
	}
    void SetRandomPassword()
    {
        int index = Random.Range(0,6);
        switch(level)
        {
            case 1 :    password = l1pass[index];
                        break;
            case 2 :    password = l2pass[index];
                        break;
            case 3 :    password = l3pass[index];
                        break;
            default:    Debug.LogError("Invalid level");
                        break;
		}
    }
    void CheckPassword(string input)
    {
        if( input == password)
            DisplayWinScreen();
        else
        {
            AskForPassword(); 
            Terminal.WriteLine("F.A.I.L.");
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
            case 1: Terminal.WriteLine(@"You've entered your crush's iphone 
`   `:+oooo+:`    ``   `-/////:-`    
  `/sosos+-oso:`     `:+//+++++++:   
 `ossosss/ +sso+`   `/+/::/++:-:++/` 
 /oososs: `ososs/   /+/`   ..   `/+- 
`+oo-.-+     `os+` `++:          o+/ 
`oso` `+     `syo```+++.   ``   :so: 
 +so` `+     .yy+   /++/.      -yo+: 
 .oo--/s:::::+yo`   .++/+/.  .osoo+` 
  `+syyyyyyssyo`     `/+++ooosooo/`");
                    Terminal.WriteLine(menuHint);
                     break;
            case 2 : Terminal.WriteLine(@"You control the airspace now 
                 `:++/         `-::  
              `./+++/          -::-  
            `-/++++/`         -:::-  
     ````.--://////-----------::::.  
  `.--::::::///////::::-----:/++/.   
      ````...-+++++/````      ./+-   
              `-++++:           ``   
                `-/++-               
                  `-//`");
                    Terminal.WriteLine(menuHint);
                    break;
            case 3 :    Terminal.WriteLine(@"You're inside the CIA mainframe network
 _                _            _ 
| |              | |          | |
| |__   __ _  ___| | _____  __| |
| '_ \ / _` |/ __| |/ / _ \/ _` |
| | | | (_| | (__|   <  __/ (_| |
|_| |_|\__,_|\___|_|\_\___|\__,_|");
                        Terminal.WriteLine(menuHint);
                        break;
            default : Debug.LogError("Invalid level reached");
                      break;
		}
	}
}
