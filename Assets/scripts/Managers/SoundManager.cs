using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    // Start is called before the first frame update

    public enum clips
    {
        walking = 0,
    }
    public static Dictionary<clips, AudioClip> clipFile = new Dictionary<clips, AudioClip>();
    static GameObject source;
    void Start()
    {
        source = Resources.Load<GameObject>("SoundSource");
    }

    void initSounds()
    {
        //clipFile.Add(clips.walking,Resources.Load<GameObject>("Clips/"))
    }

    public static void PlayClip(clips currentClip)
    {
        GameObject soundSource = Instantiate(source,Vector3.zero, Quaternion.identity);
        soundSource.GetComponent<AudioSource>().clip = clipFile[currentClip];
        soundSource.GetComponent<AudioSource>().Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
