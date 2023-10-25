using EngineerTest;
using Xunit;

namespace EngineerTestTest;

public class PharmacyTest
{
    [Fact]
    public void TestShouldDecreaseBenefitAndExpiresIn()
    {
        var pharmacy = new Pharmacy();
        pharmacy.AddDrug("test", 2, 3);
        
        Assert.Equal(new Drug[] { new Drug("test", 1, 2)}, 
            pharmacy.UpdateBenefitValue());
    }
    [Fact]
    public void TestNoNegativeBenefit()
    {
        var pharmacy = new Pharmacy();
        pharmacy.AddDrug("test", 2, 1);
        
        Assert.Equal(new Drug[] { new Drug("test", 1, 0)}, 
            pharmacy.UpdateBenefitValue());
        Assert.Equal(new Drug[] { new Drug("test", 0, 0)}, 
            pharmacy.UpdateBenefitValue());
        Assert.Equal(new Drug[] { new Drug("test", -1, 0)}, 
            pharmacy.UpdateBenefitValue());
    }
    [Fact]
    public void TestNoExceedMax()
    {
        var pharmacy = new Pharmacy();
        pharmacy.AddDrug("Fervex", 2, 50);
        
        Assert.Equal(new Drug[] { new Drug("Fervex", 1, 50)}, 
            pharmacy.UpdateBenefitValue());
        Assert.Equal(new Drug[] { new Drug("Fervex", 0, 50)}, 
            pharmacy.UpdateBenefitValue());
    }
    [Fact]
    public void TestCase()
    {
        var pharmacy = new Pharmacy();
        pharmacy.AddDrug("Doliprane", 20, 30);
        pharmacy.AddDrug("Herbal Tea", 10, 5);
        pharmacy.AddDrug("Fervex", 12, 35);
        pharmacy.AddDrug("Magic Pill", 15, 40);
        for (var elapsedDays = 0; elapsedDays < 30; elapsedDays++)
        {
            pharmacy.UpdateBenefitValue();
        }
        List<Drug> output = new List<Drug>();
        output.Add(new Drug("Doliprane", -10, 0));
        output.Add(new Drug("Herbal Tea", -20, 50));
        output.Add(new Drug("Fervex", -18, 0));
        output.Add(new Drug("Magic Pill", 15, 40));


    }
}