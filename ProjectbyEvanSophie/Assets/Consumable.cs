using UnityEngine;

public class Consumable : Item
{
    public override void Use(Player player)
    {
        // Increase the player's attribute by the item's amount
        var notifier = player.Get<Notifier>(attribute) as Notifier;
        notifier.Add(Amount);
    }
}