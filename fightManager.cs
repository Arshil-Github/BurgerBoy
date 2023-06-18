using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class fightManager : MonoBehaviour
{
    public Transform popUpPrefab;

    public GameObject player;
    public GameObject[] enemies;

    public GameObject startText;
    public GameObject endText;
    public GameObject[] UI;

    private void Start()
    {
        StartCoroutine(ShowFightText());
    }
    public void CreatePopUp(Vector3 position, int damageAmount)
    {
        Transform damagePopUptransform = Instantiate(popUpPrefab, position, Quaternion.identity);

        TextMeshPro damagePopup = damagePopUptransform.GetComponent<TextMeshPro>();
        damagePopup.SetText(damageAmount.ToString());

    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            SceneManager.LoadScene(0);
        }
        if(player.GetComponent<PlayerMovement>().lost == true)
        {
            player.SetActive(false);
            foreach (GameObject i in enemies)
            {
                i.SetActive(false);
            }
            foreach (GameObject i in UI)
            {
                i.SetActive(false);
            }
            endText.SetActive(true);
            StartCoroutine(EndFight());
        }
    }
    IEnumerator ShowFightText()
    {
        yield return new WaitForSeconds(1);

        startText.SetActive(true);
        StopAllCoroutines();
        StartCoroutine(StartFight());
    }
    IEnumerator StartFight()
    {

        yield return new WaitForSeconds(2);

        player.SetActive(true);
        foreach (GameObject i in UI)
        {
            i.SetActive(true);
        }
        foreach (GameObject i in enemies)
        {
            i.SetActive(true);
        }
        StopAllCoroutines();
    }
    IEnumerator EndFight()
    {

        yield return new WaitForSeconds(3);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        StopAllCoroutines();
    }
}
