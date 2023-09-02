using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class Win : MonoBehaviour
{
    // Start is called before the first frame updat
    // Start is called before the first frame update
    float counter = 0f;
    [SerializeField]
    string videoFileName;
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
        if (counter > 5f)
        {
            SceneManager.LoadScene(1);
        }
    }
}


