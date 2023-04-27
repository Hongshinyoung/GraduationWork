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

    //Raycast�� ��ȣ�ۿ� ������ ��� �ε��� �� �߻��ϴ� ���� ó��
    void OnInteractableHit(RaycastHit hit)
    {
        Collider other = hit.collider;

        //�÷��̾ ���� ��ȣ�ۿ� �Ϸ��� �� Ȯ��
        if (other.tag == "Land")
        {
            //Get the land component
            Land land = other.GetComponent<Land>();
            SelectLand(land);
            return;
        }

        //�÷��̾ �� ���� ������ ������ Select�� false�� ����
        if (selectedLand != null)
        {
            selectedLand.Select(false);
            selectedLand = null;
        }
    }

    //���� �����ϴ� �ڵ�
    void SelectLand(Land land)
    {
        //������ ������ ������ false�� ���� (If any)
        if (selectedLand != null)
        {
            selectedLand.Select(false);
        }

        //���� ������ ������ ���� �����ϰ� �ִ� ������ ����
        selectedLand = land;
        land.Select(true);
    }

    //�÷��̾ ���콺 ���� Ŭ�� ���� �� Triggered
    public void Interact()
    {
        //�÷��̾ ������ �����ϰ� �ִ��� Ȯ��
        if (selectedLand != null)
        {
            selectedLand.Interact();
            return;
        }

        Debug.Log("Not on any land!");
    }
}