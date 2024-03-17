using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public static ProgressBar Instance;

    private Slider slider;
    private ParticleSystem particleSys;
    public GameObject goHomeText;
    public GameObject endingTimelineTrigger;
    public GameObject progressBar;

    private float fillSpeed = 2.3f;
    private float targetProgress = 0f;
    private float lastProgress = 0f; // Track previous progress value

    private void Awake()
    {
        slider = GetComponent<Slider>();
        particleSys = GameObject.Find("Progress Bar Particles").GetComponent<ParticleSystem>();
        endingTimelineTrigger.SetActive(false);
    }

    void Start()
    {
        Instance = this;
        goHomeText.SetActive(false);
        
    }

    void Update()
    {
        if (slider.value == 1f || FlameKill.Instance.killCount == 21)
        {
            particleSys.Play();
            goHomeText.SetActive(true);
            endingTimelineTrigger.SetActive(true);
        }
    }

    public void IncrementProgress(float newProgress)
    {
        targetProgress = slider.value + newProgress;

        if (slider.value < targetProgress)
        {
            slider.value += fillSpeed * Time.deltaTime;

            // Check for progress jump of at least 0.1
            if (slider.value - lastProgress >= 0.1f)
            {
                //particleSys.Play(); // Emit particles only on significant progress increase
                lastProgress = slider.value; // Update last progress
            }
        }
        else
        {
            particleSys.Stop();
        }
    }
}
