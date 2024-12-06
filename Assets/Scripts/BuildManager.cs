using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager Instance {get; private set;}

    public TurretData standardTurretData;
    public TurretData missileTurretData;
    public TurretData laserTurretData;
    public TurretData selectedTurretData;
    
    public TextMeshProUGUI moneyText;
    public UpgradeUI upgradeUI;

    public TextMeshProUGUI upgradeText;

    public TextMeshProUGUI removeText;

    private int money = 300;

    private Animator moneyTextAnim;
    private MapCube upgradeCube;

    private void Awake()
    {
        Instance = this;
        moneyTextAnim = moneyText.GetComponent<Animator>();
    }

    private void MoneyFlicker(bool lack)
    {
        if(lack)
        {
            moneyTextAnim.SetTrigger("LackMoney");
        }
        else
        {
            moneyTextAnim.SetTrigger("AddMoney");
        }
    }

    public void OnStandardSelected(bool isOn)
    {
        selectedTurretData = standardTurretData;
    }
    public void OnMissileSelected(bool isOn)
    {
        selectedTurretData = missileTurretData;
    }
    public void OnLaserSelected(bool isOn)
    {
        selectedTurretData = laserTurretData;
    }

    public bool IsEnough(int moneyNeeded)
    {
        if (moneyNeeded > money) MoneyFlicker(true);
        return moneyNeeded <= money;
    }

    public void ChangeMoney(int changeAmount)
    {
        if(changeAmount > 0) MoneyFlicker(false);
        this.money += changeAmount;
        moneyText.text = "$" + money.ToString();
    }

    public void ShowUpgradeUI(MapCube cube, Vector3 position, bool upgradeDisabled, int costUpgraded, int removePrice)
    {
        upgradeCube = cube;
        upgradeText.text = "Upgrade\n- $" + costUpgraded;
        removeText.text = "Remove\n+ $" + removePrice;
        upgradeUI.Show(position, upgradeDisabled);
    }

    public void HideUpgradeUI()
    {
        upgradeUI.Hide();
    }

    public void OnTurretUpgrade()
    {
        upgradeCube?.OnTurretUpgrade();
        HideUpgradeUI();
    }
    public void OnTurretRemove()
    {
        upgradeCube?.OnTurretRemove();
        HideUpgradeUI();
    }
}
