using System;

namespace GildedRoseKata.Updaters;

/// <summary>
/// Updater pour les articles "Conjured" (invoqués/enchantés).
/// 
/// Règles métier des articles Conjured :
/// - Les articles Conjured se dégradent deux fois plus vite que les articles normaux
/// - La qualité diminue de 2 points par jour avant la date de péremption
/// - La qualité diminue de 4 points par jour après la date de péremption (SellIn < 0)
/// - La qualité ne peut jamais être négative (minimum 0)
/// - Le SellIn diminue de 1 point par jour
/// 
/// Exemples :
/// - Article avec SellIn = 5, Quality = 10 → après 1 jour : SellIn = 4, Quality = 8
/// - Article avec SellIn = 0, Quality = 10 → après 1 jour : SellIn = -1, Quality = 6
/// - Article avec SellIn = -1, Quality = 3 → après 1 jour : SellIn = -2, Quality = 0 (ne descend pas en dessous de 0)
/// </summary>
public class ConjuredUpdater : IItemUpdater
{
    /// <summary>
    /// Met à jour la qualité et la valeur SellIn d'un article Conjured.
    /// </summary>
    /// <param name="item">L'article à mettre à jour</param>
    public void UpdateItem(Item item)
    {
        // Diminue le nombre de jours restants avant péremption
        item.SellIn--;
        
        // La qualité diminue de 2 points (avant péremption) ou 4 points (après péremption)
        // et ne peut jamais descendre en dessous de 0
        item.Quality = Math.Max(0, item.Quality - (item.SellIn < 0 ? 4 : 2));
    }
}
