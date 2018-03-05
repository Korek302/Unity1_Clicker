using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public interface IButtonInterface: IEventSystemHandler
{
    void Message();
}

public class GameLoop : MonoBehaviour, IButtonInterface
{
    public void Message()
    {
        transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
    }

    void Start()
    {

    }
}
