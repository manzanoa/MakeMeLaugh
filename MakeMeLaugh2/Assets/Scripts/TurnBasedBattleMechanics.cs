using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnBasedBattleMechanics : MonoBehaviour
{
    [SerializeField]
    private Player player;

    [SerializeField]
    private Competitors opponent;

    private bool choiceMade = false;

    private bool saidJoke = false;

    private int choice;

    [SerializeField]
    private Image gothGirl;

    [SerializeField]
    private Joke prevJoke;

    [SerializeField]
    private Image playerFill, opponentFill;

    [SerializeField]
    List<Joke> pJokeList = new List<Joke>(), oJokeList = new List<Joke>();

    [SerializeField]
    List<Joke> pJokeHand = new List<Joke>(), oJokeHand = new List<Joke>();

    [SerializeField]
    private GameObject jokeMenu1, jokeMenu2, textBoxGO;

    [SerializeField]
    private Text playerName, opponentName, textBoxName, textBox;

    [SerializeField]
    private List<Text> playerJokeCards = new List<Text>();

    [SerializeField]
    private Slider playerMFBar, opponentMFBar;

    [SerializeField]
    private Sprite neutral, laughing, half, tell, serious;

<<<<<<< Updated upstream
    public Sprite[] gothSprites, clownSprites, fbiSprites;

    private int round = 1;

    private void Start()
    {
        //StartBattle(opponent);
    }
    public void StartBattle(Competitors opponent)
=======
    [SerializeField]
    private Text introText;

    [SerializeField]
    private Button darkButton, grossButton, punButton;

    [SerializeField]
    private GameObject introGO;

    private int settingsettings = 0;

    private void Start()
    {
        darkButton.gameObject.SetActive(false);
        grossButton.gameObject.SetActive(false);
        punButton.gameObject.SetActive(false);
        //StartBattle(opponent);
        StartCoroutine(Intro());
    }

    private IEnumerator Intro()
    {
        string s = "Welcome to Make Me Laugh!";
        foreach(char c in s)
        {
            introText.text = introText.text + c;
            yield return new WaitForSeconds(.1f);
        }
        yield return new WaitForSeconds(.5f);

        introText.text = "";
        s = "In this game, you and your opponent will go one on one telling jokes to make the other laugh.";
        foreach (char c in s)
        {
            introText.text = introText.text + c;
            yield return new WaitForSeconds(.1f);
        }

        yield return new WaitForSeconds(.5f);

        introText.text = "";
        s = "Know that some people enjoy certain types of jokes while others don't find them funny.";
        foreach (char c in s)
        {
            introText.text = introText.text + c;
            yield return new WaitForSeconds(.1f);
        }

        yield return new WaitForSeconds(.5f);

        introText.text = "";
        s = "Learn your opponents, and hit them right in their funny bone!";
        foreach (char c in s)
        {
            introText.text = introText.text + c;
            yield return new WaitForSeconds(.1f);
        }

        yield return new WaitForSeconds(.5f);

        introText.text = "";
        s = "But before we start, we will need you to answer some questions for us.";
        foreach (char c in s)
        {
            introText.text = introText.text + c;
            yield return new WaitForSeconds(.1f);
        }

        introText.text = "";
        s = "First, out of the three what is your favorite type of joke?";
        foreach (char c in s)
        {
            introText.text = introText.text + c;
            yield return new WaitForSeconds(.1f);
        }

        darkButton.gameObject.SetActive(true);
        grossButton.gameObject.SetActive(true);
        punButton.gameObject.SetActive(true);

    }

    public void ChooseSettings(string weakness)
    {
        if(settingsettings == 0)
        {
            if (weakness == "Dark")
            {
                player.setWeakness(JokeManager.JokeType.dark);
                darkButton.gameObject.SetActive(false);
            }
            else if (weakness == "Dirty")
            {
                player.setWeakness(JokeManager.JokeType.gross);
                grossButton.gameObject.SetActive(false);
            }
            else if (weakness == "Pun")
            {
                player.setWeakness(JokeManager.JokeType.pun);
                punButton.gameObject.SetActive(false);
            }
            settingsettings = 1;
            StartCoroutine(ChooseNotFunny());
        }
        else if(settingsettings == 1)
        {
            if (weakness == "Dark")
            {
                player.setNotFunny(JokeManager.JokeType.dark);
            }
            else if (weakness == "Dirty")
            {
                player.setNotFunny(JokeManager.JokeType.gross);
            }
            else if (weakness == "Pun")
            {
                player.setNotFunny(JokeManager.JokeType.pun);
            }
            darkButton.gameObject.SetActive(true);
            grossButton.gameObject.SetActive(true);
            punButton.gameObject.SetActive(true);
            settingsettings = 2;
            StartCoroutine(ChooseSpecialty());

        }
        else if(settingsettings == 2)
        {
            if (weakness == "Dark")
            {
                player.setSpecialty(JokeManager.JokeType.dark);
            }
            else if (weakness == "Dirty")
            {
                player.setSpecialty(JokeManager.JokeType.gross);
            }
            else if (weakness == "Pun")
            {
                player.setSpecialty(JokeManager.JokeType.pun);
            }
            darkButton.gameObject.SetActive(false);
            grossButton.gameObject.SetActive(false);
            punButton.gameObject.SetActive(false);
            settingsettings = 3;
            StartCoroutine(EndOfIntro());
        }
    }

    private IEnumerator EndOfIntro()
    {
        introText.text = "";
        string s = "Thank you! And with that the questions are over!";
        foreach (char c in s)
        {
            introText.text = introText.text + c;
            yield return new WaitForSeconds(.1f);
        }
        yield return new WaitForSeconds(.5f);

        introText.text = "";
        s = "It is now time to begin the game. Make people laugh before they make you laugh.";
        foreach (char c in s)
        {
            introText.text = introText.text + c;
            yield return new WaitForSeconds(.1f);
        }
        yield return new WaitForSeconds(.5f);

        s = "Good luck!";
        foreach (char c in s)
        {
            introText.text = introText.text + c;
            yield return new WaitForSeconds(.1f);
        }
        yield return new WaitForSeconds(.1f);

        StartBattle(opponent);
    }
    private IEnumerator ChooseNotFunny()
    {
        introText.text = "";
        string s = "What is you least favorite type of joke?";
        foreach (char c in s)
        {
            introText.text = introText.text + c;
            yield return new WaitForSeconds(.1f);
        }
    }

    private IEnumerator ChooseSpecialty()
    {
        introText.text = "";
        string s = "What type of jokes are your specialty?";
        foreach (char c in s)
        {
            introText.text = introText.text + c;
            yield return new WaitForSeconds(.1f);
        }
    }
    private void StartBattle(Competitors opponent)
>>>>>>> Stashed changes
    {
        introGO.SetActive(false);
        this.opponent = opponent;
        pJokeList = player.getJokeDeck();
        oJokeList = opponent.getJokeDeck();
        playerName.text = player.getName();
        opponentName.text = opponent.getName();

        for (int i = 0; i < 5; i++)
        {
            pJokeHand[i].joke = pJokeList[i].joke;
            pJokeHand[i].type = pJokeList[i].type;
            pJokeHand[i].mentalDamage = pJokeList[i].mentalDamage;
            playerJokeCards[i].text = pJokeHand[i].joke;
            oJokeHand[i].joke = oJokeList[i].joke;
            oJokeHand[i].type = oJokeList[i].type;
            oJokeHand[i].mentalDamage = oJokeList[i].mentalDamage;
        }

        textBoxName.text = "";
        textBox.text = "Match " + round.ToString() + "!";
        textBoxGO.SetActive(true);

        int first = Random.Range(0, 2);
        if(first == 0)
        {
            
            

            
            StartCoroutine(PlayerTurn());
        }
        else
        {
            StartCoroutine(EnemyTurn());
        }
    }

    public void setChoiceMade()
    {
        choiceMade = !choiceMade;
    }

    IEnumerator PlayerTurn()
    {
        gothGirl.sprite = neutral;
        yield return new WaitForSeconds(5f);
        textBoxName.text = "";
        textBox.text = player.getName() + " will start first!";

        yield return new WaitForSeconds(5f);

        textBoxGO.SetActive(false);
        choiceMade = false;
        player.NotGuarding();
        for (int i = 0; i < 5; i++)
        {
            pJokeHand[i] = pJokeList[i];
            /*pJokeHand[i].type = pJokeList[i].type;
            pJokeHand[i].mentalDamage = pJokeList[i].mentalDamage;*/
            playerJokeCards[i].text = pJokeList[i].joke;
        }

        //do stuff
        jokeMenu1.SetActive(true);
        //chose the option
        while(!choiceMade)
        {
            yield return null;
        }

        if(player.getGuarding())
        {
            //player use guard
            textBoxName.text = "";
            textBox.text = player.getName() + " steels themselves for a joke!";
            textBoxGO.SetActive(true);
            yield return new WaitForSeconds(5f);
        }
        else if(saidJoke)
        {
            //player uses joke
            textBoxName.text = player.getName();
            textBox.text = playerJokeCards[choice].text;
            textBoxGO.SetActive(true);

            //wait a few seconds
            yield return new WaitForSeconds(5f);

            //joke was in/effective
            if (pJokeHand[choice].type == opponent.getWeakness())
            {
                textBoxName.text = "";
                gothGirl.sprite = serious;
                textBox.text = opponent.getName() + " is struggling to keep their composure!";
            }
            else if (pJokeHand[choice].type == opponent.getNotFunny())
            {
                textBoxName.text = "";
                gothGirl.sprite = tell;
                textBox.text = opponent.getName() + " is barely fazed!";
            }
            else
            {
                textBoxName.text = "";
                gothGirl.sprite = half;
                textBox.text = "You got a reaction out of " + opponent.getName() + ".";
            }
            //opponent takes damage

            opponent.takeMFDamage(pJokeHand[choice], prevJoke, player.getSpecialty());
            

            prevJoke = pJokeHand[choice];
            player.setPrevJoke(pJokeHand[choice]);

            //something wrong here
            pJokeList.RemoveAt(choice);
            pJokeList.Insert(pJokeList.Count - 1, prevJoke);
            

            for (int i = 0; i < 5; i++)
            {
                pJokeHand[i].joke = pJokeList[i].joke;
                pJokeHand[i].type = pJokeList[i].type;
                pJokeHand[i].mentalDamage = pJokeList[i].mentalDamage;
                playerJokeCards[i].text = pJokeHand[i].joke;
            }




            //saving the previous joke


            for (int i = 0; i < 5; i++)
            {
                pJokeHand[i] = pJokeList[i];
            }

            playerMFBar.value = player.getMF();
            opponentMFBar.value = opponent.getMF();

            yield return new WaitForSeconds(5f);

        }
        
        
        
        //complete the option
        if(!opponent.getLaughed())
        {
            textBoxGO.SetActive(false);
            
            StartCoroutine(EnemyTurn());
        }
        else
        {
            //win scenario
            textBoxGO.SetActive(true);
            gothGirl.sprite = laughing;
            textBoxName.text = "";
            textBox.text = "You made " + opponent.getName() + " laugh! \n YOU WIN!";

            //move on to the next battle
        }
    }

    public void ToJokeMenu2()
    {
        jokeMenu1.SetActive(false);
        jokeMenu2.SetActive(true);
    }

    public void ToJokeMenu1()
    {
        jokeMenu1.SetActive(true);
        jokeMenu2.SetActive(false);
    }

    public void Guard()
    {
        player.Guard();
        choiceMade = true;
        player.Shuffle();
        jokeMenu2.SetActive(false);
        for (int i = 0; i < 5; i++)
        {
            pJokeHand[i].joke = pJokeList[i].joke;
            pJokeHand[i].type = pJokeList[i].type;
            pJokeHand[i].mentalDamage = pJokeList[i].mentalDamage;
            playerJokeCards[i].text = pJokeHand[i].joke;
        }
        textBoxGO.SetActive(true);
    }

    public void SelectJoke(int num)
    {
        saidJoke = true;
        choiceMade = true;
        choice = num;

        jokeMenu2.SetActive(false);
        textBoxGO.SetActive(true);

    }

    IEnumerator EnemyTurn()
    {
        yield return new WaitForSeconds(5f);

        textBoxGO.SetActive(false);
        gothGirl.sprite = neutral;

        //set opponent to not guarding
        opponent.NotGuarding();

        //reveal opponent's turn
        textBoxGO.SetActive(true);
        textBoxName.text = "";
        textBox.text = "It is now " + opponent.getName() + "'s turn!";

        yield return new WaitForSeconds(5f);

        //what to say when player guards
        if (player.getGuarding())
        {
            textBoxName.text = "";
            textBox.text = player.getName() + " braced themselves!";
        }

        //ai choses action based on what it knows random number
        int num = Random.Range(0, 4);

        gothGirl.sprite = tell;
        textBoxName.text = opponent.getName();
        textBox.text = oJokeHand[num].joke;

        yield return new WaitForSeconds(5f);

        gothGirl.sprite = neutral;
        //what to do depending on variables
        if (oJokeHand[num].type == player.getWeakness())
        {
            textBoxName.text = "";
            textBox.text = player.getName() + " is struggling to keep their composure!";
        }
        else if (oJokeHand[num].type == player.getNotFunny())
        {
            textBoxName.text = "";
            textBox.text = player.getName() + " is barely fazed!";
        }
        else
        {
            textBoxName.text = "";
            if (player.getGuarding())
            {
                textBox.text = player.getName() + " kept a strong poker face!";
            }
            else
            {
                textBox.text = opponent.getName() + " got a reaction out of you!";
            }
        }

        //calculate damage
        player.takeMFDamage(oJokeHand[num], prevJoke, opponent.getSpecialty());

        
        //update health bars
        playerMFBar.value = player.getMF();
        opponentMFBar.value = opponent.getMF();

        //saving the prev joke 
        prevJoke = oJokeHand[num];
        opponent.setPrevJoke(prevJoke);

        //updateing the list of opponent's jokes
        oJokeList.RemoveAt(num);
        oJokeList.Insert(oJokeList.Count - 1, prevJoke);

        //upodate the list availabe to the opponent
        for (int i = 0; i < 5; i++)
        {
            oJokeHand[i].joke = oJokeList[i].joke;
            oJokeHand[i].type = oJokeList[i].type;
            oJokeHand[i].mentalDamage = oJokeList[i].mentalDamage;

            Debug.Log(oJokeHand[i].joke);
            Debug.Log(oJokeHand[i].type);
        }



        //perform actions it chose
        if (!player.getLaughed())
        {
            
            StartCoroutine(PlayerTurn());
        }
        else
        {
            textBoxGO.SetActive(true);
            textBoxName.text = "";
            textBox.text = opponent.getName() + " has made you laugh! \n YOU LOSE!";
        }
    }

    public void ChangeOpponentBarColor()
    {
        //TODO later change sprite
        if (opponent.getMF() >= opponent.getMaxMF() / 4)
        {
            opponentFill.color = Color.red;
        }

    }
    public void ChangePlayerBarColor()
    {
        //TODO later add laughter
        if (player.getMF() >= player.getMaxMF() / 4)
        {
            playerFill.color = Color.red;
        }

    }

}
