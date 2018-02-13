using SampleAppCore.Data.Enums;
using SampleAppCore.Service.ViewModel.Product;
using SampleAppCore.Utilities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace SampleAppCore.Service.Interfaces
{
    public interface IBillService
    {
        void Create(BillViewModel billVm);
        void Update(BillViewModel billVm);

        PageResult<BillViewModel> GetAllPaging(string startDate, String endDate, string keyword, int pageIndex, int pageSize);

        BillViewModel GetDetail(int billId);

        BillDetailViewModel GetBillDetil(BillDetailViewModel billDetailVM);

        void DeleteDetail(int productId, int billId, int colorId, int SizeId);

        void UpdateStatus(int orderId, BillStatus status);

        List<BillDetailViewModel> GetBillDetails(int billId);

        List<ColorViewModel> GetColors();

        List<SizeViewModel> GetSizes();

        void Save();
    }
}
