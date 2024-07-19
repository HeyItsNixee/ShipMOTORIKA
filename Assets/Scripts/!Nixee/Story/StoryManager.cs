using ShipMotorika;
using UnityEngine;

public class StoryManager : Singleton<StoryManager>
{
    [SerializeField] private Quest[] quests;
    private int currentQuestIndex = 0;
    private Quest_Destination bufferedDestination;

    public Quest CurrentQuest => quests[currentQuestIndex];

    private void Start()
    {
        //Load
        quests[currentQuestIndex].InitializeQuest();
    }

    public void OnQuestCompleted()
    {
        Player.Instance.Money.TryChangeMoneyAmount(quests[currentQuestIndex].Reward);
        UpdateCurrentQuest();
    }


    public void SetDestinationObserve(Quest_Destination questDestOBJ)
    {
        if (questDestOBJ == null)
        {
            Debug.LogWarning("destination is null even though questType is destination");
            return;
        }

        if (bufferedDestination == null)
            bufferedDestination = questDestOBJ;
        else
        {
            Destroy(bufferedDestination.gameObject);
            bufferedDestination = questDestOBJ;
        }
            
    }

    public void SetMapObserve()
    {
       //TBD
    }

    private void CheckMoney()
    {
        var money = Player.Instance.Money;
        if (money.CurrentMoney >= quests[currentQuestIndex].AmountToEarn)
        {
            UpdateCurrentQuest();
            CutSceneManager.Instance.ShowCutScene();
            Player.Instance.Money.OnMoneyChanged -= CheckMoney;
        }
    }

    public void SetMoneyObserve()
    {
        Player.Instance.Money.OnMoneyChanged += CheckMoney;
    }
    

    private void UpdateCurrentQuest()
    {
        /*if (quests[currentQuestIndex].Type == Quest.QuestType.Destination)
        {
            Destroy(Quest_Destination.Instance.gameObject);
        }*/

        currentQuestIndex++;
        if (currentQuestIndex >= quests.Length)
        {
            enabled = false;
            return;
        }
        quests[currentQuestIndex].InitializeQuest();
        Debug.Log("Quest cleared, initializing new");
    }

    private void OnDestroy()
    {
        Player.Instance.Money.OnMoneyChanged -= CheckMoney;
    }
}
