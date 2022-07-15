using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Events;

public class WeaponView : MonoBehaviour
{
    [SerializeField] private TMP_Text _label;
    [SerializeField] private TMP_Text _price;
    [SerializeField] private Image _icon;
    [SerializeField] private Button _buyButton;

    private Weapon _weapon;

    public Button BuyButton => _buyButton;

    public event UnityAction<Weapon, WeaponView> BuyButtonClick;

    private void OnEnable()
    {
        _buyButton.onClick.AddListener(OnButtonClick);
        _buyButton.onClick.AddListener(TryLockItem);

    }

    private void OnDisable()
    {
        _buyButton.onClick.RemoveListener(OnButtonClick);
        _buyButton.onClick.RemoveListener(TryLockItem);


    }

    private void TryLockItem()
    {
        if (_weapon.IsBuyed)
            _buyButton.interactable = false;
     

    }

    public void Render(Weapon weapon)
    {
        _weapon = weapon;
        _label.text = weapon.Label;
        _icon.sprite = weapon.Icon;
        _price.text = weapon.Price.ToString();
    }
    private void OnButtonClick()
    {
        BuyButtonClick?.Invoke(_weapon, this);
    }
}
