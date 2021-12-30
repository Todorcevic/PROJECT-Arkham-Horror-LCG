using System.Collections.Generic;

namespace Arkham.Application
{
    public class GameFiles
    {
        private const string DATAFILE_EXTENSION = ".json";
        private const string JSON_ROOT_DIRECTORY = "JsonFiles/";
        private const string CAMPAIGNS_DIRECTORY = JSON_ROOT_DIRECTORY + "Campaigns/";

        public string CAMPAIGNS_STATES => "CampaignStates/";
        public string INVESTIGATOR_BACK_IMAGE => "InvestigatorBack";
        public string ENCOUNTER_BACK_IMAGE => "EncounterBack";
        public string ALL_CARDS_DATA_FILE => "AllCardsData";
        public string ALL_CARDS_IMAGE_EN => "AllCardsEN";
        //public string SCENARIO_DATA_FILE => "ScenarioInfo";
        //public const string NEW_INVESTIGATORS_FILE = "InvestigatorsDataDefault";
        //public const string CURRENT_INVESTIGATORS_FILE = "InvestigatorsDataSave";
        //public const string TEST_INVESTIGATORS_FILE = "InvestigatorsDataTest";
        public string PLAYER_PROGRESS_FILE => "PlayerProgress" + DATAFILE_EXTENSION;
        public string PLAYER_PROGRESS_DEFAULT_FILE => "PlayerProgressDefault";
        public List<string> ALL_SCENARIO_CARDS_FILES => new List<string>
        {
            "Encounter",
            "Act",
            "Agenda",
            "Location",
            "Scenario",
            "Special"
        };

        //public static string HistoriesPath => RESOURCE_PATH + GameData.Instance.Chapter + "/" + GameData.Instance.Scenario + "/" + HISTORIES_PATH;
        //public static string ChaosBagPath => RESOURCE_PATH + GameData.Instance.Chapter + "/" + CHAOS_BAG_DIRECTORY;
        //public static string StartedGameFilePath => Application.persistentDataPath + "/" + CURRENT_INVESTIGATORS_FILE + ".json";

        public string CardsDataFilePath => JSON_ROOT_DIRECTORY + ALL_CARDS_DATA_FILE;
        public string PlayerProgressFilePath => UnityEngine.Application.persistentDataPath + "/" + PLAYER_PROGRESS_FILE;
        public string PlayerProgressDefaultFilePath => JSON_ROOT_DIRECTORY + PLAYER_PROGRESS_DEFAULT_FILE;

        /*******************************************************************/
        public string DeckPath(string scenario) => CAMPAIGNS_DIRECTORY + scenario + "/Decks/";
        public string ChaosBagPath(string scenario) => CAMPAIGNS_DIRECTORY + scenario + "/ChaosBag/";
        public string HistoriesFilePath(string scenario) => CAMPAIGNS_DIRECTORY + scenario + "/Histories" + DATAFILE_EXTENSION;
    }
}
