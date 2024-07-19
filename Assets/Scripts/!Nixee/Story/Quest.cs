using UnityEngine;

[CreateAssetMenu]
public class Quest : ScriptableObject
{
    public enum QuestType
    {
        Destination,
        RevealAllMapSegments,
        EarnMoney
    }
    [Header("Settings")]
    [SerializeField] private QuestType questType;
    [SerializeField] private int moneyReward;
    [SerializeField] private string questName;
    [SerializeField] private string questDescription;
    [Header("Links")]
    [SerializeField] private Quest_Destination destinationToArrive;
    [SerializeField] private int amountOfMoneyToEarn;


    public QuestType Type => questType;
    public Quest_Destination Destination => destinationToArrive;
    public int Reward => moneyReward;
    public int AmountToEarn => amountOfMoneyToEarn;
    public string QuestName => questName;
    public string QuestDescription => questDescription;

    public void InitializeQuest()
    {
        Debug.Log(questType + "Initialize");
        switch (questType)
        {
            case QuestType.Destination:
                Quest_Destination questDestOBJ = Instantiate(destinationToArrive);
                StoryManager.Instance.SetDestinationObserve(questDestOBJ);
            break;

            case QuestType.RevealAllMapSegments:
                StoryManager.Instance.SetMapObserve();
            break;

            case QuestType.EarnMoney:
                StoryManager.Instance.SetMoneyObserve();
            break;

            default:
            break;
        }
    }

}
