using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface weapons
{
    void Attack();
    bool IsAttacking { get; }
}