using Unity.VisualScripting;
using UnityEngine;

public class AttentionSceneManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Initiate.Fade("TitleScene", Color.black, 1.0f);
        }
        
    }
}
