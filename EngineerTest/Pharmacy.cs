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

            //expire increment logic
           
            //non expired logic
            if (drug.ExpiresIn >= 0)
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

            switch (drug.Name)
            {
                case "Magic Pill":
                    break;
                default:
                    drug.ExpiresIn -= 1;
                    break;
            }

            //edge case logic to match old code
            if (drug.ExpiresIn == -1)
            {
                switch (drug.Name)
                {
                    case "Magic Pill":
                        break;
                    case "Fervex":
                        break;
                    case "Dafalgan":
                        break;
                    case "Herbal Tea":
                        drug.Benefit -= 1;
                        break;
                    default:
                        drug.Benefit += 1;
                        break;
                }
            }

            //expired logic
            if (drug.ExpiresIn < 0)
            {
                switch (drug.Name)
                {
                    case "Herbal Tea":
                        drug.Benefit = drug.Benefit + _Benefitdecrease *2;
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


            

        }
        return _drugs;
    }



    public IEnumerable<IDrug> refactoredcode()
    {
        for (var i = 0; i < _drugs.Count; i++)
        {
            if (
                _drugs[i].Name != "Herbal Tea" &&
                _drugs[i].Name != "Fervex"
            )
            {
                if (_drugs[i].Benefit > 0)
                {
                    if (_drugs[i].Name != "Magic Pill")
                    {
                        _drugs[i].Benefit = _drugs[i].Benefit - 1;
                    }
                }
            }
            else
            {
                if (_drugs[i].Benefit < 50)
                {
                    _drugs[i].Benefit = _drugs[i].Benefit + 1;
                    if (_drugs[i].Name == "Fervex")
                    {
                        if (_drugs[i].ExpiresIn < 11)
                        {
                            if (_drugs[i].Benefit < 50)
                            {
                                _drugs[i].Benefit = _drugs[i].Benefit + 1;
                            }
                        }

                        if (_drugs[i].ExpiresIn < 6)
                        {
                            if (_drugs[i].Benefit < 50)
                            {
                                _drugs[i].Benefit = _drugs[i].Benefit + 1;
                            }
                        }
                    }
                }
            }

            if (_drugs[i].Name != "Magic Pill")
            {
                _drugs[i].ExpiresIn = _drugs[i].ExpiresIn - 1;
            }

            if (_drugs[i].ExpiresIn < 0)
            {
                if (_drugs[i].Name != "Herbal Tea")
                {
                    if (_drugs[i].Name != "Fervex")
                    {
                        if (_drugs[i].Benefit > 0)
                        {
                            if (_drugs[i].Name != "Magic Pill")
                            {
                                _drugs[i].Benefit = _drugs[i].Benefit - 1;
                            }
                        }
                    }
                    else
                    {
                        _drugs[i].Benefit =
                            _drugs[i].Benefit - _drugs[i].Benefit;
                    }
                }
                else
                {
                    if (_drugs[i].Benefit < 50)
                    {
                        _drugs[i].Benefit = _drugs[i].Benefit + 1;
                    }
                }
            }
        }

        return _drugs;
    }
}