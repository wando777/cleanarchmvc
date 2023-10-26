using AutoMapper;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Application.Products.Commands;
using CleanArchMvc.Application.Products.Queries;
using CleanArchMvc.Domain.Entities;
using MediatR;

namespace CleanArchMvc.Application.Services
{
    public class ProductService : IProductService
    {
        //private IProductRepository _productRepository;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ProductService(IMapper mapper, IMediator mediator)
        {
            //_productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<IEnumerable<ProductDTO>> GetProductsAsync()
        {
            //var productsEntity = await _productRepository.GetProductsAsync();
            //return _mapper.Map<IEnumerable<ProductDTO>>(productsEntity);
            var productsQuery = new GetProductsQuery();
            if (productsQuery == null)
            {
                throw new Exception($"Error on entity load");
            }
            var result = await _mediator.Send(productsQuery);
            return _mapper.Map<IEnumerable<ProductDTO>>(result);
        }

        public async Task<ProductDTO> GetProductByIdAsync(int? id)
        {
            //var productsEntity = await _productRepository.GetByIdAsync(id);
            //return _mapper.Map<ProductDTO>(productsEntity);
            var productByIdQuery = new GetProductByIdQuery(id.Value);
            if (productByIdQuery == null)
            {
                throw new Exception($"Error on entity load");
            }
            var result = await _mediator.Send(productByIdQuery);
            return _mapper.Map<ProductDTO>(result);
        }

        //public async Task<ProductDTO> GetProductCategory(int? id)
        //{
        //    //var productEntity = await _productRepository.GetProductCategoryAsync(id);
        //    //return _mapper.Map<ProductDTO>(productEntity);
        //    var productByIdQuery = new GetProductByIdQuery(id.Value);
        //    if (productByIdQuery == null)
        //    {
        //        throw new Exception($"Error on entity load");
        //    }
        //    var result = await _mediator.Send(productByIdQuery);
        //    return _mapper.Map<ProductDTO>(result);
        //}

        public async Task Add(ProductDTO productDTO)
        {
            //var productEntity = _mapper.Map<Product>(productDTO);
            //await _productRepository.CreateAsync(productEntity);
            var productCreateCommand = _mapper.Map<ProductCreateCommand>(productDTO);
            await _mediator.Send(productCreateCommand);
        }

        public async Task Update(ProductDTO productDTO)
        {
            //var productEntity = _mapper.Map<Product>(productDTO);
            //await _productRepository.UpdateAsync(productEntity);
            var productUpdateCommand = _mapper.Map<ProductUpdateCommand>(productDTO);
            await _mediator.Send(productUpdateCommand);
        }

        public async Task Remove(int? id)
        {
            //var productEntity = _productRepository.GetByIdAsync(id).Result;
            //await _productRepository.RemoveAsync(productEntity);
            var productRemoveCommand = new ProductRemoveCommand(id.Value);
            if (productRemoveCommand == null)
            {
                throw new Exception($"Error on entity load");
            }
            await _mediator.Send(productRemoveCommand);
        }
    }
}
