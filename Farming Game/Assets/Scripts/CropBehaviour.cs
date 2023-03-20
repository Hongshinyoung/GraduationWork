using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CropBehaviour : MonoBehaviour
{
    //������ � �۹��� �ڶ����� ���� ����
    SeedData seedToGrow;

    
    [Header("Stages of Life")]
    public GameObject seed;
    public GameObject seeding;
    public GameObject harvestable;

    //�۹� ���� �ܰ�
    public enum CropState
    {
        Seed, Seeding, Harvestable
    }

    public CropState cropState;

    public void Plant(SeedData seedToGrow)
    {
        this.seedToGrow = seedToGrow;

        seeding = Instantiate(seedToGrow.seeding, transform);

        Item cropToYield = seedToGrow.cropToYield;

        harvestable = Instantiate(cropToYield.gamemodel, transform);

        SwitchState(CropState.Seed);
    }

    void SwitchState(CropState stateToSwitch)
    {
        seed.SetActive(false);
        seeding.SetActive(false);
        harvestable.SetActive(false);

        switch (stateToSwitch)
        {
            case CropState.Seed:
                seed.SetActive(true);
                break;
            case CropState.Seeding:
                seeding.SetActive(true);
                break;
            case CropState.Harvestable:
                harvestable.SetActive(true);
                break;
        }
        cropState = stateToSwitch;
    }
    public void Grow()
    {

    }

}
