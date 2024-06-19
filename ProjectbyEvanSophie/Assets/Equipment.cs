using System.Collections.Generic;
using UnityEngine;

public class Equipment : Item, IModifier
{
    // The set specifies what GameObjects this equipment is comprised of
    public Enums set;
    
    // Objects is a list of GameObjects that form the equipment
    public List<GameObject> objects;
    
    // We keep track of all the different equipment that are currently equipped by the player
    public static Dictionary<Enums, Equipment> active = new Dictionary<Enums, Equipment>();

    public override void Use(Player player)
    {
        if (active.ContainsKey(set))
        {
            // First deactivate the equipped equipment
            active[set].Unequip(player);

            // Update the active equipment
            active[set] = this;
        }
        else
        {
            active.Add(set, this);
        }
        
        // Equip the new equipment
        Equip(player);
    }

    public virtual void Equip(Player player)
    {
        // Activate all GameObjects that form this equipment
        objects.ForEach(z => z.SetActive(true));
        
        // Update the player stats with the modifier of this equipment
        var stat = player.Get<Stats>(attribute);
        if (stat != null)
        {
            stat.AddModifier(this);
        }
    }

    public virtual void Unequip(Player player)
    {
        // Deactivate all GameObjects that form this equipment
        objects.ForEach(z => z.SetActive(false));
        
        // Update the player stats to remove the modifier of this equipment
        var stat = player.Get<Stats>(attribute);
        if (stat != null)
        {
            stat.RemoveModifier(this);
        }
    }
}
