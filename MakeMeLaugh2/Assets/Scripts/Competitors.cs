using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Competitors : MonoBehaviour
{
    [SerializeField]
    protected string nametag;
    [SerializeField]
    protected int maxMentalFortitude;
    [SerializeField]
    protected int mentalFortitude;

    [SerializeField]
    protected JokeManager.JokeType weakness;
    [SerializeField]
    protected JokeManager.JokeType notFunny;
    [SerializeField]
    protected JokeManager.JokeType specialty;

    [SerializeField]
    protected List<int> jokeListInt = new List<int>();

    [SerializeField]
    protected List<Joke> jokeList = new List<Joke>();

    protected bool laughed = false;
    protected bool guarding = false;

    [SerializeField]
    protected Joke prevJoke;

    [SerializeField]
    private JokeManager jm;

    public string getName()
    {
        return nametag;
    }

    public void setName(string name)
    {
        this.nametag = name;
    }

    public void setMF(int mf = 100)
    {
        maxMentalFortitude = mf;
        mentalFortitude = mf;
    }

    public void takeMFDamage(Joke joke, Joke pJoke, JokeManager.JokeType sp)
    {
        int damage = 0;

        //determines the value for the joke type
        if(joke.type == weakness)
        {
            Debug.Log("X2");
            damage = (joke.mentalDamage * 2);
        }
        else if(joke.type == this.notFunny)
        {
            Debug.Log("/2");
            damage = joke.mentalDamage / 2;
        }
        else
        {

            Debug.Log("X1");
            damage = joke.mentalDamage;
        }

        if(joke.type == sp)
        {
            Debug.Log("X2");
            damage *= 2;
        }

        if(joke == pJoke || joke == this.getPrevJoke())
        {
            Debug.Log("/2");
            damage /= 2;
        }

        //reduces damage if guarding
        if(guarding)
        {
            damage = damage / 2;
            guarding = false;
        }
        
        mentalFortitude = Mathf.Clamp(mentalFortitude - damage, 0, maxMentalFortitude);

        if(mentalFortitude == 0)
        {
            laughed = true;
            //win or lose scenario later
        }
    }

    public int getMF()
    {
        return mentalFortitude;
    }

    public int getMaxMF()
    {
        return maxMentalFortitude;
    }

    public void Guard()
    {
        guarding = true;
    }

    public void NotGuarding()
    {
        guarding = false;
    }

    public bool getGuarding()
    {
        return guarding;
    }

    public void setWeakness(JokeManager.JokeType x)
    {
        weakness = x;
    }

    public JokeManager.JokeType getWeakness()
    {
        return weakness;
    }

    public void setNotFunny(JokeManager.JokeType x)
    {
        notFunny = x;
    }

    public JokeManager.JokeType getNotFunny()
    {
        return notFunny;
    }

    public void setSpecialty(JokeManager.JokeType x)
    {
        specialty = x;
    }

    public JokeManager.JokeType getSpecialty()
    {
        return specialty;
    }

    public void setPrevJoke(Joke joke)
    {
        this.prevJoke = joke;
    }

    public Joke getPrevJoke()
    {
        return this.prevJoke;
    }

    public bool getLaughed()
    {
        return laughed;
    }

    public List<Joke> getJokeDeck()
    {
        foreach (int i in jokeListInt)
        {
            jokeList.Add(jm.jokeList[i]);
        }

        Shuffle();
        
        return jokeList;
    }

    public void Shuffle()
    {
        int count = jokeList.Count;
        int last = count - 1;

        for (int i = 0; i < last; ++i)
        {
            int r = Random.Range(i, count);
            Joke tmp = jokeList[i];
            jokeList[i] = jokeList[r];
            jokeList[r] = tmp;
        }
    }


}
