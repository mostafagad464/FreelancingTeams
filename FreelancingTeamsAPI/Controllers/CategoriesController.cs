using Microsoft.AspNetCore.Mvc;
using FreelancingTeamData.Models;
using FreelancingTeamData.Reopsitories;
using FreelancingTeamData.Interfaces;
namespace FreelancingTeamsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategory<Category> _category;
        public CategoriesController(ICategory<Category> category)
        {
            
            _category = category;
        }


        [HttpPost("addcategory")]
        public async Task<ActionResult<Category>> CreateCategory(Category category)
        {
            if (category != null)
            {
                Category newCategory = await _category.Create(category);
                if (newCategory != null)
                    return Ok(newCategory);
            }
            return BadRequest();
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategories()
        {

            var obj = await _category.GetAll();

            if (obj != null)
        
            {
              
                return Ok(obj);
            }
            return NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCategory(int id)
        {
            if (id != 0)
            {

                var category = await _category.Delete(id);
                if (category != null)
                {
                    return Ok(category);
                }
                else
                {
                    return NoContent();

                }
            

            }
            return BadRequest();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategory(int id)
        {
            if (id != 0)
            {
                var obj = await _category.GetById(id);
                if (obj != null)
                {
                    return Ok(obj);
                }
                return NotFound();
            }
            return BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatedCategory(Category category)
        {
        
            if (category != null)
            {
                var obj = await _category.Update( category);
                if (obj != null)
                {
                    return Ok(obj);
                }
                else
                {
                    return NotFound();
                }
            }
           
            return BadRequest();
        }

    }
}
