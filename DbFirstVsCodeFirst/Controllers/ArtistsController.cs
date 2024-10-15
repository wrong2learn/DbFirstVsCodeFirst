using DbFirstVsCodeFirst.Contracts.Dtos.ArtistDtos;
using DbFirstVsCodeFirst.DbFirst.Domain.Models;
using DbFirstVsCodeFirst.DbFirst.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DbFirstVsCodeFirst.Controllers;

[ApiController]
[Route("[controller]")]
public class ArtistsController : ControllerBase
{
    private readonly IArtistRepository _artistRepo;
    private readonly DbFirstVsCodeFirst.CodeFirst.Domain.Repositories.IArtistRepository _artistRepository;

    public ArtistsController(
        IArtistRepository artistRepo,
        DbFirstVsCodeFirst.CodeFirst.Domain.Repositories.IArtistRepository artistRepository)
    {
        _artistRepo = artistRepo;
        _artistRepository = artistRepository;
    }

    #region DbFirst
    [HttpPost]
    [Route("/api/artists")]
    public async Task<IActionResult> Add(ArtistDto artist)
    {
        Artist artistToSave = new Artist
        {
            FirstName = artist.FirstName,
            LastName = artist.LastName,
            BirthDate = artist.BirthDate,
        };

        return Ok(await _artistRepo.AddArtist(artistToSave));
    }

    [HttpGet]
    [Route("/api/artists")]
    public async Task<IActionResult> GetAll()
    {
        List<ArtistDto> response = new List<ArtistDto>();

        var artistsFound = await _artistRepo.GetArtistsAsync();
        if (artistsFound != null && artistsFound.Any())
        {
            response = artistsFound.Select(a =>
                new ArtistDto
                {
                    FirstName = a.FirstName,
                    LastName = a.LastName,
                    BirthDate = a.BirthDate
                }).ToList();
        }
        return Ok(response);
    }
    #endregion

    #region CodeFirst
    [HttpPost]
    [Route("/api/artistsCodeFirst")]
    public async Task<IActionResult> AddCodeFirst(ArtistDto artist)
    {
        DbFirstVsCodeFirst.CodeFirst.Domain.Models.Artist artistToSave = new DbFirstVsCodeFirst.CodeFirst.Domain.Models.Artist
        {
            FirstName = artist.FirstName,
            LastName = artist.LastName,
            BirthDate = artist.BirthDate,
        };

        return Ok(await _artistRepository.AddArtist(artistToSave));
    }

    [HttpGet]
    [Route("/api/artistsCodeFirst")]
    public async Task<IActionResult> GetAllCodeFirst()
    {
        List<ArtistDto> response = new List<ArtistDto>();

        var artistsFound = await _artistRepository.GetArtistsAsync();
        if (artistsFound != null && artistsFound.Any())
        {
            response = artistsFound.Select(a =>
                new ArtistDto
                {
                    FirstName = a.FirstName,
                    LastName = a.LastName,
                    BirthDate = a.BirthDate
                }).ToList();
        }
        return Ok(response);
    }
    #endregion

}
