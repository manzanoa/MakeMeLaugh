using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Competitors
{
    public void AddJoke(Joke joke)
    {
        jokeList.Add(joke);
    }
}
