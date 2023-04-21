using DataLaag;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Fullstack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientController : ControllerBase
    {
        private MyDbContext _dbContext;

        public IngredientController(MyDbContext dbContext) 
        {
            _dbContext = dbContext;
        }


        // GET: api/<IngredientController>
        [HttpGet]

        public List<Ingredient> Get()
        {
            return this._dbContext.Ingredients.ToList();
        }
        

        // GET api/<IngredientController>/5
        [HttpGet("{id}")]
        public Ingredient Get(int id)
        {
            return this._dbContext.Ingredients.Find(id);
        }

        // POST api/<IngredientController>
        [HttpPost]
        public Ingredient Post([FromBody] Ingredient i)
        {
            this._dbContext.Ingredients.Add(i);
            this._dbContext.SaveChanges();

            return i;    
        }
        //1.open 2. aanpassen 3. save
        // PUT api/<IngredientController>/5
        [HttpPut("{id}")]
        public bool Put(int id, [FromBody] Ingredient newIngredient)
        {
            //openen
            Ingredient dbIngredient = this._dbContext.Ingredients.Find(id);
            if (dbIngredient == null)
                return false;

            //aanpassen
            dbIngredient.Name = newIngredient.Name;
            dbIngredient.IsVegan = newIngredient.IsVegan;
            dbIngredient.Amount = newIngredient.Amount;

            //save
            this._dbContext.Ingredients.Update(dbIngredient);
            this._dbContext.SaveChanges();
            return true;


        }

        // DELETE api/<IngredientController>/5
        [HttpDelete("{id}")]
        public bool Delete(int id)
            
        {//eerst de ingredients zoeken
            Ingredient dbIngredient = this._dbContext.Ingredients.Find(id);
            if (dbIngredient == null) 
                return false; 


            this._dbContext.Ingredients.Remove(dbIngredient);
            this._dbContext.SaveChanges();

            return true;
        }
    }
}
