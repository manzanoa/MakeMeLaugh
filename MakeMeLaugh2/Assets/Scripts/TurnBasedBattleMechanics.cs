using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnBasedBattleMechanics : MonoBehaviour
{
    [SerializeField]
    private Player player;

    private Competitors opponent;

    private bool choiceMade = false;

    private bool saidJoke = false;

    [SerializeField]
    private GameObject jokeMenu1, jokeMenu2;
    private void StartBattle(Competitors opponent)
    {
        this.opponent = opponent;

        int first = Random.Range(0, 1);
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
        }
        else if(saidJoke)
        {
            //player uses joke
            //wait a few seconds
            //joke was in/effective
            //opponent takes damage
        }
        
        
        yield return null;
        
        //complete the option
        if(!opponent.getLaughed())
        {
            StartCoroutine(EnemyTurn());
        }
        else
        {
            //win scenario
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
    }

    public void SelectJoke(Joke joke)
    {
        saidJoke = true;
        choiceMade = true;
    }

    IEnumerator EnemyTurn()
    {
        //do stuff
        //ai choses action based on what it knows
        yield return null;
        //perform actions it chose
        if (!player.getLaughed())
        {
            StartCoroutine(EnemyTurn());
        }
    }
}
