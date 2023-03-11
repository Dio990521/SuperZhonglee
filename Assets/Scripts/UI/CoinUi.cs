using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinUi : MonoBehaviour
{
    private Text text;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        text.text = "       x " + GameManager.instance.coins;
    }

    public void UpdateCoinText()
    {
        text.text = "       x " + GameManager.instance.coins;
    }
}
