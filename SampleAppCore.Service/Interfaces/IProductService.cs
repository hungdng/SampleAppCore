using SampleAppCore.Service.ViewModel.Product;
using SampleAppCore.Utilities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace SampleAppCore.Service.Interfaces
{
    public interface IProductService: IDisposable
    {
        List<ProductViewModel> GetAll();

        PageResult<ProductViewModel> GetAllPaging(int? categoryId, string keyword, int page,  int pageSize);

        ProductViewModel Add(ProductViewModel productVm);

        void Update(ProductViewModel productVm);

        void Delete(int id);

        ProductViewModel GetById(int id);

        void Save();
    }
}
