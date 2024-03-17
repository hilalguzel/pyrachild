using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class PlayEnding : MonoBehaviour
{
    public static PlayEnding instance;

    public PlayableDirector playableDirector;
    public GameObject playerObject;
    public bool endingTimelineStarted;
    private void Start()
    {
        instance = this;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(playerObject, 2.6f);
            ProgressBar.Instance.goHomeText.SetActive(false);
            ProgressBar.Instance.progressBar.SetActive(false);
            playableDirector.Play();
            endingTimelineStarted = true;
        }
    }
}
