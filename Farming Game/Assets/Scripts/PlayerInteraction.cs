using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    PlayerController playerController;
    //The land the player is currently selecting
    Land selectedLand = null;

    // Start is called before the first frame update
    void Start()
    {
        //Get access to our PlayerController component
        playerController = transform.parent.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightBracket))
        {
            TimeManager.Instance.Tick();
        }

        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 1))
        {
            OnInteractableHit(hit);
        }
    }

    //Raycast가 상호작용 가능한 대상에 부딪힐 때 발생하는 일을 처리
    void OnInteractableHit(RaycastHit hit)
    {
        Collider other = hit.collider;

        //플레이어가 땅과 상호작용 하려는 지 확인
        if (other.tag == "Land")
        {
            //Get the land component
            Land land = other.GetComponent<Land>();
            SelectLand(land);
            return;
        }

        //플레이어가 땅 위에 서있지 않으면 Select를 false로 변경
        if (selectedLand != null)
        {
            selectedLand.Select(false);
            selectedLand = null;
        }
    }

    //땅을 선택하는 핸들
    void SelectLand(Land land)
    {
        //이전에 선택한 토지를 false로 설정 (If any)
        if (selectedLand != null)
        {
            selectedLand.Select(false);
        }

        //새로 선택한 토지를 지금 선택하고 있는 토지로 설정
        selectedLand = land;
        land.Select(true);
    }

    //플레이어가 마우스 왼쪽 클릭 했을 때 Triggered
    public void Interact()
    {
        //플레이어가 토지를 선택하고 있는지 확인
        if (selectedLand != null)
        {
            selectedLand.Interact();
            return;
        }

        Debug.Log("Not on any land!");
    }
}