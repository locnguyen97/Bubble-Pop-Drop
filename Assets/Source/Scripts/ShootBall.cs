using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShootBall : MonoBehaviour
{
    [SerializeField] private List<GameObject> listBall;
    private GameManager gameManager;
    private int countBall = 0;

    public void SetData(GameManager gm)
    {
        gameManager = gm;
        gameManager.onReload += ReShowBall;
    }

    void ReShowBall()
    {
        countBall++;
        Invoke(nameof(ReloadBall),0.25f);
    }
    public void ReloadBall()
    {
        if (countBall< listBall.Count &&listBall.Count > 0 && listBall[countBall] != null)
        {
            var x = listBall[countBall];
            x.gameObject.SetActive(true);
        }
    }
}
