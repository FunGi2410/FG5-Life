using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public void OnLoadMenuPage()
    {
        SceneManager.LoadScene("MenuScene", LoadSceneMode.Single);
    }

    public void OnLoadHomePage()
    {
        SceneManager.LoadScene("MainScene", LoadSceneMode.Single);
    }

    public void OnLoadGroceryPage()
    {
        SceneManager.LoadScene("GroceryScene", LoadSceneMode.Single);
    }

    public void OnLoadSchoolPage()
    {
        SceneManager.LoadScene("SchoolScene", LoadSceneMode.Single);
    }

    public void OnLoadHospitalPage()
    {
        SceneManager.LoadScene("HospitalScene", LoadSceneMode.Single);
    }

    public void OnLoadElectronicPage()
    {
        SceneManager.LoadScene("ElectronicScene", LoadSceneMode.Single);
    }

    public void OnLoadParkPage()
    {
        SceneManager.LoadScene("ParkScene", LoadSceneMode.Single);
    }

    public void OnLoadNeighborPage()
    {
        SceneManager.LoadScene("NeighborScene", LoadSceneMode.Single);
    }
}
