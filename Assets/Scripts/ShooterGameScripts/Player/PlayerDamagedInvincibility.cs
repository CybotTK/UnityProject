using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamagedInvincibility : MonoBehaviour
{
    [SerializeField]
    private float invincibilityDuration;
    private InvincibleController invincibilityController;
    public void Awake()
    {
        invincibilityController = GetComponent<InvincibleController>();
    }

    public void StartInvincibility()
    {
        invincibilityController.StartInvincibility(invincibilityDuration);
    }
}
