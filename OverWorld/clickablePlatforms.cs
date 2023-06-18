using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clickablePlatforms : MonoBehaviour
{
    private Manager gm;
    private GameObject player;
    public GameObject[] nextfoodoptions;
    public GameObject[] nextfightoptions;
    public GameObject[] nextboss;
    public GameObject[] disabledoptions;

    public int coinsRewarded;
    public int diamondsRewarded;
    public bool PlayerResetPos;


    private void Start()
    {
        gm = GameObject.Find("manager").GetComponent<Manager>();
        player = GameObject.Find("Player");

    }
    private void OnMouseDown()
    {
        if (gameObject.tag == "fight" || gameObject.tag == "food" || gameObject.tag == "boss")
        {

            if (gameObject.tag == "food")
            {
                gameObject.GetComponent<Animator>().SetTrigger("Disappear");

                globalObject.Instance.foodPlatforms = new List<string>();
                for (int i = 0; i <= nextfoodoptions.Length - 1; i++)
                {
                    globalObject.Instance.foodPlatforms.Add(nextfoodoptions[i].name);

                }
                for (int i = 0; i <= nextfightoptions.Length - 1; i++)
                {
                    globalObject.Instance.fightPlatforms.Add(nextfightoptions[i].name);
                }
                Destroy(gameObject); 

                gameObject.GetComponent<takeFood>().Intake();

            }
            else if (gameObject.tag == "fight" || gameObject.tag == "boss")
            {
                if (gameObject.GetComponent<takeFight>() != null)
                {
                    globalObject.Instance.foodPlatforms = new List<string>();
                    for (int i = 0; i <= nextfoodoptions.Length - 1; i++)
                    {
                        globalObject.Instance.foodPlatforms.Add(nextfoodoptions[i].name);

                    }
                    for (int i = 0; i <= nextfightoptions.Length - 1; i++)
                    {
                        globalObject.Instance.fightPlatforms.Add(nextfightoptions[i].name);
                    }
                    Destroy(gameObject);

                    gameObject.GetComponent<takeFight>().StartFight();
                }
            }

            gm.MovePlayer(gameObject);
            gameObject.tag = "locked";

            if (PlayerResetPos == true)
            {
                Manager.fixedPosition = Vector3.zero;
                ES3.Save<Vector3>("playerPos", Vector3.zero);
                Debug.Log("PosChanged;");
            }


            gm.TagChange(nextfoodoptions, "food");
            gm.TagChange(nextfightoptions, "fight");
            gm.TagChange(nextboss, "boss");
            gm.TagChange(disabledoptions, "locked");



            //Rewards
            PlayerInOverWorld.coins += coinsRewarded;
            PlayerInOverWorld.diamonds += diamondsRewarded;
            player.GetComponent<PlayerInOverWorld>().ChangeText();

        }
    }


}
