
using ERP.Api.Models;

namespace ERP.Api.Services;

public class CompanyService : ICompanyService
{
    private static readonly List<Company> _companies = new();
    private static int _nextId = 1;

    public List<Company> GetAll()
    {
        return _companies;
    }

    public Company? GetById(int id)
    {
        return _companies.FirstOrDefault(c => c.Id == id);
    }

    public Company Create(Company company)
    {
        company.Id = _nextId++;
        _companies.Add(company);

        return company;
    }


public Company? Update(int id, Company company)
{
    var existingCompany = _companies.FirstOrDefault(c => c.Id == id);

    if (existingCompany is null)
    {
        return null;
    }

    existingCompany.Name = company.Name;
    existingCompany.Email = company.Email;

    return existingCompany;
}

public bool Delete(int id)
{
    var company = _companies.FirstOrDefault(c => c.Id == id);

    if (company is null)
    {
        return false;
    }

    _companies.Remove(company);

    return true;
}
}