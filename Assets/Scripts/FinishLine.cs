using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [SerializeField] float delay = 0.2f;
    [SerializeField] ParticleSystem finishEffect;
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")){
            Debug.Log("Parkour Finished!");
            finishEffect.Play();
            GetComponent<AudioSource>().Play();
            Invoke("LoadScene", delay);
        }
    }

    private void LoadScene(){
        SceneManager.LoadScene(0);
    }
}
