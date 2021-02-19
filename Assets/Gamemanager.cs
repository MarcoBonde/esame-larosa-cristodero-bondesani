using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    bool GamehasEnded = false; 
    public void EndGame()
    {
       if (GamehasEnded == false)
        GamehasEnded = true;
        Restart();
    }
     
    void Restart()
    {
        SceneManager.LoadScene("menu");
    }
}
    
