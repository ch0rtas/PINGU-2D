using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chicken : Enemy
{
    protected override void Awake()
    {
        base.Awake();
    }
    public override void Stomped(Transform player)
    {
        animator.SetTrigger("Hit");
        gameObject.layer = LayerMask.NameToLayer("OnlyGround");
        Destroy(gameObject, 1f);
        autoMovement.PauseMovement();
    }
}
