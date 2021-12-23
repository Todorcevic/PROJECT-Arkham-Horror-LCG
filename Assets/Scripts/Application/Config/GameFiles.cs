namespace Arkham.Application
{
    public class GameFiles
    {
        public string DATAFILE_EXTENSION => ".json";
        public string JSON_ROOT_DIRECTORY => "JsonFiles/";
        //const string HISTORIES_PATH = "Histories/";
        public string CAMPAIGNS_DIRECTORY => "Campaigns/";
        public string CAMPAIGNS_STATES => "CampaignStates/";
        //const string CHAOS_BAG_PATH = "ChaosBag/";

        //public const string INVESTIGATOR_BACK_IMAGE = "InvestigatorBack";
        //public const string ENCOUNTER_BACK_IMAGE = "EncounterBack";

        public string ALL_CARDS_DATA_FILE => "AllCardsData";
        public string ALL_CARDS_IMAGE_EN => "AllCardsEN";
        public string SCENARIO_DATA_FILE => "ScenarioInfo";
        //public const string NEW_INVESTIGATORS_FILE = "InvestigatorsDataDefault";
        //public const string CURRENT_INVESTIGATORS_FILE = "InvestigatorsDataSave";
        //public const string TEST_INVESTIGATORS_FILE = "InvestigatorsDataTest";
        public string PLAYER_PROGRESS_FILE => "PlayerProgress";
        public string PLAYER_PROGRESS_DEFAULT_FILE => "PlayerProgressDefault";

        //public const string ENCOUNTER_JSON = "Encounter";
        //public const string ACT_JSON = "Act";
        //public const string AGENDA_JSON = "Agenda";
        //public const string LOCATION_JSON = "Location";
        //public const string SCENARIO_JSON = "Scenario";
        //public const string SPECIAL_JSON = "Special";

        //public static string ScenarioPath => RESOURCE_PATH + GameData.Instance.Chapter + "/" + GameData.Instance.Scenario + "/" + SCENARIO_DECKS_PATH;
        //public static string HistoriesPath => RESOURCE_PATH + GameData.Instance.Chapter + "/" + GameData.Instance.Scenario + "/" + HISTORIES_PATH;
        //public static string ChaosBagPath => RESOURCE_PATH + GameData.Instance.Chapter + "/" + CHAOS_BAG_DIRECTORY;
        //public static string StartedGameFilePath => Application.persistentDataPath + "/" + CURRENT_INVESTIGATORS_FILE + ".json";

        public string CardsDataFilePath => JSON_ROOT_DIRECTORY + ALL_CARDS_DATA_FILE;
        public string PlayerProgressFilePath => UnityEngine.Application.persistentDataPath + "/" + PLAYER_PROGRESS_FILE + DATAFILE_EXTENSION;
        public string PlayerProgressDefaultFilePath => JSON_ROOT_DIRECTORY + PLAYER_PROGRESS_DEFAULT_FILE;
    }
}
