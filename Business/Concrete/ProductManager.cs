using Business.Abstract;
using Business.Constans;
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

    public IDataResult<List<Product>> GetAllByCategoryId(int id)
    {
        return new SuccesDataResult<List<Product>>(_productDal.GetAll(p => p.CategoryId == id));

    }

    public IDataResult<List<Product>> GetAll()
    {
        //iş kodları
        if (DateTime.Now.Hour == 22)
        {
            return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
        }


        return new SuccesDataResult<List<Product>>(_productDal.GetAll(),Messages.ProductListed);

    }

    public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
    {
        return new SuccesDataResult<List<Product>>(_productDal.GetAll(p=>p.UnitPrice>=min && p.UnitPrice<=max));
    }

    public IDataResult<List<ProductDetailDto>> GetProductDetails()
    {
        return new SuccesDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails());
    }

    public IResult Add(Product product)
    {
        if (product.ProductName.Length < 2)
        {
            return new ErrorResult(Messages.ProductNameInvalid);
        }
        _productDal.Add(product);

        return new SuccesResult(Messages.ProductAdded);
    }
    public IDataResult<Product> GetById(int productId)
    {
        return new SuccesDataResult<Product>(_productDal.Get(p=>p.ProductId==productId));
    }

}
