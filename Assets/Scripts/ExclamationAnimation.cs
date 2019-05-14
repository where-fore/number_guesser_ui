using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExclamationAnimation : MonoBehaviour
{

    [SerializeField]
    private Sprite defaultSprite = null;

    [SerializeField]
    private Sprite updateFlashSprite = null;

    private Image imageComponent = null;

    private float timeToFlash = 0.3f;

    void Start()
    {
        imageComponent = gameObject.GetComponent<Image>();
        imageComponent.sprite = defaultSprite;
    }

    public void FlashSprite()
    {
        StartCoroutine("actuallyFlashSprite");
    }

    private IEnumerator actuallyFlashSprite()
    {
        imageComponent.sprite = updateFlashSprite;

        yield return new WaitForSeconds(timeToFlash);

        imageComponent.sprite = defaultSprite;
    }
}
