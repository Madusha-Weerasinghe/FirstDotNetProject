
using ERP.Api.Models;
using ERP.Api.Services;
using Microsoft.AspNetCore.Mvc;
using ERP.Api.DTOs;

namespace ERP.Api.Controllers;

[ApiController]
[Route("api/companies")]
public class CompaniesController : ControllerBase
{
    private readonly ICompanyService _companyService;

    public CompaniesController(ICompanyService companyService)
    {
        _companyService = companyService;
    }

    [HttpGet]
    public ActionResult<List<Company>> GetAll()
    {
        return Ok(_companyService.GetAll());
    }

    [HttpGet("{id:int}")]
    public ActionResult<Company> GetById(int id)
    {
        var company = _companyService.GetById(id);

        if (company is null)
        {
            return NotFound();
        }

        return Ok(company);
    }

    
[HttpPost]
public ActionResult<Company> Create(CompanyRequestDto request)
{
    var company = new Company
    {
        Name = request.Name,
        Email = request.Email
    };

    var createdCompany = _companyService.Create(company);

    return CreatedAtAction(
        nameof(GetById),
        new { id = createdCompany.Id },
        createdCompany
    );
}



[HttpPut("{id:int}")]
public ActionResult<Company> Update(
    int id,
    CompanyRequestDto request)
{
    var company = new Company
    {
        Name = request.Name,
        Email = request.Email
    };

    var updatedCompany = _companyService.Update(id, company);

    if (updatedCompany is null)
    {
        return NotFound();
    }

    return Ok(updatedCompany);
}

[HttpDelete("{id:int}")]
public IActionResult Delete(int id)
{
    var deleted = _companyService.Delete(id);

    if (!deleted)
    {
        return NotFound();
    }

    return NoContent();
}
    
}