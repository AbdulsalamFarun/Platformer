using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public bool canDoubleJump = false;
    public bool canDash = false;
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            gameObject.SetActive(true);
        }
        else if (Instance != this)
        {
           
            gameObject.SetActive(false);
            
        }
    }
}
