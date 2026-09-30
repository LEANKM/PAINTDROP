using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaletteManager : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public Color[] toneChange = new Color[7];
    private int currentTone = 0;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (toneChange.Length > 0)
        {
            ChangeColor();
        }
    }
    void Update()
    {

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("SolidFloor"))
        {
            RainbowForward();
        }
    }
    void RainbowForward()
    {
        if (toneChange.Length == 0) return;
        currentTone++;
        if (currentTone >= toneChange.Length)
        {
            currentTone = 0;
        }
        ChangeColor();
    }
    void ChangeColor()
    {
        spriteRenderer.color = toneChange[currentTone];
    }
}
