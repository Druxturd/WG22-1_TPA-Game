using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharMoveManager : MonoBehaviour
{
    [SerializeField] Animator anim;
    
    public void Freeze()
    {
        anim.enabled = false;
    }

    public void Release()
    {
        anim.enabled = true;
    }
}
