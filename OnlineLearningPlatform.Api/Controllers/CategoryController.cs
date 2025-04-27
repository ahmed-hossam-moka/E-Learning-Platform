using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineLearningPlatform.BLL.Dtos;
using OnlineLearningPlatform.BLL.Managers;

namespace OnlineLearningPlatform.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryManager _categoryManager;

        public CategoryController(ICategoryManager categoryManager)
        {
            _categoryManager = categoryManager;
        }
        [HttpGet]
        public ActionResult GetAll()
        {
            var categories= _categoryManager.GetAll();
            if (categories == null)
                return NotFound("No categories found");
            else
                return Ok(categories);

        }
        [HttpGet("{Id}")]
        public ActionResult GetById(int Id)
        {
            var category = _categoryManager.GetById(Id);
            if (category == null)
                return NotFound("No category found");
            else
                return Ok(category);
        }
        [HttpPost]
        public ActionResult Add(CategoryAddDto category)
        {
            _categoryManager.Add(category);
            return CreatedAtAction(nameof(GetById), new { Id = category.CategoryId }, new { Message = "created successfully" });
        }
        [HttpPut("{Id}")]
        public ActionResult Update(int Id, CategoryUpdateDto Category)
        {
            if (Id != Category.CategoryId)
                return BadRequest();
            _categoryManager.Update(Category);
            return NoContent();
        }
        [HttpDelete("{Id}")]
        public ActionResult Delete(int Id)
        {
            _categoryManager.Delete(Id);
            return NoContent();
        }
    }
}
