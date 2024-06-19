using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float xpGain, maxHp, maxMana, maxXp, baseStr, baseDef, baseInt;
    [SerializeField] private Attribute strength, defense, intelligence, hp, mana, xp;
    [SerializeField] private Dictionary<Attribute, Wrapper> stats = new Dictionary<Attribute, Wrapper>();

    private void Awake()
    {
        stats.Add(strength, new Stats(baseStr));
        stats.Add(defense, new Stats(baseDef));
        stats.Add(intelligence, new Stats(baseInt));
        stats.Add(hp, new Notifier(maxHp, maxHp));
        stats.Add(mana, new Notifier(maxMana, maxMana));
        stats.Add(xp, new Notifier(0, maxXp));
    }

    internal void AddXP()
    {
        var stat = Get<Notifier>(xp);
        stat.Add(xpGain);
        if (stat.Amount >= stat.Max)
        {
            stat.Add(-1 * stat.Max);
            LevelUp();
        }
    }

    private void LevelUp()
    {
        Get<Stats>(strength).Upgrade();
        Get<Stats>(defense).Upgrade();
        Get<Stats>(intelligence).Upgrade();
    }

    public float TotalDmg
    {
        get
        {
            var str = Get<Stats>(strength);
            return str != null ? str.Total : 0;
        }
    }

    public float SpellDmg
    {
        get
        {
            var intel = Get<Stats>(intelligence);
            return intel != null ? intel.Total : 0;
        }
    }

    internal bool Cast(float spellCost)
    {
        var stat = Get<Notifier>(mana);
        if (stat.Amount >= spellCost)
        {
            stat.Add(-spellCost);
            return true;
        }
        return false;
    }

    public void ReceiveDmg(float damage)
    {
        var stat = Get<Notifier>(hp);
        stat.Add(Get<Stats>(defense).Total - damage);
        // Assuming there's an animator component for player reactions
        GetComponent<Animator>().SetTrigger("React");
    }

    public T Get<T>(Attribute attribute) where T : Wrapper
    {
        if (!stats.ContainsKey(attribute))
            return null;
        return stats[attribute] as T;
    }
}