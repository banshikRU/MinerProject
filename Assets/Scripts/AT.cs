using UnityEngine;

public class AT : MonoBehaviour
{
    public void PageVisible()
    {
        SoundManager.instance.OnOffAllSfx(true);
        SoundManager.instance.OnOffAllSound(true);
        Debug.Log("Игра в фокусе");
        Time.timeScale = 1F;
        ObstacleGenerator.Instance.isTimerStart =  true;
    }

    public void PageNotVisible()
    {
        SoundManager.instance.OnOffAllSfx(false);
        SoundManager.instance.OnOffAllSound(false);
        Debug.Log("Игра НЕ в фокусе");
        Time.timeScale = 0F;
        ObstacleGenerator.Instance.isTimerStart = false;
    }
}