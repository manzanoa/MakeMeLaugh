using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JokeManager : MonoBehaviour
{
    public enum JokeType
    {
        pun,
        dark,
        nsfw,
        dad,
        corny,
        math
    }

    public List<Joke> jokeList;
    public List<Joke> jokeDeck;
}
