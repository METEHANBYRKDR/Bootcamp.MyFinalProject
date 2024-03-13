using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete;

public class ProductManager : IProductService
{
    IProductDal _productDal;

    public ProductManager(IProductDal productDal)
    {
        _productDal = productDal;
    }

    public List<Product> GetAllByCategoryId(int id)
    {
        return _productDal.GetAll(p=>p.CategoryId==id);

    }

    public List<Product> GetAll()
    {
        //iş kodları
        return _productDal.GetAll();

    }

    public List<Product> GetByUnitPrice(decimal min, decimal max)
    {
        return _productDal.GetAll(p=>p.UnitPrice>=min && p.UnitPrice<=max);
    }

    public List<ProductDetailDto> GetProductDetails()
    {
        return _productDal.GetProductDetails();
    }

    public IResult Add(Product product)
    {
        _productDal.Add(product);
        if (product.ProductName.Length < 2)
        {
            return new ErrorResult("Ürün ismi en az 2 karakter olmalıdır.");
        }
        return new Result(true,"Ürün Eklendi");
    }

    public Product GetById(int productId)
    {
        return  _productDal.Get(p=>p.ProductId==productId);
    }

}
