using ShipMotorika;
using System;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(CircleCollider2D))]
public class Quest_Destination : MonoBehaviour
{
    private CircleCollider2D trigger;

    private void Start()
    {
        trigger = GetComponent<CircleCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.root.gameObject == Player.Instance.gameObject
            && StoryManager.Instance.CurrentQuest.Type == Quest.QuestType.Destination)
        {
            Debug.Log("Destination reached");
            CutSceneManager.Instance.ShowCutScene();
            trigger.enabled = false;
        }
    }
}
