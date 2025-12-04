using System;

namespace GildedRoseKata.Updaters;

/// <summary>
/// Updater pour les articles "Backstage passes" (passes pour concerts/événements).
/// 
/// Règles métier des Backstage passes :
/// - La qualité augmente à mesure que la date du concert approche
/// - La qualité augmente de 1 point par jour quand il reste plus de 10 jours (SellIn > 10)
/// - La qualité augmente de 2 points par jour quand il reste 10 jours ou moins (6 ≤ SellIn ≤ 10)
/// - La qualité augmente de 3 points par jour quand il reste 5 jours ou moins (1 ≤ SellIn ≤ 5)
/// - La qualité tombe à 0 après le concert (SellIn < 0)
/// - La qualité ne peut jamais dépasser 50 (maximum 50)
/// - Le SellIn diminue de 1 point par jour
/// 
/// Exemples :
/// - Article avec SellIn = 15, Quality = 10 → après 1 jour : SellIn = 14, Quality = 11
/// - Article avec SellIn = 10, Quality = 10 → après 1 jour : SellIn = 9, Quality = 12
/// - Article avec SellIn = 5, Quality = 10 → après 1 jour : SellIn = 4, Quality = 13
/// - Article avec SellIn = 0, Quality = 20 → après 1 jour : SellIn = -1, Quality = 0 (concert passé)
/// </summary>
public class BackstagePassUpdater : IItemUpdater
{
    /// <summary>
    /// Met à jour la qualité et la valeur SellIn d'un Backstage pass.
    /// </summary>
    /// <param name="item">L'article à mettre à jour</param>
    public void UpdateItem(Item item)
    {
        // Diminue le nombre de jours restants avant le concert
        item.SellIn--;
        
        // Après le concert, la qualité tombe à 0
        if (item.SellIn < 0)
        {
            item.Quality = 0;
            return;
        }
        
        // 5 jours ou moins avant le concert : +3 points
        if (item.SellIn < 5)
        {
            item.Quality = Math.Min(50, item.Quality + 3);
        }
        // 10 jours ou moins avant le concert : +2 points
        else if (item.SellIn < 10)
        {
            item.Quality = Math.Min(50, item.Quality + 2);
        }
        // Plus de 10 jours avant le concert : +1 point
        else
        {
            item.Quality = Math.Min(50, item.Quality + 1);
        }
    }
}
