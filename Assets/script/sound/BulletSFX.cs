using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSFX : MonoBehaviour
{

    public AudioSource gunshotSound;

    // Start is called before the first frame update
    void Start()
    {

        gunshotSound = GetComponent<AudioSource>();
        gunshotSound.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
