using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartController : MonoBehaviour 
{
    
	private void Update()
	{
        bool tap = false;
        if (Input.GetMouseButtonDown(0)) tap = true;
        if (tap)
        {
            SceneManager.LoadScene("Main");
        }
	}
}
