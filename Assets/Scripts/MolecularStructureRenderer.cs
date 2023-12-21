using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MolecularStructureRenderer : MonoBehaviour
{
    public GameObject atomPrefab;
    public GameObject bondPrefab;
    
    
    public Material carbonMaterial;
    public Material hydrogenMaterial;
    
    
    public string jsonString;

    void Start()
    {
        GameObject go = new GameObject();
        // Parse JSON data
        MoleculeData moleculeData = JsonUtility.FromJson<MoleculeData>(jsonString);

        // Draw atoms
        for (int i = 0; i < moleculeData.atoms.elements.number.Length; i++)
        {
            Vector3 position = new Vector3(
                moleculeData.atoms.coords._3d[i * 3],
                moleculeData.atoms.coords._3d[i * 3 + 1],
                moleculeData.atoms.coords._3d[i * 3 + 2]
            );

            GameObject atom = Instantiate(atomPrefab, position, Quaternion.identity);
            atom.transform.SetParent(go.transform);
            int atomicNumber = moleculeData.atoms.elements.number[i];
            if (atomicNumber == 6)
            {
                atom.GetComponent<Renderer>().material = carbonMaterial;
            }
            else if (atomicNumber == 1)
            {
                atom.GetComponent<Renderer>().material = hydrogenMaterial;
            }
        }

        // Draw bonds
        for (int i = 0; i < moleculeData.bonds.connections.index.Length; i += 2)
        {
            int atomIndex1 = moleculeData.bonds.connections.index[i];
            int atomIndex2 = moleculeData.bonds.connections.index[i + 1];

            Vector3 position1 = new Vector3(
                moleculeData.atoms.coords._3d[atomIndex1 * 3],
                moleculeData.atoms.coords._3d[atomIndex1 * 3 + 1],
                moleculeData.atoms.coords._3d[atomIndex1 * 3 + 2]
            );

            Vector3 position2 = new Vector3(
                moleculeData.atoms.coords._3d[atomIndex2 * 3],
                moleculeData.atoms.coords._3d[atomIndex2 * 3 + 1],
                moleculeData.atoms.coords._3d[atomIndex2 * 3 + 2]
            );

            Vector3 position_3 = new Vector3(
                )
            Vector3 bondPosition = (position1 + position2) / 2;

            float bondLength = Vector3.Distance(position1, position2);

            GameObject bond = Instantiate(bondPrefab, bondPosition, Quaternion.identity);

            // Calculate the rotation to look at the second atom
            Vector3    direction = position2 - position1;
            Quaternion rotation  = Quaternion.LookRotation(direction);

            // Apply the rotation to the bond
            bond.transform.rotation   = rotation;
            bond.transform.localScale = new Vector3(3, 3, bondLength*50);
            bond.transform.SetParent(go.transform);
        }
    }
}

// Data from JSON
[System.Serializable]
public class MoleculeData
{
    public AtomsData atoms;
    public BondsData bonds;
    public PropertiesData properties;
}

[System.Serializable]
public class AtomsData
{
    public ElementsData elements;
    public CoordsData coords;
}

[System.Serializable]
public class ElementsData
{
    public int[] number;
}

[System.Serializable]
public class CoordsData
{
    public float[] _3d;
}

[System.Serializable]
public class BondsData
{
    public ConnectionsData connections;
    public int[] order;
}

[System.Serializable]
public class ConnectionsData
{
    public int[] index;
}

[System.Serializable]
public class PropertiesData
{
    public float molecularMass;
    public float meltingPoint;
    public float boilingPoint;
}