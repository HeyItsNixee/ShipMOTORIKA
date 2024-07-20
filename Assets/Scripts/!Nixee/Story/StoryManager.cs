using ShipMotorika;
using UnityEngine;

public class StoryManager : Singleton<StoryManager>
{
    [SerializeField] private Quest[] quests;
    private int currentQuestIndex = 0;
    private Quest_Destination bufferedDestination;

    public Quest CurrentQuest => quests[currentQuestIndex];
    public int CurrentQuestID => currentQuestIndex;
    private void Start()
    {
        //Load
        if (currentQuestIndex < 0 || currentQuestIndex >= quests.Length)
            currentQuestIndex = quests.Length - 1;

        quests[currentQuestIndex].InitializeQuest();
    }

    public void OnQuestCompleted()
    {
        if (currentQuestIndex >= quests.Length)
            currentQuestIndex = quests.Length - 1;

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

    public void SetCurrentQuest(int questID)
    {
        if (questID >= quests.Length)
            return;

        currentQuestIndex = questID;
        quests[currentQuestIndex].InitializeQuest();
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
            currentQuestIndex = quests.Length - 1;
        PlayerSettingsHolder.Instance.settings.questID = currentQuestIndex;
        PlayerSettingsHolder.Instance.Save();
        quests[currentQuestIndex].InitializeQuest();
        Debug.Log("Quest cleared, initializing new");
    }

    private void OnDestroy()
    {
        Player.Instance.Money.OnMoneyChanged -= CheckMoney;
    }
}
