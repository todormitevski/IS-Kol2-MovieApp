using EShop.Domain.Domain;
using EShop.Domain.DTO;
using EShop.Domain.Identity;
using EShop.Service.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Movie_App.Service.Interface;

namespace EShop.Web.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : Controller
    {
        private readonly IOrderService orderService;
        private readonly IMovieService movieService;

        public AdminController(IOrderService orderService, IMovieService movieService)
        {
            this.orderService = orderService;
            this.movieService = movieService;
        }

        [HttpGet("[action]")]
        public List<Order> GetAllOrders()
        {
            return orderService.GetAllOrders();
        }

        [HttpPost("[action]")]
        public Order GetDetailsForOrder(BaseEntity id)
        {
            return orderService.GetDetailsForOrder(id);
        }

        [HttpPost("[action]")]
        public void ImportMovies(List<MovieDTO> model)
        {

            foreach (var item in model)
            {

                var movie = new Movie
                {
                    MovieName = item.MovieName,
                    MovieDescription = item.MovieDescription,
                    MovieImage = item.MovieImage,
                    Rating = item.Rating,
                    Tickets = null
                };

                movieService.CreateNewMovie(movie);
            }
        }
    }
}
