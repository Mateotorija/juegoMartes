using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    [SerializeField] private List<Monster> possibleMonsters;
    private List<Monster> currentMonsters = new();
    [SerializeField] private int monstersToCreate;

    public void Start()
    {
        for (int i = 0; i < monstersToCreate; i++)
        {
            Monster newMonster = CreateMonster();
            currentMonsters.Add(newMonster);
        }
        
    }

    private Monster CreateMonster() 
    {
        var monsterIndex = Random.Range(0, possibleMonsters.Count);
        Monster instantiatedMonster = Instantiate(possibleMonsters[monsterIndex]);
        return instantiatedMonster;
    }

    [ContextMenu("SendAttack")]
    public void SendAttack()
    {
        foreach(var monster in currentMonsters)
        {
            monster.Attack();
        }
        
    }

}
