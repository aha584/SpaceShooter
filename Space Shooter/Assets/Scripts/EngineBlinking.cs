using UnityEngine;

public class EngineBlinking : MonoBehaviour
{
    private SpriteRenderer flameSprite;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        flameSprite = GetComponent<SpriteRenderer>(); 
    }

    // Update is called once per frame
    void Update()
    {
        flameSprite.enabled = !flameSprite.enabled;
    }
}
