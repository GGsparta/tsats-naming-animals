using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;

public class FrenchNameBuilderTest : BaseNameBuilderTest
{
    protected override string GetLocaleName()
    {
        return "fr";
    }

    // A Test behaves as an ordinary method
    [Test]
    [TestCase("Fish", new string[] { "Nageoires" }, "Nageoires")]
    [TestCase("Fish", new string[] { "Blanc", "Poisson" }, "Poisson blanc")] // Let's try genders
    [TestCase("Fish", new string[] { "Blanc", "Carpe" }, "Carpe blanche")]   // ...
    [TestCase("Fish", new string[] { "Nageoires", "Doré" }, "Nageoires dorées")]   // ...
    [TestCase("Fish", new string[] { "Écailles", "Doré" }, "Écailles dorées")]   // Plurals
    [TestCase("Fish", new string[] { "Écailles", "Tacheté" }, "Écailles tachetées")]   // ...
    [TestCase("Fish", new string[] { "Nageoires", "Blanc", "Poisson" }, "Poisson aux nageoires blanches")]   // A name and two adjectives
    [TestCase("Fish", new string[] { "Poisson", "Doré", "Dos" }, "Poisson à dos doré")]
    [TestCase("Fish", new string[] { "Poisson", "Écailles", "Tacheté" }, "Poisson aux écailles tachetées")]
    [TestCase("Fish", new string[] { "Tacheté", "Doré", "Blanc" }, "À tâches blanches et dorées")] // Three adjectives
    [TestCase("Fish", new string[] { "Doré", "Tacheté", "Blanc" }, "Doré à tâches blanches")] // Three adjectives
    [TestCase("Fish", new string[] { "Blanc", "Doré", "Tacheté" }, "Blanc à tâches dorées")] // Three adjectives
    
    [TestCase("Fish", new string[] { "Nageoires", "Écailles" }, "Nageoires et écailles")]
    [TestCase("Fish", new string[] { "Nageoires", "Écailles", "Doré" }, "Nageoires et écailles dorées")] 
    [TestCase("Fish", new string[] { "Dos", "Nageoires", "Écailles" }, "Dos et nageoires et écailles")]
    
    // Some equivalents
    // - "Water dweller" : créature aquatique // qui vit dans l'eau
    // - "Water dwelling fish" : poisson qui vit dans l'eau
    // - "Gold water dwelling fish" : poisson doré qui vit dans l'eau
    // - "Teemer" : grouille // fourmille // abonde
    // - "Teeming fish" : poisson qui grouille // abondant
    // - "Dreamer", "Dreaming carp" : rêveur, carpe rêveuse
    
    /* TODO:
     * - Introduce 'et' instead of 'aux', except in first position
     * - Add exception for "à tâches" instead of "tacheté" (use adjective as noun and it will affect next adjectives)
     * - "Fish_Adj_as_noun_X" : I suppose it was a workaround when only adjectives were used. Might not be needed anymore.
     */
    public void FrenchNameBuilderFish(string animalName, string[] inputWords, string expectedName)
    {
        TestNameCombo(animalName, inputWords, expectedName);
    }
}
