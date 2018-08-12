using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldTracker : MonoBehaviour
{
    public int housesPerStore, moneyPerFacory, costPerStore, costPerHouse, costPerLab, scienceToWin;
    public float factoriesPerHouse, science, SciencePerLab;
    public int money;
    public int labs, stores, factories, houses;

    public int[] buildingCosts = { 2, 3, 4, 5 };
    
    public float MaxHouses { get { return (housesPerStore * stores) + 2; } }

    

    public float MaxFactories { get { return factoriesPerHouse * houses; } }

    public int MoneyPerTick { get { return 
                (moneyPerFacory * factories) 
                - (costPerHouse * houses) 
                - (costPerStore * stores)
                - (costPerLab * labs); } }
    public float SciencePerTick { get { return SciencePerLab * labs; } }

    public GameObject HousePrefab, FactoryPrefab, LabPrefab, ShopPrefab, RubblePrefab, EmptyPrefab;
    public GameObject WinUI;

    public int FactoryCount()
    {
        return factories;
    }

    private float tickTimer = 0;
    private void Update()
    {
        tickTimer += Time.deltaTime;
        if (tickTimer >= 1)
        {
            tickTimer = 0;
            money += MoneyPerTick;
            science += SciencePerTick;
            if (science >= 100)
            {
                Time.timeScale = 0;
                WinUI.SetActive(true);
            }
        }
    }

    public int CostToBuild(BuildingType type, float yPosition)
    {
        return (int)((double)buildingCosts[(int)type] * Math.Sqrt(yPosition * 2));
    }

    public bool CanBuildFactory(GameObject location)
    {
        return factories <= MaxFactories - 1
            && money > CostToBuild(BuildingType.Factory, location.transform.position.y);
    }

    public bool CanBuildHouse(GameObject location)
    {
        return factories <= MaxHouses - 1
            && money > CostToBuild(BuildingType.House, location.transform.position.y);
    }

    public bool CanBuildLab(GameObject location)
    {
        return money > CostToBuild(BuildingType.Lab, location.transform.position.y);
    }

    public bool CanBuildShop(GameObject location)
    {
        return money > CostToBuild(BuildingType.Shop, location.transform.position.y);
    }

    public void BuildFactory(GameObject location)
    {
        if (CanBuildFactory(location))
        {
            Transform buildAt = location.transform;
            Instantiate(FactoryPrefab, buildAt.position, buildAt.rotation, buildAt.parent);
            Destroy(location);
            money -= CostToBuild(BuildingType.Factory, buildAt.position.y);
            ++factories;
        }
    }
    public void BuildHouse(GameObject location)
    {
        if (CanBuildHouse(location))
        {
            Transform buildAt = location.transform;
            Instantiate(HousePrefab, buildAt.position, buildAt.rotation, buildAt.parent);
            Destroy(location);
            money -= CostToBuild(BuildingType.House, buildAt.position.y);
            ++houses;
        }
    }

    public void BuildLab(GameObject location)
    {
        if (CanBuildLab(location))
        {
            Transform buildAt = location.transform;
            Instantiate(LabPrefab, buildAt.position, buildAt.rotation, buildAt.parent);
            Destroy(location);
            money -= CostToBuild(BuildingType.Lab, buildAt.position.y);
            ++labs;
        }
    }

    public void BuildShop(GameObject location)
    {
        if (CanBuildShop(location))
        {
            Transform buildAt = location.transform;
            Instantiate(ShopPrefab, buildAt.position, buildAt.rotation, buildAt.parent);
            Destroy(location);
            money -= CostToBuild(BuildingType.Shop, buildAt.position.y);
            ++stores;
        }
    }

    public void MakeRubble (GameObject location, BuildingType type)
    {
        Transform buildAt = location.transform;
        Instantiate(RubblePrefab, buildAt.position, buildAt.rotation, buildAt.parent);
        Destroy(location);
        switch (type)
        {
            case BuildingType.Factory:
                --factories;
                break;
            case BuildingType.House:
                --houses;
                break;
            case BuildingType.Lab:
                --labs;
                break;
            case BuildingType.Shop:
                --stores;
                break;
            default:
                return;
        }
            
    }
    public void SellBuilding(GameObject location, BuildingType type)
    {
        Transform buildAt = location.transform;
        Instantiate(EmptyPrefab, buildAt.position, buildAt.rotation, buildAt.parent);
        Destroy(location);
        switch (type)
        {
            case BuildingType.Factory:
                --factories;
                break;
            case BuildingType.House:
                --houses;
                break;
            case BuildingType.Lab:
                --labs;
                break;
            case BuildingType.Shop:
                --stores;
                break;
            default:
                return;
        }
    }
}
