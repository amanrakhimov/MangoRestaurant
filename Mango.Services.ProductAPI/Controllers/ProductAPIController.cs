﻿using Mango.Services.ProductAPI.DbContexts.Models;
using Mango.Services.ProductAPI.DbContexts.Models.Dto;
using Mango.Services.ProductAPI.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Mango.Services.ProductAPI.Controllers
{

    [Route("api/products")]
    public class ProductAPIController : ControllerBase
    {
        protected ResponseDto _response;
        private IProductRepository _productRepository;

        public ProductAPIController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
            this._response=new ResponseDto();
        }

        
        [HttpGet]
        [Authorize]
        public async Task<object> Get()
        {
            try
            {
                IEnumerable<ProductDto> productDtos=await _productRepository.GetProducts();
                _response.Result=productDtos;

            }
            catch (Exception ex)
            {

                _response.IsSuccess = false;
                _response.ErrorMessages=new List<string> { ex.ToString()};
            }
            return _response;
        }

        
        [HttpGet]
        [Authorize]
        [Route("{id}")]
        public async Task<object> Get(int id)
        {
            try
            {
                ProductDto productDtos = await _productRepository.GetProductById(id);
                _response.Result = productDtos;

            }
            catch (Exception ex)
            {

                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }
            return _response;
        }

        [HttpPost]
        [Authorize]
        public async Task<object> Post([FromBody] ProductDto productDto)
        {
            try
            {
                ProductDto model = await _productRepository.CreateUpdateProduct(productDto);
                _response.Result = model;

            }
            catch (Exception ex)
            {

                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }
            return _response;
        }
        [HttpPut]
        [Authorize]
        public async Task<object> Put([FromBody] ProductDto productDto)
        {
            try
            {
                ProductDto model = await _productRepository.CreateUpdateProduct(productDto);
                _response.Result = model;

            }
            catch (Exception ex)
            {

                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }
            return _response;
        }
        
        [HttpDelete]
        [Authorize("Admin")]
        [Route("{id}")]
        public async Task<object> Delete(int id)
        {
            try
            {
                bool IsSuccess = await _productRepository.DeleteProduct(id);
                _response.Result = IsSuccess;

            }
            catch (Exception ex)
            {

                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }
            return _response;
        }
    }
}
