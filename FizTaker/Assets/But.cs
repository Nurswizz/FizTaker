using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class But : MonoBehaviour
{
    public void Butick()
    {
        PersonCode.keydoor = false;
        PersonCode.Moveing_Num = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Butick2()
    {
        PersonCode.keydoor = false;
        PersonCode.Moveing_Num = false;
        SceneManager.LoadScene(0);
    }
}
