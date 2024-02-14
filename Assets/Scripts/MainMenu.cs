using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ///unnecassary
    }

    // Update is called once per frame
    void Update()
    {
        ///not necassary as far as i know
    }

    public void PlayMaze()
    {
        SceneManager.LoadScene("maze");
    }
}
