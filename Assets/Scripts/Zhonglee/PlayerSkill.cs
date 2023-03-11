using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSkill : MonoBehaviour
{
    public float skillCD = 7f;
    public float distance = 10f;
    public Vector2 offset = new Vector2(0, 1f);
    public bool isSkill;
    public bool isCD;
    public Transform skillPos;

    public string soundFile;
    public float soundVolume = 1f;

    public GameObject icon;
    public string button;

    // Start is called before the first frame update
    private void Awake()
    {
        isSkill = false;
        isCD = false;
        icon.SetActive(false);
    }

    protected IEnumerator CoolDown()
    {
        StartCoroutine(CD());
        AudioManager.instance.PlaySE(soundFile, soundVolume);
        Image cdImage = icon.transform.GetChild(0).GetComponent<Image>();
        cdImage.fillAmount = 0;
        float updateRate = 1 / skillCD * Time.deltaTime;
        while (cdImage.fillAmount < 1 ) 
        {
            cdImage.fillAmount += updateRate;
            yield return null;
        }
        cdImage.fillAmount = 1;
        
    }

    private IEnumerator CD()
    {
        isCD = true;
        yield return new WaitForSeconds(skillCD);
        isCD = false;
    }

}
