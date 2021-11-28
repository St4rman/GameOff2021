using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class foodUC : MonoBehaviour
{
    [SerializeField] Puzzle puzzle;
    [SerializeField] SwitchToApp foodApp;
    [SerializeField] GameObject SnackApp;
    [SerializeField] GameObject FoodSprite;

    bool isDone = false;

    void Update()
    {
        if(puzzle.done && foodApp.appCleaned && !isDone)
        {
            SnackApp.SetActive(false);
            FoodSprite.SetActive(true);
            isDone = true;
        }
    }
}
