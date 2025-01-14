using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinBall2 : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        string tag = collision.gameObject.tag;
        switch(tag)
        {
            case "Dead":
                PinBallGameManager2.instance.GameEnd();
                
                break;

            case "Bouncer":
                PinBallGameManager2.instance.UpdateScore(10, 1);
                break;

            case "Point":
                PinBallGameManager2.instance.UpdateScore(20, 1);
                break;

            case "Side":
                PinBallGameManager2.instance.UpdateScore(10, 0);
                break;

            case "Flipper":
                PinBallGameManager2.instance.multiplier = 1;
                break;

            default:
                break;
        }
    }
}
