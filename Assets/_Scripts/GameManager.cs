using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager ins;

    public int currLevel_int;
    public bool gameover_bool;
    public Animator player_anim;
    public float bulletStartTurningAngle_float;
    public GameObject bullet_gm, bulletStartPoint_gm;
    GameObject temp_ins;
    public float shootBulletAfterSecs_float = 5;

    public GameObject win_panel, lose_panel;

    private void Awake()
    {
        ins = this;
        InvokeRepeating("StartBulletShoot_func", 1, shootBulletAfterSecs_float);
    }

    void StartBulletShoot_func()
    {
        if (!gameover_bool)
        {
            player_anim.SetTrigger("shoot_anim");
        }
    }

    public void InstantiateBullet_func()
    {
        if (!gameover_bool)
        {
            temp_ins = Instantiate(bullet_gm, bulletStartPoint_gm.transform.position, Quaternion.identity) as GameObject;
            temp_ins.transform.DORotate(new Vector3(0, 0, bulletStartTurningAngle_float), 0);
        }
    }

    public void GameoverWin_func()
    {
        gameover_bool = true;
        win_panel.SetActive(true);
    }
    public void GameoverLose_func()
    {
        gameover_bool = true;
        lose_panel.SetActive(true);
    }


    public void Restart_func()
    {
        SceneManager.LoadScene(currLevel_int);
    }

    public void NextLevel_func()
    {
        if(currLevel_int == SceneManager.sceneCountInBuildSettings-1)
            SceneManager.LoadScene(1);
        else
            SceneManager.LoadScene(currLevel_int + 1);
    }

}


// test github new branch
// test built
// add enemy animation
