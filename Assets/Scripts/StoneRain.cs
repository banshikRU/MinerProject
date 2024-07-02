using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneRain : MonoBehaviour
{
    [SerializeField] private Animator _myAnimator;
    private void OnEnable()
    {
        StartCoroutine(StoneRainn());
    }
    IEnumerator StoneRainn()
    {
        _myAnimator.Play("StoneRain");
        yield return new WaitForSeconds(2f);
        gameObject.SetActive(false);

    }
}
