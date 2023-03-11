using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeUi : MonoBehaviour
{

    private Text text;
    // Start is called before the first frame update
    private void Awake()
    {
        text = GetComponent<Text>();
        text.text = "       x " + GameManager.instance.lives;
    }

    public void UpdateLifeText()
    {
        text.text = "       x " + GameManager.instance.lives;
    }

}
