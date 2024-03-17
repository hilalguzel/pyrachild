using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameKill : MonoBehaviour
{
    public static FlameKill Instance;

    public int killCount = 0;

    public AudioSource deathSound;

    public GameObject blood;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("spider"))
        {
            Instantiate(blood, other.transform.position, Quaternion.identity);       
            Destroy(other.gameObject,0.6f);
            deathSound.Play();
            killCount++;
            ProgressBar.Instance.IncrementProgress(1f);
        }
    }
}
