using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int Capacity { get; private set; }

    [SerializeField]
    private InventoryUi _inventoryUI; // ����� �κ��丮 UI

    /// <summary> ������ ��� </summary>
    [SerializeField]
    private Item[] _items;



}