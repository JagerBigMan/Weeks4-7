using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlipMover : MonoBehaviour
{
    private bool Moving = false;
    public float speed = 1f;
    public float exhaustedSpeed;
    private float direction = 1f;
    public AudioSource moveClickAudioSource;
    public AudioSource stopClickAudioSource;
    public AudioSource flipClickAudioSource;

    public AudioClip stopClickAudioClip;

    public List<AudioClip> flipClickAudioClips;

    public Slider staminaSlider;
    public float maxStamina;
    public float minStamina;
    public float staminaCost;

    private float currentStamina;

    // Start is called before the first frame update
    void Start()
    {
        stopClickAudioSource.clip = stopClickAudioClip;
        currentStamina = maxStamina;

        staminaSlider.value = currentStamina / maxStamina;
        
    }

    // Update is called once per frame
    void Update()
    {
       if(Moving == true)
        {
            transform.position += Vector3.right * speed * Time.deltaTime * direction;
            currentStamina -= staminaCost * Time.deltaTime;
            staminaSlider.value = currentStamina / maxStamina;
        }
    }
    public void OnStaminaChange()
    {
        if (currentStamina <= 0)
        {
            speed = exhaustedSpeed;
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
