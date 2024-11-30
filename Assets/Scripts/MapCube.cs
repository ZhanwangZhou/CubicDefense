using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MapCube : MonoBehaviour
{
    private GameObject turretGO;
    private TurretData turretData;
    private bool turretUpgraded;
    private Color originalColor;

    public GameObject buildEffect;

    private void Start()
    {
        turretUpgraded = false;
        originalColor = GetComponent<MeshRenderer>().material.color;
    }

    private void OnMouseDown()
    {
        if(EventSystem.current.IsPointerOverGameObject() == true) return;
        if(turretData != null)
        {
            BuildManager.Instance.ShowUpgradeUI(this, transform.position, turretUpgraded);
        }
        else
        {
            BuildTurret();
        }
    }

    private void OnMouseEnter()
    {
        if(EventSystem.current.IsPointerOverGameObject() == false)
        {
            GetComponent<MeshRenderer>().material.color = Color.blue;
        }
    }

    private void OnMouseExit()
    {
        GetComponent<MeshRenderer>().material.color = originalColor;
    }

    private void BuildTurret()
    {
        TurretData selectedTD = BuildManager.Instance.selectedTurretData;
        if(selectedTD == null || selectedTD.turretPrefab == null) return;
        if(!BuildManager.Instance.IsEnough(selectedTD.cost)) return;
        BuildManager.Instance.ChangeMoney(- selectedTD.cost);
        turretData = selectedTD;
        turretGO = GameObject.Instantiate(selectedTD.turretPrefab, transform.position, Quaternion.identity);
        GameObject soilParticle = GameObject.Instantiate(buildEffect, transform.position, Quaternion.identity);
        Destroy(soilParticle, 2);
    }

    public void OnTurretUpgrade()
    {
        if(BuildManager.Instance.IsEnough(turretData.costUpgraded))
        {
            Destroy(turretGO);
            BuildManager.Instance.ChangeMoney(- turretData.costUpgraded);
            turretGO = GameObject.Instantiate(turretData.turretUpgradedPrefab, transform.position, Quaternion.identity);
            GameObject soilParticle = GameObject.Instantiate(buildEffect, transform.position, Quaternion.identity);
            Destroy(soilParticle, 2);
            turretUpgraded = true;
        }
    }
    
    public void OnTurretRemove()
    {
        Destroy(turretGO);
        turretData = null;
        turretGO = null;
        turretUpgraded = false;
    }
}
