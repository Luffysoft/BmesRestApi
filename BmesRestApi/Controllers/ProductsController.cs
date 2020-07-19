﻿using BmesRestApi.Messages.Requests.Products;
using BmesRestApi.Messages.Responses.Products;
using BmesRestApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace BmesRestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductsController(IProductService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public ActionResult<GetProductResponse> GetProduct(long id)
        {
            var request = new GetProductRequest { Id = id };
            var response = _service.GetProduct(request);
            return response;
        }

        [HttpGet("{categorySlug}/{brandSlug}/{page}/{productsPerPage}")]
        public ActionResult<FetchProductsResponse> GetProducts(string categorySlug, string brandSlug, int page, int productsPerPage)
        {
            var request = new FetchProductsRequest
            {
                PageNumber = page,
                ProductsPerPage = productsPerPage,
                CategorySlug = categorySlug,
                BrandSlug = brandSlug
            };
            var response = _service.GetProducts(request);
            return response;
        }

        [HttpPost]
        public ActionResult<CreateProductResponse> PostProduct(CreateProductRequest request)
        {
            var response = _service.SaveProduct(request);
            return response;
        }

        [HttpPut]
        public ActionResult<UpdateProductResponse> PutProduct(UpdateProductRequest request)
        {
            var response = _service.EditProduct(request);
            return response;
        }

        [HttpDelete("{id}")]
        public ActionResult<DeleteProductResponse> DeleteProduct(long id)
        {
            var request = new DeleteProductRequest { Id = id };
            var response = _service.DeleteProduct(request);
            return response;
        }
    }
}
