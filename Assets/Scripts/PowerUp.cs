using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public AudioSource getPowerUpAudio;
    public AudioSource powerUpExpire;

    private Movement extramove;

    public GameObject powerUpObj;

    public Transform[] possiblePositions;
    [SerializeField] private GameObject PowerUpIcon;
    [SerializeField] private GameObject timerObj;
    [SerializeField] TextMeshProUGUI timer;
    float PowerUpTime = 15;
    float SetTime = 15;

    // [SerializeField] private GameObject PowerUpIcon;
    private void Start()
    {
        //powerUpAudio = GetComponent<AudioSource>();
        extramove = GetComponent<Movement>();
    }
    private void Update()
    {
        if (timer.enabled)
        {
            PowerUpTime -= Time.deltaTime;

            timer.text = ((int) PowerUpTime).ToString();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PowerUp"))
        {
            getPowerUpAudio.Play();
            timerObj.SetActive(true);
            timer.enabled = true;
            PowerUpTime = SetTime;
            PowerUpIcon.SetActive(true);
            other.gameObject.SetActive(false);
            //powerUpAudio.Play();
            extramove.JumpHeigth = 3.5f;
            Invoke("BacktoNormal", 15f);
            Invoke("ReactivateCube", Random.Range(8f, 9f));

        }
    }
    private void BacktoNormal()
    {
        timer.enabled = false;
        extramove.JumpHeigth = 0.5f;
        PowerUpIcon.SetActive(false);
        timerObj.SetActive(false);
        powerUpExpire.Play();
    }
    private void ReactivateCube()
    {
        int randomIndex = Random.Range(0, possiblePositions.Length);

        powerUpObj.transform.position = possiblePositions[randomIndex].position;
        powerUpObj.SetActive(true); 
    }

}
