using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    private int iHealth = 100;

    //Health variable
    public int Health
    {
        get { return iHealth; }
        set
        {
            iHealth = value;

            if (iHealth <= 0)
                Die();

            //GameManager.OnPlayerHealthChange();
        }
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Health <= 0)
        {
            Die();
        }
    }
    void Die()
    {

    }
}
