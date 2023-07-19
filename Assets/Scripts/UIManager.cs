using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TMP_Text _ammoText;

    public void UpdateAmmo(int count)
    {
        _ammoText.text = "Ammo : " + count.ToString();
    }
}
