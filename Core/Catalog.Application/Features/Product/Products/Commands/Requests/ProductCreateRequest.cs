using Catalog.Application.DTOs.Product;
using MediatR;
namespace Catalog.Application.Features.Product.Products.Commands.Requests;

public record ProductCreateRequest(ProductDto Product) : IRequest;