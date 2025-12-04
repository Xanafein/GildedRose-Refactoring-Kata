using System.Collections.Generic;
using GildedRoseKata;
using NUnit.Framework;

namespace GildedRoseTests;

public class GildedRoseTest
{
    #region Normal Items Tests

    [Test]
    public void NormalItem_BeforeSellDate_QualityDecreasesBy1()
    {
        var items = new List<Item> { new Item { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20 } };
        var app = new GildedRose(items);
        app.UpdateQuality();
        
        Assert.That(items[0].SellIn, Is.EqualTo(9));
        Assert.That(items[0].Quality, Is.EqualTo(19));
    }

    [Test]
    public void NormalItem_AfterSellDate_QualityDecreasesBy2()
    {
        var items = new List<Item> { new Item { Name = "+5 Dexterity Vest", SellIn = 0, Quality = 20 } };
        var app = new GildedRose(items);
        app.UpdateQuality();
        
        Assert.That(items[0].SellIn, Is.EqualTo(-1));
        Assert.That(items[0].Quality, Is.EqualTo(18));
    }

    [Test]
    public void NormalItem_QualityNeverNegative()
    {
        var items = new List<Item> { new Item { Name = "Elixir of the Mongoose", SellIn = 5, Quality = 0 } };
        var app = new GildedRose(items);
        app.UpdateQuality();
        
        Assert.That(items[0].Quality, Is.EqualTo(0));
    }

    [Test]
    public void NormalItem_QualityNeverNegativeAfterSellDate()
    {
        var items = new List<Item> { new Item { Name = "Elixir of the Mongoose", SellIn = -1, Quality = 0 } };
        var app = new GildedRose(items);
        app.UpdateQuality();
        
        Assert.That(items[0].Quality, Is.EqualTo(0));
    }

    #endregion

    #region Aged Brie Tests

    [Test]
    public void AgedBrie_BeforeSellDate_QualityIncreasesBy1()
    {
        var items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 10, Quality = 20 } };
        var app = new GildedRose(items);
        app.UpdateQuality();
        
        Assert.That(items[0].SellIn, Is.EqualTo(9));
        Assert.That(items[0].Quality, Is.EqualTo(21));
    }

    [Test]
    public void AgedBrie_AfterSellDate_QualityIncreasesBy2()
    {
        var items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 0, Quality = 20 } };
        var app = new GildedRose(items);
        app.UpdateQuality();
        
        Assert.That(items[0].SellIn, Is.EqualTo(-1));
        Assert.That(items[0].Quality, Is.EqualTo(22));
    }

    [Test]
    public void AgedBrie_QualityNeverAbove50()
    {
        var items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 10, Quality = 50 } };
        var app = new GildedRose(items);
        app.UpdateQuality();
        
        Assert.That(items[0].Quality, Is.EqualTo(50));
    }

    [Test]
    public void AgedBrie_QualityNeverAbove50AfterSellDate()
    {
        var items = new List<Item> { new Item { Name = "Aged Brie", SellIn = -1, Quality = 49 } };
        var app = new GildedRose(items);
        app.UpdateQuality();
        
        Assert.That(items[0].Quality, Is.EqualTo(50));
    }

    [Test]
    public void AgedBrie_QualityIncreasesFrom0()
    {
        var items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 2, Quality = 0 } };
        var app = new GildedRose(items);
        app.UpdateQuality();
        
        Assert.That(items[0].Quality, Is.EqualTo(1));
    }

    #endregion

    #region Sulfuras Tests

    [Test]
    public void Sulfuras_QualityNeverChanges()
    {
        var items = new List<Item> { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 } };
        var app = new GildedRose(items);
        app.UpdateQuality();
        
        Assert.That(items[0].Quality, Is.EqualTo(80));
    }

    [Test]
    public void Sulfuras_SellInNeverChanges()
    {
        var items = new List<Item> { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 } };
        var app = new GildedRose(items);
        app.UpdateQuality();
        
        Assert.That(items[0].SellIn, Is.EqualTo(0));
    }

    [Test]
    public void Sulfuras_WithNegativeSellIn_NeverChanges()
    {
        var items = new List<Item> { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 80 } };
        var app = new GildedRose(items);
        app.UpdateQuality();
        
        Assert.That(items[0].SellIn, Is.EqualTo(-1));
        Assert.That(items[0].Quality, Is.EqualTo(80));
    }

    #endregion

    #region Backstage Passes Tests

    [Test]
    public void BackstagePasses_MoreThan10Days_QualityIncreasesBy1()
    {
        var items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 20 } };
        var app = new GildedRose(items);
        app.UpdateQuality();
        
        Assert.That(items[0].SellIn, Is.EqualTo(14));
        Assert.That(items[0].Quality, Is.EqualTo(21));
    }

    [Test]
    public void BackstagePasses_10DaysOrLess_QualityIncreasesBy2()
    {
        var items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 20 } };
        var app = new GildedRose(items);
        app.UpdateQuality();
        
        Assert.That(items[0].SellIn, Is.EqualTo(9));
        Assert.That(items[0].Quality, Is.EqualTo(22));
    }

    [Test]
    public void BackstagePasses_5DaysOrLess_QualityIncreasesBy3()
    {
        var items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 20 } };
        var app = new GildedRose(items);
        app.UpdateQuality();
        
        Assert.That(items[0].SellIn, Is.EqualTo(4));
        Assert.That(items[0].Quality, Is.EqualTo(23));
    }

    [Test]
    public void BackstagePasses_AfterConcert_QualityDropsTo0()
    {
        var items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 20 } };
        var app = new GildedRose(items);
        app.UpdateQuality();
        
        Assert.That(items[0].SellIn, Is.EqualTo(-1));
        Assert.That(items[0].Quality, Is.EqualTo(0));
    }

    [Test]
    public void BackstagePasses_QualityNeverAbove50()
    {
        var items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 49 } };
        var app = new GildedRose(items);
        app.UpdateQuality();
        
        Assert.That(items[0].Quality, Is.EqualTo(50));
    }

    [Test]
    public void BackstagePasses_At5Days_QualityNeverAbove50()
    {
        var items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 49 } };
        var app = new GildedRose(items);
        app.UpdateQuality();
        
        Assert.That(items[0].Quality, Is.EqualTo(50));
    }

    [Test]
    public void BackstagePasses_At1Day_QualityIncreasesBy3()
    {
        var items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 1, Quality = 20 } };
        var app = new GildedRose(items);
        app.UpdateQuality();
        
        Assert.That(items[0].SellIn, Is.EqualTo(0));
        Assert.That(items[0].Quality, Is.EqualTo(23));
    }

    #endregion

    #region Conjured Items Tests (Normal Behavior and new Behavior)

    [Test]
    public void ConjuredItem_BeforeSellDate_NormalBehavior()
    {
        var items = new List<Item> { new Item { Name = "Conjured Mana Cake", SellIn = 3, Quality = 6 } };
        var app = new GildedRose(items);
        app.UpdateQuality();
        
        // Actuellement traité comme un item normal
        Assert.That(items[0].SellIn, Is.EqualTo(2));
        Assert.That(items[0].Quality, Is.EqualTo(5));
    }

    [Test]
    public void ConjuredItem_AfterSellDate_NormalBehavior()
    {
        var items = new List<Item> { new Item { Name = "Conjured Mana Cake", SellIn = 0, Quality = 6 } };
        var app = new GildedRose(items);
        app.UpdateQuality();
        
        // Actuellement traité comme un item normal
        Assert.That(items[0].SellIn, Is.EqualTo(-1));
        Assert.That(items[0].Quality, Is.EqualTo(4));
    }

    //[Test]
    //public void ConjuredItem_BeforeSellDate_NewBehavior()
    //{
    //    var items = new List<Item> { new Item { Name = "Conjured Mana Cake", SellIn = 3, Quality = 6 } };
    //    var app = new GildedRose(items);
    //    app.UpdateQuality();

    //    Assert.That(items[0].SellIn, Is.EqualTo(2));
    //    Assert.That(items[0].Quality, Is.EqualTo(4));
    //}

    //[Test]
    //public void ConjuredItem_AfterSellDate_NewBehavior()
    //{
    //    var items = new List<Item> { new Item { Name = "Conjured Mana Cake", SellIn = 0, Quality = 6 } };
    //    var app = new GildedRose(items);
    //    app.UpdateQuality();

    //    Assert.That(items[0].SellIn, Is.EqualTo(-1));
    //    Assert.That(items[0].Quality, Is.EqualTo(2));
    //}

    #endregion

    #region Multiple Items Tests

    [Test]
    public void MultipleItems_AllUpdateCorrectly()
    {
        var items = new List<Item>
        {
            new Item { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20 },
            new Item { Name = "Aged Brie", SellIn = 2, Quality = 0 },
            new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 }
        };
        var app = new GildedRose(items);
        app.UpdateQuality();
        
        Assert.That(items[0].Quality, Is.EqualTo(19));
        Assert.That(items[1].Quality, Is.EqualTo(1));
        Assert.That(items[2].Quality, Is.EqualTo(80));
    }

    #endregion

    #region Edge Cases

    [Test]
    public void EmptyItemList_DoesNotThrowException()
    {
        var items = new List<Item>();
        var app = new GildedRose(items);
        
        Assert.DoesNotThrow(() => app.UpdateQuality());
    }

    [Test]
    public void NormalItem_QualityAt1AfterSellDate_DecreasesTo0()
    {
        var items = new List<Item> { new Item { Name = "Normal Item", SellIn = -1, Quality = 1 } };
        var app = new GildedRose(items);
        app.UpdateQuality();
        
        Assert.That(items[0].Quality, Is.EqualTo(0));
    }

    [Test]
    public void AgedBrie_QualityAt49AfterSellDate_IncreasesTo50Only()
    {
        var items = new List<Item> { new Item { Name = "Aged Brie", SellIn = -1, Quality = 49 } };
        var app = new GildedRose(items);
        app.UpdateQuality();
        
        Assert.That(items[0].Quality, Is.EqualTo(50));
    }

    #endregion

    #region Multi-Day Simulation Tests

    [Test]
    public void NormalItem_MultiDaySimulation()
    {
        var items = new List<Item> { new Item { Name = "Normal Item", SellIn = 5, Quality = 10 } };
        var app = new GildedRose(items);
        
        // Day 1-5 (before sell date)
        for (int i = 0; i < 5; i++)
        {
            app.UpdateQuality();
        }
        Assert.That(items[0].SellIn, Is.EqualTo(0));
        Assert.That(items[0].Quality, Is.EqualTo(5));
        
        // Day 6 (after sell date)
        app.UpdateQuality();
        Assert.That(items[0].SellIn, Is.EqualTo(-1));
        Assert.That(items[0].Quality, Is.EqualTo(3));
    }

    [Test]
    public void BackstagePasses_CompleteLifecycle()
    {
        var items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 20 } };
        var app = new GildedRose(items);
        
        // Days 1-5: More than 10 days, +1 per day
        for (int i = 0; i < 5; i++)
        {
            app.UpdateQuality();
        }
        Assert.That(items[0].SellIn, Is.EqualTo(10));
        Assert.That(items[0].Quality, Is.EqualTo(25));
        
        // Days 6-10: 10 to 6 days, +2 per day
        for (int i = 0; i < 5; i++)
        {
            app.UpdateQuality();
        }
        Assert.That(items[0].SellIn, Is.EqualTo(5));
        Assert.That(items[0].Quality, Is.EqualTo(35));
        
        // Days 11-15: 5 to 1 days, +3 per day
        for (int i = 0; i < 5; i++)
        {
            app.UpdateQuality();
        }
        Assert.That(items[0].SellIn, Is.EqualTo(0));
        Assert.That(items[0].Quality, Is.EqualTo(50));
        
        // Day 16: After concert, drops to 0
        app.UpdateQuality();
        Assert.That(items[0].SellIn, Is.EqualTo(-1));
        Assert.That(items[0].Quality, Is.EqualTo(0));
    }

    #endregion
}