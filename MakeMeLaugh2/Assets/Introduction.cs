using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Introduction : MonoBehaviour
{
    public Player player;
    public GameObject intro;
    public Text text;
    public GameObject options;
    public GameObject darkButton, grossButton, punButton;
    public TurnBasedBattleMechanics game;
    public Competitors competitors;

    private int i = 1;

    private void Start()
    {
        StartCoroutine(Intro());
    }

    IEnumerator Intro()
    {

        yield return new WaitForSeconds(5);

        text.text = "But remember that everyone has a different sense of humor. Not everyone will like the jokes you think are funny. You need to make sure to go for each person's funny bone.";

        yield return new WaitForSeconds(5);

        text.text = "Before we start, lets get to know more about you.";

        yield return new WaitForSeconds(5);

        text.text = "What type of humor would you say you have?";
        options.SetActive(true);


    }

    

    public void Response(int x)
    {
        JokeManager.JokeType jt;
        if (x == 0)
        {
            jt = JokeManager.JokeType.dark;
        }
        else if (x == 1)
        {
            jt = JokeManager.JokeType.gross;
        }
        else 
        {
            jt = JokeManager.JokeType.pun;
        }

        

        if (i == 1)
        {
            player.setWeakness(jt);
            if(x == 0)
            {
                darkButton.SetActive(false);
                
            }
            else if (x == 1)
            {
                grossButton.SetActive(false);
            }
            else if (x == 2)
            {
                punButton.SetActive(false);
            }
            text.text = "What do you find not funny?";
        }
        else if(i == 2)
        {
            player.setNotFunny(jt);
            darkButton.SetActive(true);
            grossButton.SetActive(true);
            punButton.SetActive(true);
            text.text = "What type of joke would you say you are the best at telling?";
        }
        else if(i == 3)
        {
            player.setSpecialty(jt);
            options.SetActive(false);
            StartCoroutine(StartGame());
        }
        i++;
    }

    IEnumerator StartGame()
    {
        text.text = "Great! You are now ready to start.";

        yield return new WaitForSeconds(5);

        text.text = "You will now go through 3 matches against 3 different people with different taste in humor.";

        yield return new WaitForSeconds(5);

        text.text = "Good luck and make them laugh!";

        yield return new WaitForSeconds(5);

        
        options.SetActive(false);
        
        intro.SetActive(false);

        game.StartBattle(competitors);


    }
}
