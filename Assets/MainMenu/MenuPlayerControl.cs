using UnityEngine;

public class MenuPlayerControl : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnEnter()
    {
        MenuManager menuManager = (MenuManager)Object.FindFirstObjectByType(typeof(MenuManager));
        menuManager.StartGame();
    }
}
