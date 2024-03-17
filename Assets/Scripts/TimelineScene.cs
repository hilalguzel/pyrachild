using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TimelineScene : MonoBehaviour
{
    public string sceneName;

    private void Awake()
    {
        SceneManager.LoadScene(sceneName);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
