using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audio : MonoBehaviour
{
    public AudioClip ambient;  //ambient.wav
    public AudioClip appear;  // appear.ogg
    public AudioClip victory;  // victory.mp3
    public AudioClip defeat;  // defeat.ogg
    public AudioClip startnewlevel;  // newlevel.ogg
    public AudioClip enemycomes;  // enemycome.mp3
    public AudioClip getattacked;  // getattacked.ogg
    public AudioClip movement;  // slime.ogg
    public AudioClip avoidenemy;  // nicework.ogg
    public AudioClip lowink;  // lowink.ogg

    AudioSource audioSource;

    private bool canWalkSound = true;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    //void OnCollisionEnter()
    //{
    //    audioSource.PlayOneShot(enemycome, 0.8F);
    //}

    public void AmbientSound()
    {
        audioSource.PlayOneShot(ambient);
    }

    public void PlayVictorySound()
    {
        audioSource.PlayOneShot(victory);
    }

    public void AppearSound()
    {
        audioSource.PlayOneShot(appear);
    }

    public void DefeatSound()
    {
        audioSource.PlayOneShot(defeat);
    }

    public void NewLevelSound()
    {
        audioSource.PlayOneShot(startnewlevel);
    }

    public void EnemySound()
    {
        audioSource.PlayOneShot(enemycomes);
    }

    public void AttackedSound()
    {
        audioSource.PlayOneShot(getattacked);
    }

    public void MovementSound()
    {
        if(canWalkSound)
        {
            StartCoroutine(MovementSoundTime());
        }
    }

    private IEnumerator MovementSoundTime()
    {
        canWalkSound = false;
        yield return new WaitForSeconds(0.5f);
        audioSource.PlayOneShot(movement, 0.3f);
        canWalkSound = true;

    }

    public void AvoidEnemySound()
    {
        audioSource.PlayOneShot(avoidenemy);
    }

    public void LowinkSound()
    {
        audioSource.PlayOneShot(lowink);
    }
}
