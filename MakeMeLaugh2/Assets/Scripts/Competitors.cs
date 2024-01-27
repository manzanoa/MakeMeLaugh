using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Competitors : MonoBehaviour
{
    private string nametag;
    private int maxMentalFortitude;
    private int mentalFortitude;
    private JokeManager.JokeType[] weakness;
    private JokeManager.JokeType[] notFunny;
    private JokeManager.JokeType[] specialty;

    private List<Joke> jokeList;

    private Joke lastJoke;

    private bool laughed = false;

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

    public void takeMFDamage(int damage)
    {
        this.mentalFortitude -= damage;
        mentalFortitude = Mathf.Clamp(mentalFortitude, 0, maxMentalFortitude);

        if(mentalFortitude > 0)
        {

        }
    }
}
