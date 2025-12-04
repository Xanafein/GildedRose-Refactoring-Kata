namespace GildedRoseKata.Updaters;

/// <summary>
/// Updater pour l'article légendaire "Sulfuras, Hand of Ragnaros".
/// 
/// Règles métier de Sulfuras :
/// - Article légendaire qui ne se dégrade jamais
/// - La qualité reste toujours à 80 (valeur fixe)
/// - Le SellIn ne change jamais
/// - Cet article n'a pas besoin d'être vendu ou mis à jour
/// 
/// Note : "Sulfuras is legen...wait for it...dary!" - Un article légendaire immortel
/// qui conserve ses propriétés magiques pour l'éternité.
/// 
/// Exemples :
/// - Article avec SellIn = 0, Quality = 80 → après 1 jour : SellIn = 0, Quality = 80 (aucun changement)
/// - Article avec SellIn = 5, Quality = 80 → après 1 jour : SellIn = 5, Quality = 80 (aucun changement)
/// </summary>
public class SulfurasUpdater : IItemUpdater
{
    /// <summary>
    /// "Met à jour" Sulfuras (ne fait rien car c'est un article légendaire immuable).
    /// </summary>
    /// <param name="item">L'article légendaire (non modifié)</param>
    public void UpdateItem(Item item)
    {
        // Sulfuras is legen...wait for it...dary! Les articles légendaires ne changent jamais
        // Ni la qualité, ni le SellIn ne sont modifiés
    }
}
