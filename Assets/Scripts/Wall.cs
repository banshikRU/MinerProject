using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    [SerializeField] private Sprite attentionSprite;
    [SerializeField]private SpriteRenderer curentAttentionSprite;
    [SerializeField]private float timeToRevert;
    private bool isRevert;
    private void Awake()
    {
        isRevert = false;
    }
    public void RevertSprite()
    {
        curentAttentionSprite.sprite = attentionSprite;
        isRevert = true;
    }
    private void Update()
    {
        if (isRevert)
        {
            timeToRevert -= Time.fixedDeltaTime;
            if (timeToRevert <= 0)
            {
                isRevert = false;
                curentAttentionSprite.sprite = null;
            }
        }
    }
    
}
