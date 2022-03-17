using System.Collections.Generic;
using UnityEngine;
//using Newtonsoft.Json;

namespace TownRally.RallySystem
{

    // TODO: That comes from TownRallyUI - Implement it to RallySystem!
    public class RallyCreator : MonoBehaviour
    {
        private static readonly string PATH_MURRALLY = "rallies/murrally";
        private static readonly string PATH_SCHLOSSBERG = "rallies/schlossberg";

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.M))
            {
                Debug.Log("CREATE RALLY MurRally!!");
                List<Station> stations = new List<Station>();
                stations.Add(CreateStation("r_murrally_s1_header", "r_murrally_s1_desc"));
                stations.Add(CreateStation("Murinsel", "desc_rally_murrally_station2"));
                stations.Add(CreateStation("Murnockerl", "desc_rally_murrally_station3"));
                stations.Add(CreateStation("Besiedlung der Mur", "desc_rally_murrally_station4"));
                stations.Add(CreateStation("Natur", "desc_rally_murrally_station5"));
                stations.Add(CreateStation("Fischfang", "desc_rally_murrally_station6"));
                stations.Add(CreateStation("Das Murkraftwerk", "desc_rally_murrally_station7"));
                stations.Add(CreateStation("Graz und die Mur", "desc_rally_murrally_station8"));
                Description description = this.CreateDescription("desc_rally_murrally");
                Rally rally = CreateRally(0, "MurRally", "./img/tour/main/murrally", description, stations);

                //string rallyData = JsonConvert.SerializeObject(rally);
                //FirebaseDB.EventIn_SaveObjectData.Invoke(PATH_MURRALLY, rallyData);
                Debug.Log("DONE!!!");
            }

            if (Input.GetKeyDown(KeyCode.N))
            {
                Debug.Log("CREATE RALLY Schloﬂberg!!");
                List<Station> stations = new List<Station>();
                stations.Add(CreateStation("Geschichte", "desc_rally_schlossberg_station1"));
                stations.Add(CreateStation("2ter Weltkrieg", "desc_rally_schlossberg_station2"));
                stations.Add(CreateStation("Kriegssteig", "desc_rally_schlossberg_station3"));
                Description description = this.CreateDescription("desc_rally_schlossberg");
                Rally rally = CreateRally(0, "Schloﬂberg", "./img/tour/main/schlossberg", description, stations);

                //string rallyData = JsonConvert.SerializeObject(rally);
                //FirebaseDB.EventIn_SaveObjectData.Invoke(PATH_SCHLOSSBERG, rallyData);
                Debug.Log("DONE!!!");
            }

            if (Input.GetKeyDown(KeyCode.B))
            {
                //FirebaseDB.EventIn_RequestData.Invoke(PATH_SCHLOSSBERG, OnRequestData);
            }
        }

        private void OnRequestData(string dbResponse)
        {
            Debug.Log("TO IT HERE: " + dbResponse);
            //Rally rally = JsonConvert.DeserializeObject<Rally>(dbResponse);
            //Debug.Log("DONE! " + rally.Name);
        }

        private Rally CreateRally(int enumID, string name, string previewImgFolder, Description description, List<Station> stations)
        {
            Rally rally = new Rally();
            rally.EnumID = 0;
            rally.Name = name;
            rally.PreviewImgFolder = previewImgFolder;
            rally.description = description;
            rally.stations = stations;
            return rally;
        }

        private Description CreateDescription(string descriptionTextID)
        {
            Description description = new Description();
            description.DescriptionTextID = descriptionTextID;
            return description;
        }

        private Station CreateStation(string name, string descriptionTextID)
        {
            Station station = new Station();
            station.Name = name;
            Description description = new Description();
            description.DescriptionTextID = descriptionTextID;
            station.description = description;
            return station;
        }
    }
}
