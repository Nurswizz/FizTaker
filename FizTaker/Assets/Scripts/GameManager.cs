using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    private bool ReadyForInput;
    public PersonCode m_Player;

    private PlayerControls contral;

    SpriteRenderer spriteRenderer;

    private Animator animator;
    
    void Awake()
    {
        contral = new PlayerControls();
        animator = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        spriteRenderer = GameObject.FindGameObjectWithTag("Player").GetComponent<SpriteRenderer>();
        contral.GamePlay.Replay.performed += context => Butick();
    }

    private void OnEnable()
    {
        contral.Enable();
    }

    private void OnDisable()
    {
        contral.Disable();
    }

     void Update()
    {
        if (!PersonCode.Moveing_Num)
        {
            Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            //Vector2 moveInput = contral.GamePlay.Move.ReadValue<Vector2>();
            moveInput.Normalize();
            if (moveInput.x < 0)
            {
                spriteRenderer.flipX = true;
            }
            else if (moveInput.x > 0)
            {
                spriteRenderer.flipX = false;
            }
            if (moveInput.sqrMagnitude > 0.5)
            {
                if (ReadyForInput)
                {
                    ReadyForInput = false;
                    m_Player.Move(moveInput);
                }
            }

            else 
            {
                ReadyForInput = true;
            }
        } 
    }
    public void Butick()
    {
        PersonCode.Moveing_Num = false;
        PersonCode.keydoor = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
