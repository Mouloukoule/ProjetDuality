using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class DeathPopupUI : MonoBehaviour
{
    public event Action OnPopupActivated = null;

    [SerializeField] GameObject popup = null;
    [SerializeField] Button deathButton = null;
    [SerializeField] TextMeshProUGUI timeSurvivedText = null;
    [SerializeField] Player playerRef = null;

    // Start is called before the first frame update
    void Start()
    {
        deathButton.onClick.AddListener(Excute);
    }

    // Update is called once per frame
    void Update()
    {
        SetTimeSurvivedText(playerRef.Score);
    }

    public void UpdateVisibility(bool _value)
    {
        if (!popup) return;
        popup.SetActive(!popup.activeInHierarchy);
        OnPopupActivated?.Invoke();
    }

    void Excute()
    {
        EditorApplication.ExitPlaymode();
    }

    void SetTimeSurvivedText(double _value)
    {
        timeSurvivedText.text = $"You Survived {_value} s";
    }
}
