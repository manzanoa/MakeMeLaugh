using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joke : MonoBehaviour 
{
    // Start is called before the first frame update
    public string joke;
    public JokeManager.JokeType type;
    public int mentalDamage;

    public Joke(string j, JokeManager.JokeType t, int md)
    {
        this.joke = j;
        this.type = t;
        this.mentalDamage = md;
    }

}
