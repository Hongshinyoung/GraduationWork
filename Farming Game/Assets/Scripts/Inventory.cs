using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int Capacity { get; private set; }

    [SerializeField]
    private InventoryUi _inventoryUI; // 연결된 인벤토리 UI

    /// <summary> 아이템 목록 </summary>
    [SerializeField]
    private Item[] _items;



}