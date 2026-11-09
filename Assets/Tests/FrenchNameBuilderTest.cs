using NUnit.Framework;

public class FrenchNameBuilderTest : BaseNameBuilderTest
{
    protected override string GetLocaleName()
    {
        return "fr";
    }

    // A Test behaves as an ordinary method
    [Test]
    [TestCase("Fish", new[] { "Nageoires" }, "Nageoires")]
    [TestCase("Fish", new[] { "Blanc", "Poisson" }, "Poisson blanc")] // Let's try genders
    [TestCase("Fish", new[] { "Blanc", "Carpe" }, "Carpe blanche")]   // ...
    [TestCase("Fish", new[] { "Nageoires", "Doré" }, "Nageoires dorées")]   // ...
    [TestCase("Fish", new[] { "Écailles", "Doré" }, "Écailles dorées")]   // Plurals
    [TestCase("Fish", new[] { "Écailles", "Tacheté" }, "Écailles tachetées")]   // ...
    [TestCase("Fish", new[] { "Nageoires", "Blanc", "Poisson" }, "Poisson aux nageoires blanches")]   // A name and two adjectives
    [TestCase("Fish", new[] { "Poisson", "Doré", "Dos" }, "Poisson à dos doré")]
    [TestCase("Fish", new[] { "Poisson", "Écailles", "Tacheté" }, "Poisson aux écailles tachetées")]
    
    // Only adjectives : will look up for the first adjective usable as a noun. Only 'tacheté' in our case. 
    [TestCase("Fish", new[] { "Tacheté", "Doré", "Blanc" }, "Taches dorées et blanches")]
    [TestCase("Fish", new[] { "Doré", "Tacheté", "Blanc" }, "Taches dorées et blanches")]
    [TestCase("Fish", new[] { "Blanc", "Doré", "Tacheté" }, "Taches blanches et dorées")]
    
    [TestCase("Fish", new[] { "Nageoires", "Écailles" }, "Nageoires et écailles")]
    [TestCase("Fish", new[] { "Nageoires", "Écailles", "Doré" }, "Nageoires et écailles dorées")] 
    [TestCase("Fish", new[] { "Dos", "Nageoires", "Écailles" }, "Dos et nageoires et écailles")]
    
    // Some equivalents
    // - "Water dweller" : créature aquatique // qui vit dans l'eau
    // - "Water dwelling fish" : poisson qui vit dans l'eau
    // - "Gold water dwelling fish" : poisson doré qui vit dans l'eau
    // - "Teemer" : grouille // fourmille // abonde
    // - "Teeming fish" : poisson qui grouille // abondant
    // - "Dreamer", "Dreaming carp" : rêveur, carpe rêveuse
    
    public void FrenchNameBuilderFish(string animalName, string[] inputWords, string expectedName)
    {
        TestNameCombo(animalName, inputWords, expectedName);
    }
}
