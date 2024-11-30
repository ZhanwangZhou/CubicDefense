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

    private int money = 150;
    private MapCube upgradeCube;

    private void Awake()
    {
        Instance = this;
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
        return moneyNeeded <= money;
    }

    public void ChangeMoney(int changeAmount)
    {
        this.money += changeAmount;
        moneyText.text = "$" + money.ToString();
    }

    public void ShowUpgradeUI(MapCube cube, Vector3 position, bool upgradeDisabled)
    {
        upgradeCube = cube;
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
