using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD;

public class DogController : MonoBehaviour
{
    //Unity Sound
    AudioSource soundSource;
    
    //FMOD Sound
    [FMODUnity.EventRef]
    public string barkSound;
    FMOD.Studio.EventInstance barkSoundEvent;
    [FMODUnity.ParamRef]
    public string parameterName;
    FMOD.Studio.PARAMETER_ID parameter;
    float number = 1f;

    // Start is called before the first frame update
    void Start()
    {
        //Unity Sound
        //soundSource = GetComponent<AudioSource>();
        
        //FMOD Sound
        barkSoundEvent = FMODUnity.RuntimeManager.CreateInstance(barkSound);
        barkSoundEvent.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
        barkSoundEvent.start();

        barkSoundEvent.release();
        //FMOD Sound one line. No control over the sound, just plays it
        //FMODUnity.RuntimeManager.PlayOneShot(barkSound, transform.position);

        //Method
        Bark();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        barkSoundEvent.setParameterByName(parameterName, number);

    }

    void Bark()
    {
        soundSource.Play();
    }
}
