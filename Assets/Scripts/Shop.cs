using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private List<Weapon> _weapons;
    [SerializeField] private Player _player;
    [SerializeField] private WeaponView _template;
    [SerializeField] private GameObject _itemContainer;

    private WeaponView _view;
    private Weapon _weapon;


    private void Start()
    {
        for (int i = 0; i < _weapons.Count; i++)
        {
            AddItem(_weapons[i]);
        }
    }

  

    private void AddItem(Weapon weapon)
    {
        var view = Instantiate(_template, _itemContainer.transform);
        view.BuyButtonClick += OnBuyButtonClick;
        view.Render(weapon);
        weapon._isBuyed = false;
    }

    private void OnBuyButtonClick(Weapon weapon, WeaponView view)
    {
        TrySellWeapon(weapon, view);
    }

    private void TrySellWeapon(Weapon weapon, WeaponView view)
    {
        if (weapon.Price <= _player.Money)
        {
            _player.BuyWeapon(weapon);
            weapon.Buy();
            view.BuyButtonClick -= OnBuyButtonClick;
        }
 
    }
    public void TryInteractButton()
    {
        if (_weapon.Price > _player.Money)
            _view.BuyButton.interactable = false;
      
    }
}
