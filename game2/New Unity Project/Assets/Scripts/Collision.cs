/* using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Collision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



     void OnCollisionEnter(Collision other) {
        switch (other.gameObject.tag)
        {
            case "Friendly" : 
                Debug.Log("This thing is friendly");
                break;

            case "Finish" : 
                Debug.Log("Congrats! You finished!");
                break;
            
            case "Fuel" : 
                Debug.Log("You picked up fuel");
                break;
            
            default:
                ReloadLevel();
                break;
        }
    }

    void ReloadLevel()
    {
        SceneManager.LoadScene(0);
    }
} */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Collision : MonoBehaviour
{
    void OnCollisionEnter(UnityEngine.Collision other)
    {
        switch (other.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("This thing is friendly");
                break;

            case "Finish":
                Debug.Log("Congrats! You finished!");
                break;

            case "Fuel":
                Debug.Log("You picked up fuel");
                break;

            default:
                ReloadLevel();
                break;
        }
    }

    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
