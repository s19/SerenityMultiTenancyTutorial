using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.SaveRequest<MultiTenancy.Administration.TenantRow>;
using MyResponse = Serenity.Services.SaveResponse;
using MyRow = MultiTenancy.Administration.TenantRow;

namespace MultiTenancy.Administration
{
    public interface ITenantSaveHandler : ISaveHandler<MyRow, MyRequest, MyResponse> {}

    public class TenantSaveHandler : SaveRequestHandler<MyRow, MyRequest, MyResponse>, ITenantSaveHandler
    {
        public TenantSaveHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}