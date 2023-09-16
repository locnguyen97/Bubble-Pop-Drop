using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public List<Level> levelss;

    private int startIndex = 0;

    private int currentIndex;
    public Transform trash;
    public Action onReload;
    private Level curentLevel;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        currentIndex = startIndex;

        curentLevel =Instantiate(levelss[currentIndex]);
        curentLevel.SetData(this);
    }

    public int GetCurrentIndex()
    {
        return currentIndex;
    }

    public void CheckLevelUp()
    {
        Invoke(nameof(CheckWin),0.5f);
    }

    void CheckWin()
    {
        onReload.Invoke();
        if (curentLevel.transform.childCount == 1)
        {
            currentIndex += 1;
            StartCoroutine(LevelUp());
        }
    }

    public void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    IEnumerator LevelUp()
    {
        yield return new WaitForSeconds(1);

        if (currentIndex == 3)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

            currentIndex = 0;
        }

        onReload = null;

        curentLevel =Instantiate(levelss[currentIndex]);
        curentLevel.SetData(this);
        foreach (Transform tr in trash)
        {
            Destroy(tr.gameObject);
        }
    }

    public void ReSetCurrentLevel()
    {
        //levels[currentIndex].AddComponents();
    }
}