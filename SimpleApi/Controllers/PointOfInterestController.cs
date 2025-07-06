using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using SimpleApi.DbContexts;
using SimpleApi.Entities;
using SimpleApi.models;
using SimpleApi.Repositories;
using SimpleApi.Services;
using System.Security.Cryptography.X509Certificates;

namespace SimpleApi.Controllers
{
    [Route("/api/cities/{cityId}/pointofinterest")]
    [ApiController]
    public class PointOfInterestController : ControllerBase
    {
        private readonly CitiesDataStore _citiesDataStore;
        private readonly ICityInfoRepository _cityInfoRepository;
        private readonly ILogger<PointOfInterestController> _logger;
        private readonly IMailServices _mailService;
        private readonly IPointOfInterestInfoRepository _pointOfInterestInfoRepository;
        private readonly IMapper _mapper;

        public PointOfInterestController(ILogger<PointOfInterestController> logger, IMailServices _mailService,
            IPointOfInterestInfoRepository pointOfInterestInfoRepository, IMapper mapper, CitiesDataStore citiesDataStore, ICityInfoRepository cityInfoRepository)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mailService = _mailService ?? throw new ArgumentNullException(nameof(_mailService));
            _pointOfInterestInfoRepository = pointOfInterestInfoRepository ?? throw new ArgumentNullException(nameof(pointOfInterestInfoRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _citiesDataStore = citiesDataStore ?? throw new ArgumentNullException(nameof(citiesDataStore));
            _cityInfoRepository = cityInfoRepository ?? throw new ArgumentNullException(nameof(cityInfoRepository));

        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PointOfInterestDto>>> GetPointOfInterest(int cityId)
        {
            try
            {
                //throw new Exception("exception simple . . .");
                if (!await _cityInfoRepository.GetCityAsync(cityId))
                {
                    _logger.LogInformation($"{cityId} this city id not found ");
                    return StatusCode(404, "this id not found");
                    
                }
                var pointOfInterests = await _pointOfInterestInfoRepository.GetPointOfInterestsAsync(cityId);
                return Ok(
                   _mapper.Map<IEnumerable<PointOfInterestDto>>(pointOfInterests));
            }
            catch (Exception ex)
            {
                _logger.LogCritical("with have one Exception ");
                return StatusCode(500, "a problem happened in this segment ...");
            }

        }

        [HttpGet("{pointOfInterestId}", Name = "GetPointOfInterest")]
        public async Task<ActionResult<PointOfInterestDto>> GetPointOfInterest(int cityId, int pointOfInterestId)
        {
            if (!await _cityInfoRepository.GetCityAsync(cityId))
            {
                return NotFound();
            }


            var pointOfInterest = await _pointOfInterestInfoRepository.GetPointOfInterestsAsync(cityId, pointOfInterestId);

            if (pointOfInterest == null)
            {
                return NotFound();
            }

            return Ok(
                _mapper.Map<PointOfInterestDto>(pointOfInterest));
        }

        #region create

        [HttpPost]
        public async Task<ActionResult<PointOfInterestDto>> CreatePointOfInterest(
            int cityId, [FromBody] PointOfInterestForCreationDto pointOfInterest)
        {
            if (!await _cityInfoRepository.GetCityAsync(cityId))
            {
                return NotFound();
            }

            var finalPoint = _mapper.Map<PointOfInterest>(pointOfInterest);
            await _pointOfInterestInfoRepository.AddPointOfInterestForCityAsync(cityId, finalPoint);
            await _pointOfInterestInfoRepository.SaveChangesAsync();
            var createPoint = _mapper.Map<PointOfInterestDto>(finalPoint);
            return CreatedAtRoute("GetPointOfInterest", new
            {
                cityId,
                pointOfInterestId = createPoint.Id
            },
                createPoint);
            
        }
        #endregion

        [HttpPut("{pointOfInterestId}")]
        public async Task<ActionResult> EditPointOfInterest(int cityId, int pointOfInterestId, PointOfInterestUpdateDto pointOfInterest)
        {
            if (!await _cityInfoRepository.GetCityAsync(cityId))
            {
                return NotFound();
            }

            var point = await _pointOfInterestInfoRepository.GetPointOfInterestsAsync(cityId, pointOfInterestId);
            if (point == null)
            {
                return NotFound();
            }

            _mapper.Map(pointOfInterest, point); // chetor kar mikonat daghighan >????
            await _pointOfInterestInfoRepository.SaveChangesAsync();

            return NoContent();
        }

        [HttpPatch("{pointOfInterestId}")]
        public async Task<ActionResult> PatchEditPointOfInterest(int cityId,
            int pointOfInterestId,
            JsonPatchDocument<PointOfInterestUpdateDto> jsonPatchDocument)
        {
            if (!await _cityInfoRepository.GetCityAsync(cityId))
            {
                return NotFound();
            }

            var point = await _pointOfInterestInfoRepository.GetPointOfInterestsAsync(cityId, pointOfInterestId);
            if (point == null)
            {
                return NotFound();
            }

            var pointToPatch = _mapper.Map<PointOfInterestUpdateDto>(point);
            jsonPatchDocument.ApplyTo(pointToPatch, ModelState);
            if (!ModelState.IsValid)
            {
                BadRequest();
            }

            if (!TryValidateModel(pointToPatch))
            {
                BadRequest();
            }

            _mapper.Map(pointToPatch, point);
            await _pointOfInterestInfoRepository.SaveChangesAsync();
            return NoContent();
            

        }

        [HttpDelete("{pointOfInterestId}")]
        public async Task<ActionResult> DeletePointOfInterest(int cityId, int pointOfInterestId)
        {
            if (!await _cityInfoRepository.GetCityAsync(cityId))
            {
                return NotFound();
                
            }

            var pointOfInterestForDelete = await _pointOfInterestInfoRepository
                .GetPointOfInterestsAsync(cityId, pointOfInterestId);
            if (pointOfInterestForDelete == null)
            {
                return NotFound();
            }
            _pointOfInterestInfoRepository.RemovePointOfInterest(pointOfInterestForDelete);
            await _pointOfInterestInfoRepository.SaveChangesAsync();
            return NoContent();
        }


    }
}
