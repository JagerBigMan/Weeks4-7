using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipMover : MonoBehaviour
{
    private bool Moving = false;
    public float speed = 1f;
    private float direction = 1f;
    public AudioSource moveClickAudioSource;
    public AudioSource stopClickAudioSource;
    public AudioSource flipClickAudioSource;

    public AudioClip stopClickAudioClip;

    public List<AudioClip> flipClickAudioClips;

    // Start is called before the first frame update
    void Start()
    {
        stopClickAudioSource.clip = stopClickAudioClip;
    }

    // Update is called once per frame
    void Update()
    {
       if(Moving == true)
        {
            transform.position += Vector3.right * speed * Time.deltaTime * direction;
        }
    }

    public void OnMoveClick()
    {
        Moving = true;
        moveClickAudioSource.Play();

    }

    public void OnStopClick()
    {
        Moving = false;
        stopClickAudioSource.Play();
    }

    public void OnFlipClick()
    {
        speed *= -1;

        //Take our clips and choose one ramdonly

        //Get a random number from 0 to (the size of the list -1)
        //Make sure you're taking into account the exclusive nature of the maximum parameter with Random.Range. (min, total + 1)
        int randomIndex = UnityEngine.Random.Range(0, flipClickAudioClips.Count);
        AudioClip randomlyChosenClip = flipClickAudioClips[randomIndex];

        flipClickAudioSource.PlayOneShot(randomlyChosenClip);
    }
}
