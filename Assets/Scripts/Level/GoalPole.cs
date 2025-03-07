using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalPole : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Penguin penguin = collision.GetComponent<Penguin>();
        if(penguin != null)
        {
            penguin.Goal();
        }
    }
}
