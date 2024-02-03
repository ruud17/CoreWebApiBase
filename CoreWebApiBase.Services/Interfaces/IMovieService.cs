

using CoreWebApiBase.Services.Dto;

namespace CoreWebApiBase.Services.Interfaces
{
    public interface IMovieService
    {
        public Task<IEnumerable<MovieResponseDto>> GetAllMovies();

        Task<bool> CreateMovie(MovieRequestDto movie);


        //      Task<ProductDetails> GetProductById(int productId);

        // Task<bool> UpdateProduct(ProductDetails productDetails);

        // Task<bool> DeleteProduct(int productId);
        //         Task<bool> CreateProduct(ProductDetails productDetails);

    }

}