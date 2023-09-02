using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class Intro : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    string videoFileName;
    float length = 28f;
    float counter = 0f;
    void Start()
    {
          playVideo();
    }

    public void playVideo()
    {
        var videoPLayer = GetComponent<VideoPlayer>();
        if (videoPLayer)
        {
            string videoPath = System.IO.Path.Combine(Application.streamingAssetsPath, videoFileName);
            Debug.Log(videoPath);
            videoPLayer.url = videoPath;
            videoPLayer.Play();
        }

    }

    // Update is called once per frame
    void Update()
    {
        counter += Time.deltaTime;
        if(counter > length)
        {
            SceneManager.LoadScene(1);
        }
    }
}
