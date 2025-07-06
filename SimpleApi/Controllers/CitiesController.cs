using System.Security.Cryptography.X509Certificates;
using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using SimpleApi.Entities;
using SimpleApi.models;
using SimpleApi.Repositories;

namespace SimpleApi.Controllers
{
    [ApiController]
    [Route("api/Cities")]
    public class CitiesController : ControllerBase
    {
        private readonly ICityInfoRepository _cityInfoRepository;
        private readonly IMapper _mapper;
        public CitiesController(ICityInfoRepository cityInfoRepository, IMapper mapper)
        {
            _cityInfoRepository = cityInfoRepository ?? throw new ArgumentNullException(nameof(cityInfoRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CityWithoutPointOfInterestDto>>> GetCities()
        {
            var cities = await _cityInfoRepository.GetCitiesAsync();
            return Ok(_mapper.Map<IEnumerable<CityWithoutPointOfInterestDto>>(cities));

        }

        [HttpGet("{cityId}")]
        public async Task<IActionResult> GetCity(int cityId, bool includePointOfInterest)
        {
            if (!await _cityInfoRepository.GetCityAsync(cityId))
            {
                return NotFound();
            }

            var city = await _cityInfoRepository.GetCitiesAsync(cityId, includePointOfInterest);

            if (includePointOfInterest)
            {
                return Ok(
                    _mapper.Map<CityDto>(city));
            }
            return Ok(
                _mapper.Map<CityWithoutPointOfInterestDto>(city));

        }
    }
}
