using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
public class GifVideo : MonoBehaviour
{
    public VideoPlayer gif1;
    public VideoPlayer gif2;
    private void Start()
    {
        gif1.url = System.IO.Path.Combine(Application.streamingAssetsPath, "Gif1.mp4");
        gif2.url = System.IO.Path.Combine(Application.streamingAssetsPath, "Gif2.mp4");
        gif1.Play();
        gif2.Play();

    }
}
