namespace GildedRoseKata.Updaters;

public class ItemUpdaterFactory
{
    public static IItemUpdater Create(Item item)
    {
        return item switch
        {
            { Name: "Aged Brie" } => new AgedBrieUpdater(),
            { Name: "Sulfuras, Hand of Ragnaros" } => new SulfurasUpdater(),
            { Name: "Backstage passes to a TAFKAL80ETC concert" } => new BackstagePassUpdater(),
            //{ Name: "Conjured Mana Cake" } => new ConjuredUpdater(),
            _ => new NormalItemUpdater()
        };
    }
}
