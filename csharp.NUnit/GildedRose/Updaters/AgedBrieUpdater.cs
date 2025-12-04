using System;

namespace GildedRoseKata.Updaters;

/// <summary>
/// Updater pour l'article spécial "Aged Brie".
/// 
/// Règles métier de l'Aged Brie :
/// - Contrairement aux articles normaux, la qualité AUGMENTE avec le temps
/// - La qualité augmente de 1 point par jour avant la date de péremption
/// - La qualité augmente de 2 points par jour après la date de péremption (SellIn < 0)
/// - La qualité ne peut jamais dépasser 50 (maximum 50)
/// - Le SellIn diminue de 1 point par jour
/// 
/// Exemples :
/// - Article avec SellIn = 5, Quality = 10 → après 1 jour : SellIn = 4, Quality = 11
/// - Article avec SellIn = 0, Quality = 10 → après 1 jour : SellIn = -1, Quality = 12
/// - Article avec SellIn = -1, Quality = 49 → après 1 jour : SellIn = -2, Quality = 50 (ne dépasse pas 50)
/// </summary>
public class AgedBrieUpdater : IItemUpdater
{
    /// <summary>
    /// Met à jour la qualité et la valeur SellIn de l'Aged Brie.
    /// </summary>
    /// <param name="item">L'article à mettre à jour</param>
    public void UpdateItem(Item item)
    {
        // Diminue le nombre de jours restants avant péremption
        item.SellIn--;
        
        // La qualité augmente de 1 point (avant péremption) ou 2 points (après péremption)
        // et ne peut jamais dépasser 50
        item.Quality = Math.Min(50, item.Quality + (item.SellIn < 0 ? 2 : 1));
    }
}
