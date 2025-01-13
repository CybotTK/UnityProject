using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinBall : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        string tag = collision.gameObject.tag;
        switch(tag)
        {
            case "Dead":
                PinBallGameManager.instance.GameEnd();
                break;

            case "Bouncer":
                PinBallGameManager.instance.UpdateScore(10, 1);
                break;

            case "Point":
                PinBallGameManager.instance.UpdateScore(20, 1);
                break;

            case "Side":
                PinBallGameManager.instance.UpdateScore(10, 0);
                break;

            case "Flipper":
                PinBallGameManager.instance.multiplier = 1;
                break;

            default:
                break;
        }
    }
}
