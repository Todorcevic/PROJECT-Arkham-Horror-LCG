using System.Collections.Generic;

namespace Arkham.Application
{
    public class GameFiles
    {
        private const string DATAFILE_EXTENSION = ".json";
        private const string JSON_ROOT_DIRECTORY = "JsonFiles/";
        private const string CAMPAIGNS_DIRECTORY = JSON_ROOT_DIRECTORY + "Campaigns/";

        public string CAMPAIGNS_STATES => "CampaignStates/";
        //public const string INVESTIGATOR_BACK_IMAGE = "InvestigatorBack";
        //public const string ENCOUNTER_BACK_IMAGE = "EncounterBack";
        public string ALL_CARDS_DATA_FILE => "AllCardsData";
        public string ALL_CARDS_IMAGE_EN => "AllCardsEN";
        //public string SCENARIO_DATA_FILE => "ScenarioInfo";
        //public const string NEW_INVESTIGATORS_FILE = "InvestigatorsDataDefault";
        //public const string CURRENT_INVESTIGATORS_FILE = "InvestigatorsDataSave";
        //public const string TEST_INVESTIGATORS_FILE = "InvestigatorsDataTest";
        public string PLAYER_PROGRESS_FILE => "PlayerProgress";
        public string PLAYER_PROGRESS_DEFAULT_FILE => "PlayerProgressDefault";
        private string ENCOUNTER_JSON => "Encounter";
        private string ACT_JSON => "Act";
        private string AGENDA_JSON => "Agenda";
        private string LOCATION_JSON => "Location";
        private string SCENARIO_JSON => "Scenario";
        private string SPECIAL_JSON => "Special";
        public List<string> ALL_SCENARIO_CARDS_FILES => new List<string>
        {
            ENCOUNTER_JSON,
            ACT_JSON,
            AGENDA_JSON,
            LOCATION_JSON,
            SCENARIO_JSON,
            SPECIAL_JSON
        };

        //public static string HistoriesPath => RESOURCE_PATH + GameData.Instance.Chapter + "/" + GameData.Instance.Scenario + "/" + HISTORIES_PATH;
        //public static string ChaosBagPath => RESOURCE_PATH + GameData.Instance.Chapter + "/" + CHAOS_BAG_DIRECTORY;
        //public static string StartedGameFilePath => Application.persistentDataPath + "/" + CURRENT_INVESTIGATORS_FILE + ".json";

        public string CardsDataFilePath => JSON_ROOT_DIRECTORY + ALL_CARDS_DATA_FILE;
        public string PlayerProgressFilePath => UnityEngine.Application.persistentDataPath + "/" + PLAYER_PROGRESS_FILE + DATAFILE_EXTENSION;
        public string PlayerProgressDefaultFilePath => JSON_ROOT_DIRECTORY + PLAYER_PROGRESS_DEFAULT_FILE;

        /*******************************************************************/
        public string DECK_PATH(string scenario) => CAMPAIGNS_DIRECTORY + scenario + "Decks/";
        public string CHAOS_BAG_PATH(string scenario) => CAMPAIGNS_DIRECTORY + scenario + "ChaosBag/";
        public string HistoriesFilePath(string scenario) => CAMPAIGNS_DIRECTORY + scenario + "Histories" + DATAFILE_EXTENSION;
    }
}
