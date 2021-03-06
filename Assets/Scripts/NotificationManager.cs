using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NotificationManager : MonoBehaviour
{
    public Sprite[] RarityImageArray = new Sprite[14];
    public GameObject RarityNotificationButton;
    public Image NotificationImage;

    #region Singleton
    public static NotificationManager Instance;
    private void Awake()
    {
        Instance = this;
    }

    #endregion

    public void ShowRarityNotification(Item item)
    {
        NotificationImage.sprite = RarityImageArray[(int)item.Rarity];
        NotificationImage.enabled = true;
        RarityNotificationButton.SetActive(true);
    }

    public void CloseRarityNotification()
    {
        NotificationImage.enabled = false;
        RarityNotificationButton.SetActive(true);
    }
}
