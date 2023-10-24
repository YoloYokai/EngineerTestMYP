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
    public IEnumerable<IDrug> UpdateBenefitValueRefactor()
    {
        foreach(var drug in _drugs)
        {
            if(drug.ExpiresIn <= 0)
            {
                switch (drug.Name)
                {
                    case "Herbal Tea":
                        drug.Benefit = drug.Benefit + _Benefitdecrease;
                        break;
                    case "Magic Pill":
                        break;
                    case "Fervex":
                        if (drug.ExpiresIn <= 5) drug.Benefit += 3;
                        else if (drug.ExpiresIn <= 10) drug.Benefit += 2;
                        break;
                    default:
                        drug.Benefit = drug.Benefit - _Benefitdecrease;
                        break;
                }
            }
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
                    default:
                        drug.Benefit = drug.Benefit - (_Benefitdecrease * _ExpiredMulti);
                        break;
                }
            }
            if(drug.Benefit < 0) drug.Benefit = 0;
            if(drug.Benefit > 50) drug.Benefit = 50;
        }
        return _drugs;
    }
    public IEnumerable<IDrug> UpdateBenefitValue()
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