using System.Collections;
using System.Collections.Generic;
using App;
using TMPro;
using UnityEngine;

public class TutorialTextController : MonoBehaviour, IGameStartListener, IGameFinishListener
{
    [SerializeField] private TMP_Text _text;
    
    public void OnGameStarted()
    {
        _text.gameObject.SetActive(false);
    }

    public void OnGameFinished()
    {
        _text.gameObject.SetActive(true);
    }
}
