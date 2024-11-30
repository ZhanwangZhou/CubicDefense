using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeUI : MonoBehaviour
{
    public Button upgradeButton;
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void Show(Vector3 position, bool upgradeDisabled)
    {
        if(transform.localScale != Vector3.zero && transform.position == position)
        {
            Hide();
            return;
        }
        upgradeButton.interactable = !upgradeDisabled;
        transform.position = position;
        anim.SetBool("Show", true);
    }
    public void Hide()
    {
        anim.SetBool("Show", false);
    }

    public void OnUpgradeButtonClick()
    {
        BuildManager.Instance.OnTurretUpgrade();
    }

    public void OnRemoveButtonClick()
    {
        BuildManager.Instance.OnTurretRemove();
    }
}
