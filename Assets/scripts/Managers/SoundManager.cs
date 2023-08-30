using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    // Start is called before the first frame update

    public List<AudioClip> clip = new List<AudioClip>();
    Dictionary<clips,AudioClip> library = new Dictionary<clips, AudioClip>();
    GameObject source;

    public enum clips
    {
        walking = 0,
        coin = 1,
    }
    void Start()
    {
         source = Resources.Load<GameObject>("source");
        library.Add(clips.coin, clip[0]);

    }

    void initSounds()
    {
        //clipFile.Add(clips.walking,Resources.Load<GameObject>("Clips/"))
    }

    public  void PlayClip(clips currentClip)
    {
        
        GameObject soundSource = Instantiate(source,Vector3.zero, Quaternion.identity);
        soundSource.GetComponent<AudioSource>().clip = library[currentClip];
        soundSource.GetComponent<AudioSource>().Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
