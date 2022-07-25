using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.RetrieveRequest;
using MyResponse = Serenity.Services.RetrieveResponse<MultiTenancy.Administration.TenantRow>;
using MyRow = MultiTenancy.Administration.TenantRow;

namespace MultiTenancy.Administration
{
    public interface ITenantRetrieveHandler : IRetrieveHandler<MyRow, MyRequest, MyResponse> {}

    public class TenantRetrieveHandler : RetrieveRequestHandler<MyRow, MyRequest, MyResponse>, ITenantRetrieveHandler
    {
        public TenantRetrieveHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}