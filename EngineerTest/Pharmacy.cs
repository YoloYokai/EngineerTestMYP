namespace EngineerTest;

public class Pharmacy : IPharmacy
{
    private readonly List<IDrug> _drugs = new();
    private int _Benefitdecrease = 1;
    private int _ExpiredMulti = 2;
    public IDrug AddDrug(string name, int expiresIn, int benefit)
    {
        var drug = new Drug(name, expiresIn, benefit);
        _drugs.Add(drug);
        return drug;
    }
    public IEnumerable<IDrug> UpdateBenefitValue()
    {
        foreach(var drug in _drugs)
        {
            //non expired logic
            if(drug.ExpiresIn >= 0)
            {
                switch (drug.Name)
                {
                    case "Herbal Tea":
                        drug.Benefit = drug.Benefit + _Benefitdecrease;
                        break;
                    case "Magic Pill":
                        break;
                    case "Fervex":
                        if (drug.ExpiresIn <= 5) drug.Benefit += _Benefitdecrease*3;
                        else if (drug.ExpiresIn <= 10) drug.Benefit += _Benefitdecrease*2;
                        else if (drug.ExpiresIn > 1) drug.Benefit += _Benefitdecrease;
                        break;
                    default:
                        drug.Benefit = drug.Benefit - _Benefitdecrease;
                        break;
                }
            }
            //expired logic
            else
            {
                switch (drug.Name)
                {
                    case "Herbal Tea":
                        drug.Benefit = drug.Benefit + _Benefitdecrease * 2;
                        break;
                    case "Magic Pill":
                        break;
                    case "Fervex":
                        drug.Benefit = 0;
                        break;
                    case "Dafalgan":
                        drug.Benefit = drug.Benefit - (_Benefitdecrease * _ExpiredMulti * 2);
                        break;
                    default:
                        drug.Benefit = drug.Benefit - (_Benefitdecrease * _ExpiredMulti);
                        break;
                }
            }
            //catches for exceeding bounds
            if(drug.Benefit < 0) drug.Benefit = 0;
            if(drug.Benefit > 50) drug.Benefit = 50;


            //expire increment logic
            switch (drug.Name)
            {
                case "Magic Pill":
                    break;
                default:
                    drug.ExpiresIn -= 1;
                    break;
            }

        }
        return _drugs;
    }
}