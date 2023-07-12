using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioMgr : MonoBehaviour
{
    public static AudioMgr inst;

    private void Awake(){
        inst = this;
    }

    public AudioSource Footstep;
    public AudioSource Cardflip;
    public AudioSource Card;
    public AudioSource Combinecard;
    public AudioSource OpenInv;
    public AudioSource CloseInv;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            PlayFootStep();
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            PlayCombinecard();
        }
    }

    public void PlayFootStep()
    {
        Footstep.Play();
    }

    public void PlayCardflip()
    {
        Cardflip.Play();
    }

    public void PlayCard()
    {
        Card.Play();
    }

    public void PlayCombinecard()
    {
        Combinecard.Play();
    }

    public void PlayOpenInv()
    {
        OpenInv.Play();
    }

    public void PlayCloseInv()
    {
        CloseInv.Play();
    }
}
