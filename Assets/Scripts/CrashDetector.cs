using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{

    [SerializeField] float delayAmount = 1f;
    [SerializeField] ParticleSystem crashEffect;
    bool crashed = false;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Ground" && !crashed)
        {
            crashed = true;
            FindObjectOfType<PlayerController>().DisableControls();
            Debug.Log("Crashed");
            crashEffect.Play();
            Invoke("ReloadScene", delayAmount);


        }
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
