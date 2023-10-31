using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetGo : MonoBehaviour
{
    private Animator anim;
    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Start()
    {
        
    }
}
