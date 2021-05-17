using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using VotingSystem.Model.Users;
using VotingSystem.Service.Services.Voters;
using VotingSystem.WebApplication.Contracts.V1;
using VotingSystem.WebApplication.ViewModel;
using VotingSystem.WebApplication.Mapper;

namespace VotingSystem.WebApplication.Controllers
{
    [Route(ApiRoutes.BaseRoute.V1)]
    [ApiController]
    public class VoterController : ControllerBase
    {
        private readonly IVoterService _voterService;
        public VoterController(IVoterService voterService)
        {
            _voterService = voterService;
        }

        [HttpPost("Add", Name = "Add")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Voter))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Add(AddVoterVM voter)
        {
            if (voter == null || !ModelState.IsValid)
                return BadRequest();
            try
            {
                var result = this._voterService.Insert(voter.ToVoter());
                return CreatedAtAction(nameof(Add), result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("GetAllVoters", Name = "GetAllVoters")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IAsyncEnumerable<Candidate>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetAllVoters()
        {
            try
            {
                var allVoters = this._voterService.GetAllAsync();
                return Ok(allVoters);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }


        [HttpPut("UpdateBirthday", Name = "UpdateBirthday")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult UpdateBirthday(UpdateVoterAgeVM updateVoterAgeVM)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            try
            {
                var voterReturned = this._voterService.Get(updateVoterAgeVM.Id);
                if (voterReturned == null)// voter does not exsit in database
                    return NotFound("User has been removed or not register with Voting System!");
                voterReturned.Birthday = updateVoterAgeVM.Birthday;
                this._voterService.Update(voterReturned);
                return Ok("Voter's age has been successfully updated!");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("Delete", Name = "Delete")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            try
            {
                var voterReturned = this._voterService.Get(id);
                if (voterReturned == null)// voter does not exsit in database
                    return NoContent();
                this._voterService.Delete(voterReturned);
                return Ok("Voter is successfully removed from VotingSystem Application!");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
