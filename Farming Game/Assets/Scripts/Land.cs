using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Land : MonoBehaviour, ITimeTracker
{
    public enum LandStatus
    {
        Soil, Farmland, Watered
    }

    public LandStatus landStatus;

    public Material soilMat, farmlandMat, wateredMat;
    new Renderer renderer;

    //플레이어가 Land를 선택할 때 활성화할 게임 오브젝트
    public GameObject select;

    //Cache the time the land was watared
    GameTimestamp timeWatered;

    // Start is called before the first frame update
    void Start()
    {
        //Get the renderer component
        renderer = GetComponent<Renderer>();

        //default 상태를 흙으로 설정
        SwitchLandStatus(LandStatus.Soil);

        //토지 선택 해제가 default
        Select(false);

        //Add this to TimeManager's Listener list
        TimeManager.Instance.RegisterTracker(this);
    }

    public void SwitchLandStatus(LandStatus statusToSwitch)
    {
        landStatus = statusToSwitch;

        Material materialToSwitch = soilMat;

        switch (statusToSwitch)
        {
            case LandStatus.Soil:
                materialToSwitch = soilMat;
                break;
            case LandStatus.Farmland:
                materialToSwitch = farmlandMat;
                break;

            case LandStatus.Watered:
                materialToSwitch = wateredMat;

                timeWatered = TimeManager.Instance.GetGameTimestamp();
                break;

 

        }

        //Get the renderer to apply the changes
        renderer.material = materialToSwitch;
    }

    public void Select(bool toggle)
    {
        select.SetActive(toggle);
    }

    //플레이어가 토지를 선택한 상태에서 마우스 왼쪽 버튼을 누를 때
    public void Interact()
    {
        if (landStatus == LandStatus.Farmland)
        {
            SwitchLandStatus(LandStatus.Watered);
        }
        else
        {
            SwitchLandStatus(LandStatus.Farmland);
        }
        //Interaction 
    }


    //Checked if 24 hours has passed last watered
    public void ClockUpdate(GameTimestamp timestamp)
    {
        if(landStatus == LandStatus.Watered)
        {
            int hoursElapsed = GameTimestamp.CompareTimestamps(timeWatered, timestamp);
            Debug.Log(hoursElapsed + "hours since this was watered");

            if(hoursElapsed > 24)
            {
                SwitchLandStatus(LandStatus.Farmland);
            }
        }
    }
}