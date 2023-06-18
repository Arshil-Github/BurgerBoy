using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.TextCore.LowLevel;

public class Manager : MonoBehaviour
{
    public GameObject player;
    public Animator anim;
    public static Vector3 fixedPosition;
    public bool loadPos;
    public GameObject hungermetre;

    private void Awake()
    {
        if (ES3.KeyExists("foodPlatforms"))
        {
            globalObject.Instance.foodPlatforms = ES3.Load<List<string>>("foodPlatforms");
        }
        if (ES3.KeyExists("fightPlatforms"))
        {
            globalObject.Instance.fightPlatforms = ES3.Load<List<string>>("fightPlatforms");
        }
        globalObject.Instance.ChangeTagFood();
        globalObject.Instance.ChangeTagFight();
    }
    private void Start()
    {
        CutSceneManager.Instance.PlayAfterFightCutScene();

    }
    public void MovePlayer(GameObject g)
    {
        anim.Play("ShrinkOut");
        if(anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !anim.IsInTransition(0))
        {
            player.transform.position = g.transform.position;
            fixedPosition = g.transform.position;

            ES3.Save<Vector3>("playerPos", fixedPosition);

            anim.Play("Idle");
        }

    }

    public void TagChange(GameObject[] options, string tagname)
    {   
        for(int i = 0; i < options.Length; i++)
        {
            options[i].tag = tagname;
        }
    }
    
}
