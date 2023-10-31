    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PersonCode : MonoBehaviour
{
    private bool ReadyToMove = true;
    public static bool flag = true;

    private GameObject[] Walls;
    private GameObject[] Blocks;

    private GameObject[] Green;

    private GameObject[] Door;

    private bool key = false;

    private bool Trig = true;

    public GameObject Panel;
    public GameObject TextDeath;

    public GameObject Button;

    public GameObject Puddle;

    private Animator anim;
    private Animator anim1;

    private Animator animator;

    private GameObject file;
    private GameObject b_lock;

    public static bool keydoor = false;

    public int num;

    public static bool Moveing_Num = false;

    [SerializeField] private TextMeshProUGUI Number;

    void Awake()
    {
        anim = GameObject.FindGameObjectWithTag("File").GetComponent<Animator>();
        anim1 = GameObject.FindGameObjectWithTag("Door").GetComponent<Animator>();
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        Walls = GameObject.FindGameObjectsWithTag("Walls");
        Blocks = GameObject.FindGameObjectsWithTag("Blocks");
        Green = GameObject.FindGameObjectsWithTag("GreenTracker");
        Door = GameObject.FindGameObjectsWithTag("Door");
    }

    public bool Move(Vector2 direction)
    {
        if (Mathf.Abs(direction.x) < 0.5)
        {
            direction.x = 0;
        }
        else
        {
            direction.y = 0;
        }
        direction.Normalize();
        Debug.Log(direction);
        
        if (Block(transform.position, direction))
        {
            return false;
        }
        else
        {
            if(Push.Target)
            {
                transform.Translate(direction);
            }
            else
            {
                animator.SetTrigger("hit");
                transform.Translate(0, 0, 0);
                Push.Target = true;
            }
            return true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("File"))
        {
            file = other.gameObject;

            anim.SetTrigger("Sign");
            key = true;
            StartCoroutine(DestroyFile());
        }
        if (other.gameObject.CompareTag("puddle"))
        {
            num -= 1;
            Number.text = (num).ToString();
            if (num <= 0)
            {
                Number.text = (0).ToString();
                Moveing_Num = true;
                Panel.SetActive(true);
                TextDeath.SetActive(true);
                Button.SetActive(true);
            }
        }
        if (other.gameObject.CompareTag("Portal1"))
            transform.Translate(-5f, 1f, 0);
        if (other.gameObject.CompareTag("Portal2"))
            transform.Translate(5f, 1f, 0);
        if (other.gameObject.CompareTag("Portal3"))
            transform.Translate(-3f, 4f, 0);
        if (other.gameObject.CompareTag("Portal4"))
            transform.Translate(3f, -3f, 0);
    }

    private IEnumerator DestroyFile()
    {
        yield return new WaitForSeconds(1f);
        Destroy(file);
    }

    public bool Block(Vector3 position, Vector2 direction)
    {
        Vector2 newPos = new Vector2(position.x, position.y) + direction;

        foreach (var wall in Walls)
        {
            if (wall.transform.position.x == newPos.x && wall.transform.position.y == newPos.y)
            {
                return true;
            }
        }
         
        foreach (var block in Blocks)
        {
            if (block.transform.position.x == newPos.x && block.transform.position.y == newPos.y)
            {
                animator.SetTrigger("hit");
                Push objpush = block.GetComponent<Push>();
                if (objpush && objpush.Move(direction))
                {
                    num = num - 1;
                    Number.text = (num).ToString();
                    if (num <= 0)
                    {
                        Number.text = (0).ToString();   
                        Moveing_Num = true;
                        Panel.SetActive(true);
                        TextDeath.SetActive(true);
                        Button.SetActive(true);
                    }
                    return true;
                }
            }
        }

        foreach (var green in Green)
        {
            if (green.transform.position.x == newPos.x && green.transform.position.y == newPos.y)
            {
                Trig = false;
            }
        }

        if (Door != null)
        {
            foreach (var door in Door)
            {
                if (door.transform.position.x == newPos.x && door.transform.position.y == newPos.y)
                {
                    if (!key)
                        return true;
                    else
                    {
                        anim1.SetTrigger("Open");
                        Door = null;
                        keydoor = true;
                        b_lock = door.gameObject;
                        StartCoroutine(DestroyLock());
                    }
                }
            }
        }
        num = num - 1;
        Number.text = (num).ToString();
        if (num <= 0)
        {
            Number.text = (0).ToString();
            Moveing_Num = true;
        }
        if (num <= 0 && Trig)
        {
            Number.text = (0).ToString();
            Panel.SetActive(true);
            TextDeath.SetActive(true);
            Button.SetActive(true);
        }
        return false;
    }
    private IEnumerator DestroyLock()
    {
        yield return new WaitForSeconds(1f);
        Destroy(b_lock);
    }
}
