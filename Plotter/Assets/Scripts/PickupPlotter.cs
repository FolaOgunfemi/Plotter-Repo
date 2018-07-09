using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using UnityEngine;
using UnityEngine.UI;


//Read data from csv and place pickups accordingly. 
    // Offer a UI to display information etc

public class PickupPlotter : MonoBehaviour {

    public GameObject pickUp;
        //File Variables
    private static string locationsPath = "Assets/Resources/PickupLocations.csv";
    TextAsset locationsCsv = (TextAsset)Resources.Load(locationsPath);

        //Parsing Variables
    private char lineSeperater = '\n'; // It defines line seperate character
    private char fieldSeperator = ','; // It defines field seperate chracter

        //UI variables
    public Text contentArea;
    public InputField xField;
    public InputField yField;
    public InputField zField;

    void Start()
    {
        readData();
    }
    // Read data from CSV file //return list of coordinates
    private List<string> readData()
    {
            //split csv by rows
        string[] records = locationsCsv.text.Split(lineSeperater);
       

        foreach (string record in records)
        {
                //split records by field seperator
            string[] fieldsArr = record.Split(fieldSeperator);
            List<string> fields = new List<string>(fieldsArr);
            foreach (string field in fields)
            {
                //TODO: foreach, turn the field into a vector3 and return that...
                contentArea.text += field + "\t";
            }
            contentArea.text += '\n';
                return fields;
        }
       
    }
    // Add data to CSV file
    public void addData()
    {
        // Following line adds data to CSV file
        File.AppendAllText(locationsPath, lineSeperater + xField.text + fieldSeperator + yField.text + fieldSeperator + zField.text);
        
            // Following lines refresh the edotor and print data
        xField.text = "";
        yField.text = "";
        zField.text = "";
        contentArea.text = "";
#if UNITY_EDITOR
        UnityEditor.AssetDatabase.Refresh();
#endif
        readData();
    }

    public void updatePickup()
    {
        Debug.Log("update pckup item based on Row");
    }

    private List<Vector3> calcCoordinates(List<string> fields)
    {
        List<Vector3> positions;

        foreach (string field in fields)
        {
            string[] coords = field.Split(':');

                foreach (string axis in coords) {
                    List<float> posList = new List<float>();

                    for (int i = 0; i < 3; i++) {
                      float value  = float.Parse(axis, CultureInfo.InvariantCulture.NumberFormat);
                        posList.Add(value);
                        }

                for (int i = 0; i < (posList.Count); i++)
                {
                    vectors[i] = new Vector3(xFloats[i], yFloats[i], zFloats[i]);
                }
            }
        }
            Vector3 position =
        }

        return positions;

    }
    public void plotPickups(List<Vector3> positions)
    {

    }


}

