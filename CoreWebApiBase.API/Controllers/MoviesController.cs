using CoreWebApiBase.Services.Dto;
using CoreWebApiBase.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace UnitOfWorkDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        public readonly IMovieService _movieService;
        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        /// <summary>
        /// Add a new product
        /// </summary>
        /// <param name="productDetails"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Insert(MovieRequestDto movie)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var isMovieCreated = await _movieService.CreateMovie(movie);

            return isMovieCreated ? Ok(isMovieCreated) : BadRequest();
        }


        /// <summary>
        /// Get the list of movies
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetProductList()
        {
            var productDetailsList = await _movieService.GetAllMovies();
            if (productDetailsList == null)
            {
                return NotFound();
            }
            return Ok(productDetailsList);
        }

        /// <summary>
        /// Get product by id
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        // [HttpGet("{movieId}")]
        // public async Task<IActionResult> GetProductById(int productId)
        // {
        //     var productDetails = await _movieService.GetProductById(productId);

        //     if (productDetails != null)
        //     {
        //         return Ok(productDetails);
        //     }
        //     else
        //     {
        //         return BadRequest();
        //     }
        // }


        /// <summary>
        /// Update the product
        /// </summary>
        /// <param name="productDetails"></param>
        /// <returns></returns>
        // [HttpPut]
        // public async Task<IActionResult> UpdateProduct(ProductDetails productDetails)
        // {
        //     if (productDetails != null)
        //     {
        //         var isProductCreated = await _productService.UpdateProduct(productDetails);
        //         if (isProductCreated)
        //         {
        //             return Ok(isProductCreated);
        //         }
        //         return BadRequest();
        //     }
        //     else
        //     {
        //         return BadRequest();
        //     }
        // }

        /// <summary>
        /// Delete product by id
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        // [HttpDelete("{productId}")]
        // public async Task<IActionResult> DeleteProduct(int productId)
        // {
        //     var isProductCreated = await _productService.DeleteProduct(productId);

        //     if (isProductCreated)
        //     {
        //         return Ok(isProductCreated);
        //     }
        //     else
        //     {
        //         return BadRequest();
        //     }
        // }
    }
}