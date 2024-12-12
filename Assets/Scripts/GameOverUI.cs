using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverUI : MonoBehaviour
{
    private Animator anim;
    public TextMeshProUGUI gameEndMessage;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    public void Show(string message)
    {
        gameEndMessage.text = message;
        anim.SetTrigger("show");
    }

    public void OnRestartButtonClick()
    {
        GameManager.Instance.Restart();
    }

    public void OnMainMenuButtonClick()
    {
        GameManager.Instance.Menu();
    }
}
