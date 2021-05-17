using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using VotingSystem.Model.Users;
using VotingSystem.Service.Services.Canditates;
using VotingSystem.WebApplication.Contracts.V1;
using VotingSystem.WebApplication.ViewModel;
using VotingSystem.WebApplication.Mapper;

namespace VotingSystem.WebApplication.Controllers
{
    [Route(ApiRoutes.BaseRoute.V1)]
    [ApiController]
    public class CandidateController : ControllerBase
    {
        private readonly ICandidateService _candidateService;
        public CandidateController(ICandidateService candidateService)
        {
            this._candidateService = candidateService;
        }

        [HttpPost("AddCandidate", Name = "AddCandidate")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Candidate))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult AddCandidate(AddCandidateVM candidate)
        {
            if (candidate == null || !ModelState.IsValid)
                return BadRequest();
            try
            {
                var result = this._candidateService.Insert(candidate.ToCandidate());
                return CreatedAtAction(nameof(AddCandidate), result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("GetAllCandidates", Name = "GetAllCandidates")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IAsyncEnumerable<Candidate>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetAllCandidateCategories()
        {
            try
            {
                var allCandidateCategories = this._candidateService.GetAllAsync();
                return Ok(allCandidateCategories);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
