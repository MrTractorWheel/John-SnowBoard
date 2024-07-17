using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetactor : MonoBehaviour
{
    CircleCollider2D playerHead;
    [SerializeField] float delay = 0.2f;
    [SerializeField] ParticleSystem bloodEffect;
    [SerializeField] ParticleSystem landEffect;
    [SerializeField] AudioClip crashSFX;
    int playNum = 0;
 
    private void Start()
    {
        playerHead = GetComponent<CircleCollider2D>();
    }  
 
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground") && playerHead.IsTouching(other.collider) && playNum == 0){
            Debug.Log("Broken Neck!");
            playNum++;
            FindObjectOfType<PlayerController>().DisableControls();
            bloodEffect.Play();
            GetComponent<AudioSource>().PlayOneShot(crashSFX);
            Invoke("LoadScene", delay);
        }
        else{
            landEffect.Play();
        }
    }

    private void LoadScene(){
        SceneManager.LoadScene(0);
    }
}
