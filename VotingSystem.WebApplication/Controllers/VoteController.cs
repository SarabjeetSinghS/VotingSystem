using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VotingSystem.Model.Votes;
using VotingSystem.Service.Services.Votes;
using VotingSystem.WebApplication.Contracts.V1;
using VotingSystem.WebApplication.Mapper;
using VotingSystem.WebApplication.ViewModel;

namespace VotingSystem.WebApplication.Controllers
{
    [Route(ApiRoutes.BaseRoute.V1)]
    [ApiController]
    public class VoteController : ControllerBase
    {
        private readonly IVoteService _voteService;
        public VoteController(IVoteService voteService)
        {
            this._voteService = voteService;
        }

        [HttpPost("CastVote", Name = "CastVote")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CastVote(AddVoteVM vote)
        {
            if (vote == null || !ModelState.IsValid)
                return BadRequest();
            try
            {
                //if voter is valid and he/she does not cast vote for same catergory before
                var isVoteAlreadyCasted = await this._voteService.IsVoteCastForCategoryByVoter(vote.VoterId, vote.CandidateCategoryId);
                if (isVoteAlreadyCasted)
                    return UnprocessableEntity("You already cast vote for this category");

                var IsValidUser = await this._voteService.IsVoterAndCandidateIsValid(vote.VoterId, vote.CandidateId, vote.CandidateCategoryId);
                if (!IsValidUser.VoterExist) // voter is not a valid 
                    return StatusCode(StatusCodes.Status404NotFound, "Voter does not associate with VoterSystem application, please register to cast vote");
                if (!IsValidUser.CandidateExist) // candidate is not a valid 
                    return StatusCode(StatusCodes.Status404NotFound, "Candidate selected is not valid, please recheck and try again");

                // now candidate and voter both are valid.
                var IsVoteCasted = await this._voteService.CastAVote(vote.ToVote());
                var status = IsVoteCasted == true ? "Thanks for voting. Your vote is succcessfully cast!" : "Unexpected error in voting system, please retry after 1 minute time";

                return CreatedAtAction(nameof(CastVote), status);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }


        [HttpPost("GetAllVotesByCandidate/{candidateId}", Name = "GetAllVotesByCandidate")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllVotesByCandidate(int candidateId)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            try
            {
                var allVotes = await this._voteService.GetVotesForCandidate(candidateId);
                return CreatedAtAction(nameof(GetAllVotesByCandidate),$"Candidate got {allVotes.Count} votes");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
