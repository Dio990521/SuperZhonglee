using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public PlayerSpriteRenderer smallRenderer;

    public PlayerDeathAnimation playerDeathAnimation;
    public bool small => smallRenderer.enabled;
    public bool death => playerDeathAnimation.enabled;

    public bool starPower { get; private set; }
    public static string MAIN_SCENE = "Main";

    public bool isShield = false;

    private void Start()
    {
        LoadSavePoint();
        CheckSkillStatus();
    }

    private void LoadSavePoint()
    {
        transform.position = GameManager.instance.restartPos;
    }

    private void CheckSkillStatus()
    {
        if (GameManager.instance.isColumnSkillOn)
        {
            ColumnSkill columnSkill = GetComponent<ColumnSkill>();
            columnSkill.enabled = true;
        }
        if (GameManager.instance.isBombSkillOn)
        {
            BombSkill bombSkill = GetComponent<BombSkill>();
            bombSkill.enabled = true;
        }
    }

    public void Hit()
    {
        smallRenderer.enabled = false;
        playerDeathAnimation.enabled = true;
        GameManager.instance.ResetGame(4f);
    }

    public void StarPower()
    {
        StartCoroutine(StarAnimation(10f));
    }

    private IEnumerator StarAnimation(float duration)
    {
        AudioManager.instance.StopMusic();
        AudioManager.instance.PlayMusic("star", 0.3f);


        starPower = true;

        float elapsed = 0f;
        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            if (Time.frameCount % 50 == 0)
            {
                smallRenderer.spriteRenderer.color = Random.ColorHSV(0f, 1f, 1f, 1f, 1f, 1f);
            }
            yield return null;
        }
        smallRenderer.spriteRenderer.color = Color.white;
        starPower = false;
        AudioManager.instance.StopMusic();
        AudioManager.instance.PlayMusic("world bgm");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Fireball"))
        {
            if (isShield)
            {
                isShield = false;
            }
            else
            {
                Hit();
            }
        }
    }
}
