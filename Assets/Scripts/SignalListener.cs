using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SignalListener : MonoBehaviour
{
    private bool playerInRange = false;
    /*private void Update()
    {
        if (playerInRange)
        {
            SceneManager.LoadScene("GridMove");
        }
    }*/

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerInRange = true;
            Trans.fact1 = true;
        }
    }
}
