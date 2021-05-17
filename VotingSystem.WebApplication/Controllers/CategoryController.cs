using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using VotingSystem.Model.Users;
using VotingSystem.Service.Services.CandidateCategories;
using VotingSystem.Service.Services.CandidateXCategories;
using VotingSystem.WebApplication.Contracts.V1;
using VotingSystem.WebApplication.Mapper;
using VotingSystem.WebApplication.ViewModel;

namespace VotingSystem.WebApplication.Controllers
{
    [Route(ApiRoutes.BaseRoute.V1)]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICandidateCategoryService _candidateCategoryService;
        private readonly ICandidateXCategoryService _candidateXCategoryService;
        public CategoryController(ICandidateCategoryService candidateCategoryService, ICandidateXCategoryService candidateXCategoryService)
        {
            _candidateCategoryService = candidateCategoryService;
            _candidateXCategoryService = candidateXCategoryService;
        }

        [HttpPost("Add", Name = "AddCategory")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(CandidateCategory))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Add(AddCategoryVM candidateCategory)
        {
            if (candidateCategory == null || !ModelState.IsValid)
                return BadRequest();
            try
            {
                var result = this._candidateCategoryService.Insert(candidateCategory.ToCandidateCategory());
                return CreatedAtAction(nameof(Add), result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        //Not using [FromService] attribute as it is heavy operation compare to constructor injection 
        //https://stackoverflow.com/questions/54656115/asp-net-core-what-challenges-or-issues-may-arise-from-using-fromservices-att
        [HttpPost("MapCandidateToCategory", Name = "MapCandidateToCategory")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(CandidateXCategory))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult MapCandidateToCategory(AddCandidateToCategoryVM candidateXCategory)
        {
            if (candidateXCategory == null || !ModelState.IsValid)
                return BadRequest();
            try
            {
                var result = this._candidateXCategoryService.Insert(candidateXCategory.ToCandidateXCategory());
                return CreatedAtAction(nameof(MapCandidateToCategory), result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }


        [HttpGet("GetAll", Name = "GetAll")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IAsyncEnumerable<CandidateCategory>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetAll()
        {
            try
            {
                var allCandidateCategories = this._candidateCategoryService.GetAllAsync();
                return Ok(allCandidateCategories);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("GetAllCandidatesWithCategories", Name = "GetAllCandidatesWithCategories")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IAsyncEnumerable<CandidateXCategory>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetAllCandidatesWithCategories()
        {
            try
            {
                var allCandidateWithCategories = this._candidateXCategoryService.GetAllAsync();
                return StatusCode(StatusCodes.Status200OK,allCandidateWithCategories);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

    }
}
