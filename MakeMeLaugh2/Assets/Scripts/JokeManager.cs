using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JokeManager : MonoBehaviour
{
    public enum JokeType
    {
        pun,
        dark,
        gross
    }

    public List<string> jokeListString = new List<string>();
    public List<Joke> jokeList = new List<Joke>();
    public List<Joke> jokeDeck = new List<Joke>();

    private void Awake()
    {
        int i = 0;
        foreach(string j in jokeListString)
        {
            
            if(i >= 0 && i < 5)
            {
                jokeList[i].joke = j;
                jokeList[i].type = JokeType.dark;
                jokeList[i].mentalDamage = 10;
            }
            else if(i >= 5 && i < 10)
            {
                jokeList[i].joke = j;
                jokeList[i].type = JokeType.gross;
                jokeList[i].mentalDamage = 10;
            }
            else if (i >= 10 && i < 15)
            {
                jokeList[i].joke = j;
                jokeList[i].type = JokeType.pun;
                jokeList[i].mentalDamage = 10;
            }
            i++;
            //Debug.Log(i);

        }
    }
}
