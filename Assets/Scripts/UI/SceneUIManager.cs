using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneUIManager : MonoBehaviour
{
    /*[SerializeField] private OverlayUILogic overlayUILogic;
    [SerializeField] private CartEditorUILogic cartEditorPanelPrefab;
    private OverlayUILogic _overlayPanel;
    private CartEditorUILogic _cartEditorPanel;
    private float _timeScale;

    private void Awake()
    {
        _overlayPanel = Instantiate(overlayUILogic, transform);
        _cartEditorPanel = Instantiate(cartEditorPanelPrefab, transform);
    }

    private void Start()
    {
        _cartEditorPanel.gameObject.SetActive(false);
        _overlayPanel.EditCartButtonPressed += OnEditCartButtonPressed;
        _cartEditorPanel.LeaveEditorMenu += OnLeaveEditorMenu;
    }
        
    private void OnEditCartButtonPressed(object sender, EventArgs e)
    {
        _timeScale = Time.timeScale;
        Time.timeScale = 0;
        _overlayPanel.gameObject.SetActive(false);
        _cartEditorPanel.gameObject.SetActive(true); 
    }
        
    private void OnLeaveEditorMenu(object sender, EventArgs e)
    {
        Time.timeScale = _timeScale;
        _overlayPanel.gameObject.SetActive(true);
        _cartEditorPanel.gameObject.SetActive(false);
    }*/
}
