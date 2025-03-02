using UnityEngine;

public class GunShopTab : MonoBehaviour
{
    [SerializeField] private GameObject _contentObj;
    [SerializeField] private GameObject _shopItemPrefab;

    private GameObject _shopItem;

    void Start()
    {
        CreateAllItems();
    }

    private void CreateAllItems()
    {
        foreach(LRWeaponObject weapon in Weapons.LRWeaponDict.Values)
        {
            _shopItem = Instantiate(_shopItemPrefab, _contentObj.transform);
            _shopItem.GetComponent<WeaponShopItem>().Init(weapon);
        }
    }
}
