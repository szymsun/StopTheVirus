using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class GlitchSoundEffect : MonoBehaviour
{
    private AudioSource _source;
    public AudioClip[] clips;
    public bool hasToPlay = true;
    
    // Start is called before the first frame update
    void Start()
    {
        _source = GetComponent<AudioSource>();
        _source.clip = clips[Random.Range(0, clips.Length)];
    }

    // Update is called once per frame
    void Update()
    {
        if (!_source.isPlaying && hasToPlay)
        {
            _source.clip = clips[Random.Range(0, clips.Length)];
            _source.pitch = Random.Range(0.2f, 2f);
            _source.Play();
        }    
    }
    
    
}
