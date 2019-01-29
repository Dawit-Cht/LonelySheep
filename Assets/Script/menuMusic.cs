using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuMusic : MonoBehaviour {

    public AudioSource music;
    static bool AudioBegin = false;

    private void Awake()
    {
        if (!AudioBegin)
        {
            music.Play();
            DontDestroyOnLoad(gameObject);
            AudioBegin = true;
        }
    }

    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        music.Stop();
        AudioBegin = false;
	}
}
