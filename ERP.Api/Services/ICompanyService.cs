
using ERP.Api.Models;

namespace ERP.Api.Services;

public interface ICompanyService
{
    List<Company> GetAll();

    Company? GetById(int id);

    Company Create(Company company);

    Company? Update(int id, Company company);

    bool Delete(int id);
}