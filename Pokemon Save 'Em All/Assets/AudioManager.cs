using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    public AudioClip backgroundLVL1;
    public AudioClip backgroundLVL2;
    public AudioClip combat;
    public AudioClip degats;
    public AudioClip monstre;
    public AudioClip health;

    private void Start(){
        string currentScene = SceneManager.GetActiveScene().name;

            if (currentScene == "Numero1")
            {
                musicSource.clip = backgroundLVL1;
                musicSource.Play();
            }else if (currentScene == "Numero1bis")
            {
                musicSource.clip = backgroundLVL1;
                musicSource.Play();
            }else if (currentScene == "Numero2")
            {
                musicSource.clip = backgroundLVL2;
                musicSource.Play();
            }
            else if (currentScene == "Numero2bis")
            {
                musicSource.clip = backgroundLVL2;
                musicSource.Play();
            }else if (currentScene == "Combat")
            {
                musicSource.clip = combat;
                musicSource.Play();
            }
            else if (currentScene == "Combat1")
            {
                musicSource.clip = combat;
                musicSource.Play();
            }
            


    }


    public void PlaySfxDegats(AudioClip clip){
        SFXSource.PlayOneShot(clip);

    }
}
