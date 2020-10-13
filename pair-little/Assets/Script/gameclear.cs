using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameclear : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        SceneManager.LoadScene("stageclear", LoadSceneMode.Additive);
    }
}

